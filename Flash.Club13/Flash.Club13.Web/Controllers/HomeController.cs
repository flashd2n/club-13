using Flash.Club13.Interfaces.Services;
using Flash.Club13.Models;
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

        public HomeController(IMemberService memberService, IWorkoutService workoutService)
        {
            this.memberService = memberService;
            this.workoutService = workoutService;
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

            var model = new TotalMembersViewModel();
            model.Count = totalCount;

            return this.PartialView("_TotalMembersPartial", model);
        }

        [OutputCache(Duration = 100)]
        [ChildActionOnly]
        public ActionResult TotalWorkouts()
        {
            var totalCount = this.workoutService.GetTotalWorkouts();

            var model = new TotalWorkoutsViewModel();
            model.Count = totalCount;

            return this.PartialView("_TotalWorkoutsPartial", model);
        }
    }
}