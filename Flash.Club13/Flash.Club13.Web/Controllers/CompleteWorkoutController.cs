using AutoMapper;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Web.Infrastructure.Factories;
using Flash.Club13.Web.Infrastructure.Providers;
using Flash.Club13.Web.Models.CompleteWorkout;
using System;
using System.Linq;
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
        private readonly IModelViewFactory modelViewFactory;
        private readonly IDataModelFactory dataModelFactory;

        public CompleteWorkoutController(IMemberIdProvider memberIdProvider, IMemberService memberService, IMapper mapper, IPendingWorkoutService pendingWorkoutService, IModelViewFactory modelViewFactory, IDataModelFactory dataModelFactory)
        {
            this.memberIdProvider = memberIdProvider ?? throw new ArgumentException("MemberIdProvider cannot be null");
            this.memberService = memberService ?? throw new ArgumentException("memberService cannot be null");
            this.mapper = mapper ?? throw new ArgumentException("mapper cannot be null");
            this.pendingWorkoutService = pendingWorkoutService ?? throw new ArgumentException("pendingWorkoutService cannot be null");
            this.modelViewFactory = modelViewFactory ?? throw new ArgumentException("modelViewFactory cannot be null");
            this.dataModelFactory = dataModelFactory ?? throw new ArgumentException("dataModelFactory cannot be null");
        }

        public ActionResult All()
        {
            // get current member from DB
            var userId = this.memberIdProvider.GetLoggeedUserId();
            var loggedMember = this.memberService.GetByUserId(userId);

            var pendingWorkouts = loggedMember.PendingWorkouts.Where(x => x.IsCompleted == false);

            var model = this.modelViewFactory.CreateAllPendingViewModel();

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
            var model = this.modelViewFactory.CreateCompleteViewModel(id);

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Complete(CompleteViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var time = new TimeSpan(0, model.Minutes, model.Seconds);

                var pending = this.pendingWorkoutService.GetById(model.Id);

                this.pendingWorkoutService.MarkPendingAsCompleted(pending);

                var workout = this.dataModelFactory.CreateWorkout();

                workout.Member = pending.Member;
                workout.WorkoutInformation = pending.DailyWorkout.WorkoutInformation;
                workout.Time = time;

                var member = this.memberService.GetById(pending.Member.Id);

                this.memberService.AddWorkout(member, workout);

                return this.RedirectToAction("All");
            }

            return this.View(model.Id);
        }
    }
}