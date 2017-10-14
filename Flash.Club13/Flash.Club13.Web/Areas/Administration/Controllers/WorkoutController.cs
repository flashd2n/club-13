using AutoMapper;
using Flash.Club13.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flash.Club13.Web.Areas.Administration.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly IMapper mapper;
        private readonly IWorkoutInformationService workoutInformationService;

        public WorkoutController(IMapper mapper, IWorkoutInformationService workoutInformationService)
        {
            this.mapper = mapper;
            this.workoutInformationService = workoutInformationService;
        }

        public ActionResult GetWorkoutNames()
        {
            var allNames = this.workoutInformationService.GetAllNames();
            return this.Json(allNames, JsonRequestBehavior.AllowGet);
            
        }

    }
}