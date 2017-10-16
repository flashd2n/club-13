using AutoMapper;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Models;
using Flash.Club13.Web.Areas.Administration.Controllers;
using Flash.Club13.Web.Areas.Administration.Models.Schedule;
using Flash.Club13.Web.Infrastructure.Factories;
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
    public class ScheduleControllerTests
    {
        [Test]
        public void Constructor_ShouldCreateCorrectInstanceWhenAllParametersAreValid()
        {
            var mapperStub = new Mock<IMapper>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();

            var sut = new ScheduleController(mapperStub.Object, weekScheduleServiceStub.Object, workoutInformationServiceStub.Object, dailyWorkoutServiceStub.Object, modelViewFactoryStub.Object);

            Assert.IsInstanceOf<ScheduleController>(sut);
        }

        [Test]
        public void Constructor_ShouldThrowWhenMapperIsInvalid()
        {
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();

            Assert.Throws<ArgumentException>(() => new ScheduleController(null, weekScheduleServiceStub.Object, workoutInformationServiceStub.Object, dailyWorkoutServiceStub.Object, modelViewFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenWeekScheduleServiceIsInvalid()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();

            Assert.Throws<ArgumentException>(() => new ScheduleController(mapperStub.Object, null, workoutInformationServiceStub.Object, dailyWorkoutServiceStub.Object, modelViewFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenWorkoutInformationServiceIsInValid()
        {
            var mapperStub = new Mock<IMapper>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();

            Assert.Throws<ArgumentException>(() => new ScheduleController(mapperStub.Object, weekScheduleServiceStub.Object, null, dailyWorkoutServiceStub.Object, modelViewFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenModelViewFactoryIsInvalid()
        {
            var mapperStub = new Mock<IMapper>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            
            Assert.Throws<ArgumentException>(() => new ScheduleController(mapperStub.Object, weekScheduleServiceStub.Object, workoutInformationServiceStub.Object, dailyWorkoutServiceStub.Object, null));
        }

        [Test]
        public void Constructor_ShouldThrowWhenDailyWorkoutServiceIsInvalid()
        {
            var mapperStub = new Mock<IMapper>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            Assert.Throws<ArgumentException>(() => new ScheduleController(mapperStub.Object, weekScheduleServiceStub.Object, workoutInformationServiceStub.Object, null, modelViewFactoryStub.Object));
        }

        [Test]
        public void All_ShouldRenderDefaultViewWithCorrectModel()
        {
            var mapperStub = new Mock<IMapper>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();

            var sut = new ScheduleController(mapperStub.Object, weekScheduleServiceStub.Object, workoutInformationServiceStub.Object, dailyWorkoutServiceStub.Object, modelViewFactoryStub.Object);

            var allSchedules = new List<WeekSchedule>()
            {
                new WeekSchedule()
            };
            var scheduleViewModel = new ScheduleViewModel();
            var allSchedulesViewModel = new AllSchedulesViewModel();

            weekScheduleServiceStub.Setup(x => x.GetAllDescending()).Returns(allSchedules);
            mapperStub.Setup(x => x.Map<ScheduleViewModel>(It.IsAny<WeekSchedule>())).Returns(scheduleViewModel);
            modelViewFactoryStub.Setup(x => x.CreateAllSchedulesViewModel(It.IsAny<List<ScheduleViewModel>>())).Returns(allSchedulesViewModel);

            sut
                .WithCallTo(c => c.All())
                .ShouldRenderDefaultView()
                .WithModel(allSchedulesViewModel);
        }

        [Test]
        public void All_ShouldGetAllSchedulesFromWeekScheduleServiceOnce()
        {
            var mapperStub = new Mock<IMapper>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();

            var sut = new ScheduleController(mapperStub.Object, weekScheduleServiceStub.Object, workoutInformationServiceStub.Object, dailyWorkoutServiceStub.Object, modelViewFactoryStub.Object);

            var allSchedules = new List<WeekSchedule>()
            {
                new WeekSchedule()
            };
            var scheduleViewModel = new ScheduleViewModel();
            var allSchedulesViewModel = new AllSchedulesViewModel();

            weekScheduleServiceStub.Setup(x => x.GetAllDescending()).Returns(allSchedules);
            mapperStub.Setup(x => x.Map<ScheduleViewModel>(It.IsAny<WeekSchedule>())).Returns(scheduleViewModel);
            modelViewFactoryStub.Setup(x => x.CreateAllSchedulesViewModel(It.IsAny<List<ScheduleViewModel>>())).Returns(allSchedulesViewModel);

            sut
                .WithCallTo(c => c.All());

            weekScheduleServiceStub.Verify(x => x.GetAllDescending(), Times.Once);

        }

        [Test]
        public void All_ShouldCallMapperOnceWhenWeekScheduleReturnsOneWeekSchedule()
        {
            var mapperStub = new Mock<IMapper>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();

            var sut = new ScheduleController(mapperStub.Object, weekScheduleServiceStub.Object, workoutInformationServiceStub.Object, dailyWorkoutServiceStub.Object, modelViewFactoryStub.Object);

            var allSchedules = new List<WeekSchedule>()
            {
                new WeekSchedule()
            };
            var scheduleViewModel = new ScheduleViewModel();
            var allSchedulesViewModel = new AllSchedulesViewModel();

            weekScheduleServiceStub.Setup(x => x.GetAllDescending()).Returns(allSchedules);
            mapperStub.Setup(x => x.Map<ScheduleViewModel>(It.IsAny<WeekSchedule>())).Returns(scheduleViewModel);
            modelViewFactoryStub.Setup(x => x.CreateAllSchedulesViewModel(It.IsAny<List<ScheduleViewModel>>())).Returns(allSchedulesViewModel);

            sut
                .WithCallTo(c => c.All());

            mapperStub.Verify(x => x.Map<ScheduleViewModel>(It.IsAny<WeekSchedule>()), Times.Once);

        }

        [Test]
        public void All_ShouldCallModelViewFactoryOnceToGetViewModel()
        {
            var mapperStub = new Mock<IMapper>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();

            var sut = new ScheduleController(mapperStub.Object, weekScheduleServiceStub.Object, workoutInformationServiceStub.Object, dailyWorkoutServiceStub.Object, modelViewFactoryStub.Object);

            var allSchedules = new List<WeekSchedule>()
            {
                new WeekSchedule()
            };
            var scheduleViewModel = new ScheduleViewModel();
            var allSchedulesViewModel = new AllSchedulesViewModel();

            weekScheduleServiceStub.Setup(x => x.GetAllDescending()).Returns(allSchedules);
            mapperStub.Setup(x => x.Map<ScheduleViewModel>(It.IsAny<WeekSchedule>())).Returns(scheduleViewModel);
            modelViewFactoryStub.Setup(x => x.CreateAllSchedulesViewModel(It.IsAny<List<ScheduleViewModel>>())).Returns(allSchedulesViewModel);

            sut
                .WithCallTo(c => c.All());

            modelViewFactoryStub.Verify(x => x.CreateAllSchedulesViewModel(It.IsAny<ICollection<ScheduleViewModel>>()), Times.Once);

        }

        [Test]
        public void Edit_ShouldRenderDefaultViewWithCorrectViewModel()
        {
            var mapperStub = new Mock<IMapper>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();

            var sut = new ScheduleController(mapperStub.Object, weekScheduleServiceStub.Object, workoutInformationServiceStub.Object, dailyWorkoutServiceStub.Object, modelViewFactoryStub.Object);

            var id = new Guid();

            var weekScheduleDataModel = new WeekSchedule();
            weekScheduleDataModel.DailyWorkouts = new List<DailyWorkout>()
            {
                new DailyWorkout()
            };

            var dailyWorkoutViewModel = new DailyWorkoutViewModel();
            dailyWorkoutViewModel.Day = "monday";

            var scheduleViewModel = new EditScheduleViewModel();
            scheduleViewModel.AllWorkouts = new Dictionary<string, DailyWorkoutViewModel>();

            weekScheduleServiceStub.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(weekScheduleDataModel);
            mapperStub.Setup(x => x.Map<EditScheduleViewModel>(It.IsAny<WeekSchedule>())).Returns(scheduleViewModel);
            mapperStub.Setup(x => x.Map<DailyWorkoutViewModel>(It.IsAny<DailyWorkout>())).Returns(dailyWorkoutViewModel);

            sut
                .WithCallTo(c => c.Edit(id))
                .ShouldRenderDefaultView()
                .WithModel(scheduleViewModel);
        }

        [Test]
        public void Edit_ShouldCallWeekScheduleServiceGetByIdOnceWithPassedId()
        {
            var mapperStub = new Mock<IMapper>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();

            var sut = new ScheduleController(mapperStub.Object, weekScheduleServiceStub.Object, workoutInformationServiceStub.Object, dailyWorkoutServiceStub.Object, modelViewFactoryStub.Object);

            var id = new Guid();

            var weekScheduleDataModel = new WeekSchedule();
            weekScheduleDataModel.DailyWorkouts = new List<DailyWorkout>()
            {
                new DailyWorkout()
            };

            var dailyWorkoutViewModel = new DailyWorkoutViewModel();
            dailyWorkoutViewModel.Day = "monday";

            var scheduleViewModel = new EditScheduleViewModel();
            scheduleViewModel.AllWorkouts = new Dictionary<string, DailyWorkoutViewModel>();

            weekScheduleServiceStub.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(weekScheduleDataModel);
            mapperStub.Setup(x => x.Map<EditScheduleViewModel>(It.IsAny<WeekSchedule>())).Returns(scheduleViewModel);
            mapperStub.Setup(x => x.Map<DailyWorkoutViewModel>(It.IsAny<DailyWorkout>())).Returns(dailyWorkoutViewModel);

            sut
                .WithCallTo(c => c.Edit(id));

            weekScheduleServiceStub.Verify(x => x.GetById(id), Times.Once);
        }

        [Test]
        public void Edit_ShouldGetScheduleViewModelOnceFromMapperMyPassingScheduleDataModelFromWeekScheduleService()
        {
            var mapperStub = new Mock<IMapper>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();

            var sut = new ScheduleController(mapperStub.Object, weekScheduleServiceStub.Object, workoutInformationServiceStub.Object, dailyWorkoutServiceStub.Object, modelViewFactoryStub.Object);

            var id = new Guid();

            var weekScheduleDataModel = new WeekSchedule();
            weekScheduleDataModel.DailyWorkouts = new List<DailyWorkout>()
            {
                new DailyWorkout()
            };

            var dailyWorkoutViewModel = new DailyWorkoutViewModel();
            dailyWorkoutViewModel.Day = "monday";

            var scheduleViewModel = new EditScheduleViewModel();
            scheduleViewModel.AllWorkouts = new Dictionary<string, DailyWorkoutViewModel>();

            weekScheduleServiceStub.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(weekScheduleDataModel);
            mapperStub.Setup(x => x.Map<EditScheduleViewModel>(It.IsAny<WeekSchedule>())).Returns(scheduleViewModel);
            mapperStub.Setup(x => x.Map<DailyWorkoutViewModel>(It.IsAny<DailyWorkout>())).Returns(dailyWorkoutViewModel);

            sut
                .WithCallTo(c => c.Edit(id));

            mapperStub.Verify(x => x.Map<EditScheduleViewModel>(weekScheduleDataModel), Times.Once);
        }

        [Test]
        public void Edit_GetCallMapperToGetDailyWorkoutViewModelOnceWhenScheduleDataModelContainsOneWorkout()
        {
            var mapperStub = new Mock<IMapper>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();

            var sut = new ScheduleController(mapperStub.Object, weekScheduleServiceStub.Object, workoutInformationServiceStub.Object, dailyWorkoutServiceStub.Object, modelViewFactoryStub.Object);

            var id = new Guid();

            var weekScheduleDataModel = new WeekSchedule();
            weekScheduleDataModel.DailyWorkouts = new List<DailyWorkout>()
            {
                new DailyWorkout()
            };

            var dailyWorkoutViewModel = new DailyWorkoutViewModel();
            dailyWorkoutViewModel.Day = "monday";

            var scheduleViewModel = new EditScheduleViewModel();
            scheduleViewModel.AllWorkouts = new Dictionary<string, DailyWorkoutViewModel>();

            weekScheduleServiceStub.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(weekScheduleDataModel);
            mapperStub.Setup(x => x.Map<EditScheduleViewModel>(It.IsAny<WeekSchedule>())).Returns(scheduleViewModel);
            mapperStub.Setup(x => x.Map<DailyWorkoutViewModel>(It.IsAny<DailyWorkout>())).Returns(dailyWorkoutViewModel);

            sut
                .WithCallTo(c => c.Edit(id));

            mapperStub.Verify(x => x.Map<DailyWorkoutViewModel>(weekScheduleDataModel.DailyWorkouts.First()), Times.Once);
        }

        [Test]
        public void Edit_ShouldAddCorrectWoDDayAndDailyWorkoutViewModelToScheduleModel()
        {
            var mapperStub = new Mock<IMapper>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();

            var sut = new ScheduleController(mapperStub.Object, weekScheduleServiceStub.Object, workoutInformationServiceStub.Object, dailyWorkoutServiceStub.Object, modelViewFactoryStub.Object);

            var id = new Guid();

            var weekScheduleDataModel = new WeekSchedule();
            weekScheduleDataModel.DailyWorkouts = new List<DailyWorkout>()
            {
                new DailyWorkout()
            };

            var dailyWorkoutViewModel = new DailyWorkoutViewModel();
            dailyWorkoutViewModel.Day = "monday";

            var scheduleViewModel = new EditScheduleViewModel();
            scheduleViewModel.AllWorkouts = new Dictionary<string, DailyWorkoutViewModel>();

            weekScheduleServiceStub.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(weekScheduleDataModel);
            mapperStub.Setup(x => x.Map<EditScheduleViewModel>(It.IsAny<WeekSchedule>())).Returns(scheduleViewModel);
            mapperStub.Setup(x => x.Map<DailyWorkoutViewModel>(It.IsAny<DailyWorkout>())).Returns(dailyWorkoutViewModel);

            sut.WithCallTo(c => c.Edit(id));

            Assert.AreEqual("monday", scheduleViewModel.AllWorkouts.Keys.First());
            Assert.AreSame(dailyWorkoutViewModel, scheduleViewModel.AllWorkouts[dailyWorkoutViewModel.Day]);
        }

    }
}
