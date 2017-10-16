using AutoMapper;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Models;
using Flash.Club13.Web.Controllers;
using Flash.Club13.Web.Models.PublicSchedule;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace Flash.Club13.UnitTests.Controllers
{
    [TestFixture]
    public class PublicScheduleControllerTests
    {
        [Test]
        public void Constructor_ShouldCreateCorrectInstanceWhenAllParametersAreValid()
        {
            var mapperStub = new Mock<IMapper>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();

            var sut = new PublicScheduleController(mapperStub.Object, weekScheduleServiceStub.Object);

            Assert.IsInstanceOf<PublicScheduleController>(sut);
        }

        [Test]
        public void Constructor_ShouldThrowWhenMapperIsInvalid()
        {
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();

            Assert.Throws<ArgumentException>(() => new PublicScheduleController(null, weekScheduleServiceStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenWeekScheduleSeerviceIsInvalid()
        {
            var mapperStub = new Mock<IMapper>();

            Assert.Throws<ArgumentException>(() => new PublicScheduleController(mapperStub.Object, null));
        }

        [Test]
        public void Current_ShouldRenderDefaultViewWithCorrectModel()
        {
            var mapperStub = new Mock<IMapper>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();

            var sut = new PublicScheduleController(mapperStub.Object, weekScheduleServiceStub.Object);

            var currentSchedule = new WeekSchedule();
            var model = new CurrentScheduleViewModel();

            weekScheduleServiceStub.Setup(x => x.GetCurrentSchedule()).Returns(currentSchedule);
            mapperStub.Setup(x => x.Map<CurrentScheduleViewModel>(It.IsAny<WeekSchedule>())).Returns(model);

            sut
                .WithCallTo(c => c.Current())
                .ShouldRenderDefaultView()
                .WithModel(model);
        }

        [Test]
        public void Current_CallWeekScheduleOnceAndGetCuretSchedule()
        {
            var mapperStub = new Mock<IMapper>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();

            var sut = new PublicScheduleController(mapperStub.Object, weekScheduleServiceStub.Object);

            var currentSchedule = new WeekSchedule();
            var model = new CurrentScheduleViewModel();

            weekScheduleServiceStub.Setup(x => x.GetCurrentSchedule()).Returns(currentSchedule);
            mapperStub.Setup(x => x.Map<CurrentScheduleViewModel>(It.IsAny<WeekSchedule>())).Returns(model);

            sut
                .WithCallTo(c => c.Current());

            weekScheduleServiceStub.Verify(x => x.GetCurrentSchedule(), Times.Once);
        }

        [Test]
        public void Current_ShouldCAllMapperOnceWithCurrentSchedule()
        {
            var mapperStub = new Mock<IMapper>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();

            var sut = new PublicScheduleController(mapperStub.Object, weekScheduleServiceStub.Object);

            var currentSchedule = new WeekSchedule();
            var model = new CurrentScheduleViewModel();

            weekScheduleServiceStub.Setup(x => x.GetCurrentSchedule()).Returns(currentSchedule);
            mapperStub.Setup(x => x.Map<CurrentScheduleViewModel>(It.IsAny<WeekSchedule>())).Returns(model);

            sut
                .WithCallTo(c => c.Current());

            mapperStub.Verify(x => x.Map<CurrentScheduleViewModel>(currentSchedule), Times.Once);
        }
    }
}
