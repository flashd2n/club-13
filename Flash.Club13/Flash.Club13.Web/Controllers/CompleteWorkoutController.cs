using Flash.Club13.Interfaces.Services;
using Flash.Club13.Web.Infrastructure.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flash.Club13.Web.Controllers
{
    [Authorize]
    public class CompleteWorkoutController : Controller
    {
        private readonly IMemberIdProvider memberIdProvider;
        private readonly IMemberService memberService;

        public CompleteWorkoutController(IMemberIdProvider memberIdProvider, IMemberService memberService)
        {
            this.memberIdProvider = memberIdProvider;
            this.memberService = memberService;
        }

        public ActionResult All()
        {
            // get current member from DB
            var userId = this.memberIdProvider.GetLoggeedUserId();
            var loggedMember = this.memberService.GetByUserId(userId);

            var test = loggedMember.DailyWorkouts;

            return this.View();
        }
    }
}