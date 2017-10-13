using AutoMapper;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Models;
using Flash.Club13.Web.Areas.Administration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flash.Club13.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManagerController : Controller
    {
        private readonly IMapper mapper;
        private readonly IExerciseService exerciseService;

        public ManagerController(IMapper mapper, IExerciseService exerciseService)
        {
            this.mapper = mapper;
            this.exerciseService = exerciseService;
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
            return this.View();
        }

        [HttpPost]
        public ActionResult CreateWorkout(object workout)
        {
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateSchedule()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult CreateSchedule(object schedule)
        {
            return this.RedirectToAction("Index");
        }
    }
}