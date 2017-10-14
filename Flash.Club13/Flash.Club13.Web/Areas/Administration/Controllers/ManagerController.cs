using AutoMapper;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Models;
using Flash.Club13.Web.Areas.Administration.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Flash.Club13.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManagerController : Controller
    {
        private readonly IMapper mapper;
        private readonly IExerciseService exerciseService;
        private readonly IWorkoutInformationService workoutInformationService;
        private readonly IWeekScheduleService weekScheduleService;

        public ManagerController(IMapper mapper, IExerciseService exerciseService, IWorkoutInformationService workoutInformationService, IWeekScheduleService weekScheduleService)
        {
            this.mapper = mapper;
            this.exerciseService = exerciseService;
            this.workoutInformationService = workoutInformationService;
            this.weekScheduleService = weekScheduleService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult CreateExercise()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult CreateExercise(CreateExerciseViewModel exercise)
        {
            var exerciseDataModel = this.mapper.Map<Exercise>(exercise);

            this.exerciseService.AddExercise(exerciseDataModel);

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateWorkout()
        {
            var allExercises = this.exerciseService.GetAll();

            var allExercisesViews = new List<ExerciseMutipleSelectionViewModel>();

            foreach (var exercise in allExercises)
            {
                var viewExercise = this.mapper.Map<ExerciseMutipleSelectionViewModel>(exercise);
                allExercisesViews.Add(viewExercise);
            }

            var model = new CreateWorkoutViewModel();
            model.AllExercises = allExercisesViews;

            return this.View(model);
        }

        [HttpPost]
        public ActionResult CreateWorkout(CreateWorkoutViewModel workout)
        {
            var workoutDataModel = this.mapper.Map<WorkoutInformation>(workout);

            this.workoutInformationService.AddWorkoutInformation(workoutDataModel);

            var validExercisesIds = workout.AllExercises.Where(x => x.IsSelected == true).Select(x => x.Id).ToList();

            var validExerciseDataModels = new List<Exercise>();

            foreach (var id in validExercisesIds)
            {
                var exerciseToInsert = this.exerciseService.GetById(id);

                validExerciseDataModels.Add(exerciseToInsert);
            }

            this.workoutInformationService.InsertMultipleExercisesToWorkoutInformation(workoutDataModel, validExerciseDataModels);

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateSchedule()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult CreateSchedule(CreateWeekScheduleViewModel schedule)
        {
            var scheduleDataModel = this.mapper.Map<WeekSchedule>(schedule);

            this.weekScheduleService.AddWeekSchedule(scheduleDataModel);

            return this.RedirectToAction("Edit", "Schedule", new { id = scheduleDataModel.Id });
        }
    }
}