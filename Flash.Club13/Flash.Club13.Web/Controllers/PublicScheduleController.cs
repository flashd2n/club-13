using AutoMapper;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Web.Models.PublicSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flash.Club13.Web.Controllers
{
    public class PublicScheduleController : Controller
    {
        private readonly IMapper mapper;
        private readonly IWeekScheduleService weekScheduleService;

        public PublicScheduleController(IMapper mapper, IWeekScheduleService weekScheduleService)
        {
            this.mapper = mapper ?? throw new ArgumentException("Mapper cannot be null");
            this.weekScheduleService = weekScheduleService ?? throw new ArgumentException("Mapper cannot be null");
        }

        public ActionResult Current()
        {
            var currentSchedule = this.weekScheduleService.GetCurrentSchedule();

            var model = this.mapper.Map<CurrentScheduleViewModel>(currentSchedule);

            return this.View(model);
        }
    }
}