using AutoMapper;
using Flash.Club13.Interfaces.Providers;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Web.Infrastructure.Providers;
using Flash.Club13.Web.Models.Home;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public WorkoutController(IMapper mapper, IWorkoutInformationService workoutInformationService, IWeekScheduleService weekScheduleService, IDatetimeProvider datetimeProvider, IDailyWorkoutService dailyWorkoutService, IMemberIdProvider memberIdProvider, IMemberService memberService)
        {
            this.mapper = mapper;
            this.workoutInformationService = workoutInformationService;
            this.weekScheduleService = weekScheduleService;
            this.datetimeProvider = datetimeProvider;
            this.dailyWorkoutService = dailyWorkoutService;
            this.memberIdProvider = memberIdProvider;
            this.memberService = memberService;
        }

        public ActionResult GetWorkOutOfTheDay()
        {
            var currentSchedule = this.weekScheduleService.GetCurrentSchedule();

            if (currentSchedule == null)
            {
                return this.PartialView("_HomeWoDPartial");
            }

            var day = this.datetimeProvider.GetCurrentDayOfWeek().ToString();

            var currentWorkout = currentSchedule.DailyWorkouts.FirstOrDefault(x => x.Day == day);

            if (currentWorkout == null)
            {
                return this.PartialView("_HomeWoDPartial");
            }

            var workoutDetails = currentWorkout.WorkoutInformation;

            var model = this.mapper.Map<HomeWoDViewModel>(workoutDetails);

            return this.PartialView("_HomeWoDPartial", model);
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

            var userId = this.memberIdProvider.GetLoggeedUserId();
            var loggedMember = this.memberService.GetByUserId(userId);

            var model = new SignUpWoDViewModel();

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
            // get daily workout from db by id
            var dailyWoD = this.dailyWorkoutService.GetById(SelectedWoDId);
            // get the member from Db
            var userId = this.memberIdProvider.GetLoggeedUserId();
            var loggedMember = this.memberService.GetByUserId(userId);
            // add member to daily wod signed members collection
            this.dailyWorkoutService.AddMemberToDailyWorkout(loggedMember, dailyWoD);

            var responseTest = string.Format($"Signed for {dailyWoD.StartTime} workout");

            return this.Json(responseTest);
        }

        public ActionResult GetWorkoutNames()
        {
            var allNames = this.workoutInformationService.GetAllNames();
            return this.Json(allNames, JsonRequestBehavior.AllowGet);
            
        }

    }
}