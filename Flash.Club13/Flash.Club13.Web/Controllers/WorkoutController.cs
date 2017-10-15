using AutoMapper;
using Flash.Club13.Interfaces.Providers;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Web.Infrastructure.Factories;
using Flash.Club13.Web.Infrastructure.Providers;
using Flash.Club13.Web.Models.Home;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Flash.Club13.Web.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly IMapper mapper;
        private readonly IWorkoutInformationService workoutInformationService;
        private readonly IWeekScheduleService weekScheduleService;
        private readonly IDatetimeProvider datetimeProvider;
        private readonly IDailyWorkoutService dailyWorkoutService;
        private readonly IMemberIdProvider memberIdProvider;
        private readonly IMemberService memberService;
        private readonly IWorkoutService workoutService;
        private readonly IModelViewFactory modelViewFactory;
        private readonly IDataModelFactory dataModelFactory;

        public WorkoutController(IMapper mapper, IWorkoutInformationService workoutInformationService, IWeekScheduleService weekScheduleService, IDatetimeProvider datetimeProvider, IDailyWorkoutService dailyWorkoutService, IMemberIdProvider memberIdProvider, IMemberService memberService, IWorkoutService workoutService, IModelViewFactory modelViewFactory, IDataModelFactory dataModelFactory)
        {
            this.mapper = mapper;
            this.workoutInformationService = workoutInformationService;
            this.weekScheduleService = weekScheduleService;
            this.datetimeProvider = datetimeProvider;
            this.dailyWorkoutService = dailyWorkoutService;
            this.memberIdProvider = memberIdProvider;
            this.memberService = memberService;
            this.workoutService = workoutService;
            this.modelViewFactory = modelViewFactory;
            this.dataModelFactory = dataModelFactory;
        }

        [OutputCache(Duration = 42)]
        public ActionResult GetWorkOutOfTheDay()
        {
            var currentSchedule = this.weekScheduleService.GetCurrentSchedule();

            if (currentSchedule == null)
            {
                return this.PartialView("_WoDPartial");
            }

            var day = this.datetimeProvider.GetCurrentDayOfWeek().ToString();

            var currentWorkout = currentSchedule.DailyWorkouts.FirstOrDefault(x => x.Day == day);

            if (currentWorkout == null)
            {
                return this.PartialView("_WoDPartial");
            }

            var bestTime = this.workoutService.GetBestTime(currentWorkout);

            var workoutDetails = currentWorkout.WorkoutInformation;

            var model = this.mapper.Map<WoDViewModel>(workoutDetails);
            model.BestTime = bestTime;

            return this.PartialView("_WoDPartial", model);
        }

        [HttpGet]
        public ActionResult SignUpForWorkout()
        {
            var currentSchedule = this.weekScheduleService.GetCurrentSchedule();

            if (currentSchedule == null)
            {
                return this.PartialView("_HomeWoDSignUp");
            }

            var day = this.datetimeProvider.GetCurrentDayOfWeek().ToString();

            var workouts = currentSchedule.DailyWorkouts.Where(x => x.Day == day).ToList();

            if (workouts.Count == 0)
            {
                return this.PartialView("_HomeWoDSignUp");
            }

            var userId = this.memberIdProvider.GetLoggeedUserId();
            var loggedMember = this.memberService.GetByUserId(userId);

            var model = this.modelViewFactory.CreateSignUpWoDViewModel();

            foreach (var wod in workouts)
            {
                var wodModel = this.mapper.Map<HomeDailyWoDViewModel>(wod);
                model.AllDailyWoDs.Add(wodModel);

                var signedMember = wod.SignedMembers.FirstOrDefault(x => x.Id == loggedMember.Id);

                if (signedMember != null)
                {
                    model.IsSigned = true;
                    model.SignedDailyWoD = wodModel;
                }
            }

            return this.PartialView("_HomeWoDSignUp", model);
        }

        [HttpPost]
        public ActionResult SignUpForWorkout(Guid SelectedWoDId)
        {
            if (SelectedWoDId == default(Guid))
            {
                return this.RedirectToAction("SignUpForWorkout");
            }

            var dailyWoD = this.dailyWorkoutService.GetById(SelectedWoDId);

            var userId = this.memberIdProvider.GetLoggeedUserId();

            var loggedMember = this.memberService.GetByUserId(userId);

            this.dailyWorkoutService.AddMemberToDailyWorkout(loggedMember, dailyWoD);

            var pending = this.dataModelFactory.CreatePendingWorkout(dailyWoD, loggedMember, false);

            this.memberService.AddPending(loggedMember, pending);

            var responseTest = string.Format($"Signed for {dailyWoD.StartTime} workout");

            return this.Json(responseTest);
        }

        public ActionResult GetWorkoutNames()
        {
            var allNames = this.workoutInformationService.GetAllNames();
            return this.Json(allNames, JsonRequestBehavior.AllowGet);
            
        }

        public ActionResult AllWorkouts()
        {
            var allWorkouts = this.workoutInformationService.GetAll();

            var model = this.modelViewFactory.CreateAllWorkoutsViewModel();

            foreach (var wod in allWorkouts)
            {
                var bestTime = this.workoutService.GetBestTime(wod);
                var wodViewModel = this.mapper.Map<WoDViewModel>(wod);
                wodViewModel.BestTime = bestTime;

                model.AllWorkouts.Add(wodViewModel);
            }

            return this.View(model);
        }
    }
}