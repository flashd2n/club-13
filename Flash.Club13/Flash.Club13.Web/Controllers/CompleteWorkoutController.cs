using AutoMapper;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Models;
using Flash.Club13.Web.Infrastructure.Providers;
using Flash.Club13.Web.Models.CompleteWorkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flash.Club13.Web.Controllers
{
    [Authorize]
    public class CompleteWorkoutController : Controller
    {
        private readonly IMemberIdProvider memberIdProvider;
        private readonly IMemberService memberService;
        private readonly IMapper mapper;
        private readonly IPendingWorkoutService pendingWorkoutService;

        public CompleteWorkoutController(IMemberIdProvider memberIdProvider, IMemberService memberService, IMapper mapper, IPendingWorkoutService pendingWorkoutService)
        {
            this.memberIdProvider = memberIdProvider;
            this.memberService = memberService;
            this.mapper = mapper;
            this.pendingWorkoutService = pendingWorkoutService;
        }

        public ActionResult All()
        {
            // get current member from DB
            var userId = this.memberIdProvider.GetLoggeedUserId();
            var loggedMember = this.memberService.GetByUserId(userId);

            var pendingWorkouts = loggedMember.PendingWorkouts.Where(x => x.IsCompleted == false);

            var model = new AllPendingViewModel();

            foreach (var pending in pendingWorkouts)
            {
                var pendingViewModel = this.mapper.Map<AllPendingSingleWorkoutViewModel>(pending);
                model.AllWorkouts.Add(pendingViewModel);
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Complete(Guid id)
        {
            var model = new CompleteViewModel();
            model.Id = id;

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Complete(CompleteViewModel model)
        {
            var time = new TimeSpan(0, model.Minutes, model.Seconds);

            var pending = this.pendingWorkoutService.GetById(model.Id);

            this.pendingWorkoutService.MarkPendingAsCompleted(pending);

            var workout = new Workout();
            workout.Member = pending.Member;
            workout.WorkoutInformation = pending.DailyWorkout.WorkoutInformation;
            workout.Time = time;

            var member = this.memberService.GetById(pending.Member.Id);

            this.memberService.AddWorkout(member, workout);

            return this.RedirectToAction("All");
        }
    }
}