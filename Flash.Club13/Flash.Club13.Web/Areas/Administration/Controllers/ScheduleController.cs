using AutoMapper;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Models;
using Flash.Club13.Models.Enums;
using Flash.Club13.Web.Areas.Administration.Models.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flash.Club13.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ScheduleController : Controller
    {
        private readonly IMapper mapper;
        private readonly IWeekScheduleService weekScheduleService;
        private readonly IWorkoutInformationService workoutInformationService;
        private readonly IDailyWorkoutService dailyWorkoutService;

        public ScheduleController(IMapper mapper, IWeekScheduleService weekScheduleService, IWorkoutInformationService workoutInformationService, IDailyWorkoutService dailyWorkoutService)
        {
            this.mapper = mapper;
            this.weekScheduleService = weekScheduleService;
            this.workoutInformationService = workoutInformationService;
            this.dailyWorkoutService = dailyWorkoutService;
        }

        public ActionResult All()
        {
            var allSchedules = this.weekScheduleService.GetAllDescending();

            var allSchedulesViewModels = new List<ScheduleViewModel>();

            foreach (var schedule in allSchedules)
            {
                var scheduleViewModel = this.mapper.Map<ScheduleViewModel>(schedule);
                allSchedulesViewModels.Add(scheduleViewModel);
            }

            var viewModel = new AllSchedulesViewModel();
            viewModel.Schedules = allSchedulesViewModels;
            
            return this.View(viewModel);
        }

        public ActionResult Edit(Guid id)
        {
            var scheduleDataModel = this.weekScheduleService.GetById(id);
            var scheduleViewModel = this.mapper.Map<EditScheduleViewModel>(scheduleDataModel);

            foreach (var dailyWorkout in scheduleDataModel.DailyWorkouts)
            {
                var dailyWorkoutViewModel = this.mapper.Map<DailyWorkoutViewModel>(dailyWorkout);

                var wodDay = dailyWorkoutViewModel.Day;

                // check of key exists before adding to dictionary
                if (scheduleViewModel.AllWorkouts.ContainsKey(wodDay))
                {
                    continue;
                }

                scheduleViewModel.AllWorkouts.Add(wodDay, dailyWorkoutViewModel);

            }

            return this.View(scheduleViewModel);
        }

        [HttpPost]
        public ActionResult Edit(DailyWorkoutViewModel dailyWorkout)
        {
            var wodInfo = this.workoutInformationService.GetByName(dailyWorkout.Name);

            var morningDailyWodDataModel = this.mapper.Map<DailyWorkout>(dailyWorkout);
            morningDailyWodDataModel.WorkoutInformation = wodInfo;
            morningDailyWodDataModel.StartTime = TimeOfDay.Morning;

            var noonDailyWodDataModel = this.mapper.Map<DailyWorkout>(dailyWorkout);
            noonDailyWodDataModel.WorkoutInformation = wodInfo;
            noonDailyWodDataModel.StartTime = TimeOfDay.Noon;

            var eveningDailyWodDataModel = this.mapper.Map<DailyWorkout>(dailyWorkout);
            eveningDailyWodDataModel.WorkoutInformation = wodInfo;
            eveningDailyWodDataModel.StartTime = TimeOfDay.Evening;

            this.dailyWorkoutService.AddAllDailyWorkouts(morningDailyWodDataModel, noonDailyWodDataModel, eveningDailyWodDataModel);

            var schedule = this.weekScheduleService.GetById(dailyWorkout.ScheduleId);

            this.weekScheduleService.AddDailiesToSchedule(schedule, morningDailyWodDataModel, noonDailyWodDataModel, eveningDailyWodDataModel);

            return this.Json(dailyWorkout.Name, JsonRequestBehavior.DenyGet);
        }

    }
}