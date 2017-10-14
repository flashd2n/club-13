using AutoMapper;
using Flash.Club13.Interfaces.Providers;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Web.Models.Home;
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

        public WorkoutController(IMapper mapper, IWorkoutInformationService workoutInformationService, IWeekScheduleService weekScheduleService, IDatetimeProvider datetimeProvider)
        {
            this.mapper = mapper;
            this.workoutInformationService = workoutInformationService;
            this.weekScheduleService = weekScheduleService;
            this.datetimeProvider = datetimeProvider;
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

            return this.PartialView("_HomeWoDSignUp");
        }

        public ActionResult GetWorkoutNames()
        {
            var allNames = this.workoutInformationService.GetAllNames();
            return this.Json(allNames, JsonRequestBehavior.AllowGet);
            
        }

    }
}