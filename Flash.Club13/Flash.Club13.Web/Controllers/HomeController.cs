using Flash.Club13.Interfaces.Services;
using Flash.Club13.Models;
using Flash.Club13.Web.Infrastructure.Factories;
using Flash.Club13.Web.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flash.Club13.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemberService memberService;
        private readonly IWorkoutService workoutService;
        private readonly IModelViewFactory modelViewFactory;

        public HomeController(IMemberService memberService, IWorkoutService workoutService, IModelViewFactory modelViewFactory)
        {
            this.memberService = memberService;
            this.workoutService = workoutService;
            this.modelViewFactory = modelViewFactory;
        }

        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 100)]
        [ChildActionOnly]
        public ActionResult TotalMembers()
        {
            var totalCount = this.memberService.GetTotalMemberCount();

            var model = this.modelViewFactory.CreateTotalMembersViewModel(totalCount);

            return this.PartialView("_TotalMembersPartial", model);
        }

        [OutputCache(Duration = 100)]
        [ChildActionOnly]
        public ActionResult TotalWorkouts()
        {
            var totalCount = this.workoutService.GetTotalWorkouts();

            var model = this.modelViewFactory.CreateTotalWorkoutsViewModel(totalCount);

            return this.PartialView("_TotalWorkoutsPartial", model);
        }
    }
}