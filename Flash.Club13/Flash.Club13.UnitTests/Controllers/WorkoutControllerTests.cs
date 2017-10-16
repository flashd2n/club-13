using AutoMapper;
using Flash.Club13.Interfaces.Providers;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Models;
using Flash.Club13.Models.Enums;
using Flash.Club13.Web.Controllers;
using Flash.Club13.Web.Infrastructure.Factories;
using Flash.Club13.Web.Infrastructure.Providers;
using Flash.Club13.Web.Models.Home;
using Flash.Club13.Web.Models.Workout;
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
    public class WorkoutControllerTests
    {
        [Test]
        public void Constructor_ShouldCreateCorrectInstanceWhenAllParametersAreValid()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            Assert.IsInstanceOf<WorkoutController>(sut);
        }

        [Test]
        public void Constructor_ShouldThrowWhenInvalidMapper()
        {
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();
            
            Assert.Throws<ArgumentException>(() => new WorkoutController(null,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenWorkoutInformtionServiceIsInvalid()
        {
            var mapperStub = new Mock<IMapper>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();
            
            Assert.Throws<ArgumentException>(() => new WorkoutController(mapperStub.Object,
                null,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenWeekScheduleServiceIsInvalid()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();
            
            Assert.Throws<ArgumentException>(() => new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                null,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenDateTimeProviderIsInvalid()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();
            
            Assert.Throws<ArgumentException>(() => new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                null,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenDailyWorkoutServiceIsInvalid()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();
            
            Assert.Throws<ArgumentException>(() => new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                null,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenMemberIdProviderIsInvalid()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();
            
            Assert.Throws<ArgumentException>(() => new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                null,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenMemberServiceIsInvalid()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();
            
            Assert.Throws<ArgumentException>(() => new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                null,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenWorkoutServiceIsInvalid()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();
            
            Assert.Throws<ArgumentException>(() => new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                null,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldModelViewFactoryIsInvalid()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();
            
            Assert.Throws<ArgumentException>(() => new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                null,
                dataModelFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenDataModelFactoryIsInvalid()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            
            Assert.Throws<ArgumentException>(() => new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                null));
        }

        [Test]
        public void GetWorkOutOfTheDay_ShouldRenderCorrectPartialViewWithNoModelWhenWhenThereIsNoCurrentWeekSchedule()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            WeekSchedule currentSchedule = null;

            weekScheduleServiceStub.Setup(x => x.GetCurrentSchedule()).Returns(currentSchedule);

            sut
                .WithCallTo(c => c.GetWorkOutOfTheDay())
                .ShouldRenderPartialView("_WoDPartial");
        }

        [Test]
        public void GetWorkOutOfTheDay_ShouldRenderCorrectPartialViewWithNoModelWhenWhenThereIsNoCurrentWorkout()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            var currentSchedule = new WeekSchedule();
            currentSchedule.DailyWorkouts = new List<DailyWorkout>()
            {
                new DailyWorkout
                {
                    Day = "Tuesday"
                }
            };

            weekScheduleServiceStub.Setup(x => x.GetCurrentSchedule()).Returns(currentSchedule);
            datetimeProviderStub.Setup(x => x.GetCurrentDayOfWeek()).Returns(DayOfWeek.Monday);

            sut
                .WithCallTo(c => c.GetWorkOutOfTheDay())
                .ShouldRenderPartialView("_WoDPartial");
        }

        [Test]
        public void GetWorkOutOfTheDay_ShouldRenderCorrectPartialViewWithCurrectModelWhenThereIsACurrentWorkout()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            var currentSchedule = new WeekSchedule();
            currentSchedule.DailyWorkouts = new List<DailyWorkout>()
            {
                new DailyWorkout
                {
                    Day = "Monday",
                    WorkoutInformation = new WorkoutInformation()
                }
            };
            var bestTime = new TimeSpan(0, 15, 0);
            var model = new WoDViewModel();

            weekScheduleServiceStub.Setup(x => x.GetCurrentSchedule()).Returns(currentSchedule);
            datetimeProviderStub.Setup(x => x.GetCurrentDayOfWeek()).Returns(DayOfWeek.Monday);
            workoutServiceStub.Setup(x => x.GetBestTimeDaily(It.IsAny<DailyWorkout>())).Returns(bestTime);
            mapperStub.Setup(x => x.Map<WoDViewModel>(It.IsAny<WorkoutInformation>())).Returns(model);


            sut
                .WithCallTo(c => c.GetWorkOutOfTheDay())
                .ShouldRenderPartialView("_WoDPartial")
                .WithModel(model);
        }

        [Test]
        public void GetWorkOutOfTheDay_ShouldCallWeekScheduleGetCurrentScheduleOncetoGetTheCurrentWeekSchedule()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            var currentSchedule = new WeekSchedule();
            currentSchedule.DailyWorkouts = new List<DailyWorkout>()
            {
                new DailyWorkout
                {
                    Day = "Monday",
                    WorkoutInformation = new WorkoutInformation()
                }
            };
            var bestTime = new TimeSpan(0, 15, 0);
            var model = new WoDViewModel();

            weekScheduleServiceStub.Setup(x => x.GetCurrentSchedule()).Returns(currentSchedule);
            datetimeProviderStub.Setup(x => x.GetCurrentDayOfWeek()).Returns(DayOfWeek.Monday);
            workoutServiceStub.Setup(x => x.GetBestTimeDaily(It.IsAny<DailyWorkout>())).Returns(bestTime);
            mapperStub.Setup(x => x.Map<WoDViewModel>(It.IsAny<WorkoutInformation>())).Returns(model);


            sut
                .WithCallTo(c => c.GetWorkOutOfTheDay());

            weekScheduleServiceStub.Verify(x => x.GetCurrentSchedule(), Times.Once);
        }

        [Test]
        public void GetWorkOutOfTheDay_ShouldCallDateTimeProviderGetCurrentdayOnceToGetCurrentDayOfWeek()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            var currentSchedule = new WeekSchedule();
            currentSchedule.DailyWorkouts = new List<DailyWorkout>()
            {
                new DailyWorkout
                {
                    Day = "Monday",
                    WorkoutInformation = new WorkoutInformation()
                }
            };
            var bestTime = new TimeSpan(0, 15, 0);
            var model = new WoDViewModel();

            weekScheduleServiceStub.Setup(x => x.GetCurrentSchedule()).Returns(currentSchedule);
            datetimeProviderStub.Setup(x => x.GetCurrentDayOfWeek()).Returns(DayOfWeek.Monday);
            workoutServiceStub.Setup(x => x.GetBestTimeDaily(It.IsAny<DailyWorkout>())).Returns(bestTime);
            mapperStub.Setup(x => x.Map<WoDViewModel>(It.IsAny<WorkoutInformation>())).Returns(model);


            sut
                .WithCallTo(c => c.GetWorkOutOfTheDay());

            datetimeProviderStub.Verify(x => x.GetCurrentDayOfWeek(), Times.Once);
        }

        [Test]
        public void GetWorkOutOfTheDay_ShouldCallWorkoutServiceGetBestTimeDailyOnceWithCorrectCurrentWorkout()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            var currentSchedule = new WeekSchedule();
            currentSchedule.DailyWorkouts = new List<DailyWorkout>()
            {
                new DailyWorkout
                {
                    Day = "Monday",
                    WorkoutInformation = new WorkoutInformation()
                }
            };
            var bestTime = new TimeSpan(0, 15, 0);
            var model = new WoDViewModel();

            weekScheduleServiceStub.Setup(x => x.GetCurrentSchedule()).Returns(currentSchedule);
            datetimeProviderStub.Setup(x => x.GetCurrentDayOfWeek()).Returns(DayOfWeek.Monday);
            workoutServiceStub.Setup(x => x.GetBestTimeDaily(It.IsAny<DailyWorkout>())).Returns(bestTime);
            mapperStub.Setup(x => x.Map<WoDViewModel>(It.IsAny<WorkoutInformation>())).Returns(model);


            sut
                .WithCallTo(c => c.GetWorkOutOfTheDay());

            workoutServiceStub.Verify(x => x.GetBestTimeDaily(currentSchedule.DailyWorkouts.First()), Times.Once);
        }

        [Test]
        public void GetWorkOutOfTheDay_ShouldCallMapperOnceWithCorrectWorkoutDetails()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            var currentSchedule = new WeekSchedule();
            currentSchedule.DailyWorkouts = new List<DailyWorkout>()
            {
                new DailyWorkout
                {
                    Day = "Monday",
                    WorkoutInformation = new WorkoutInformation()
                }
            };
            var bestTime = new TimeSpan(0, 15, 0);
            var model = new WoDViewModel();

            weekScheduleServiceStub.Setup(x => x.GetCurrentSchedule()).Returns(currentSchedule);
            datetimeProviderStub.Setup(x => x.GetCurrentDayOfWeek()).Returns(DayOfWeek.Monday);
            workoutServiceStub.Setup(x => x.GetBestTimeDaily(It.IsAny<DailyWorkout>())).Returns(bestTime);
            mapperStub.Setup(x => x.Map<WoDViewModel>(It.IsAny<WorkoutInformation>())).Returns(model);


            sut
                .WithCallTo(c => c.GetWorkOutOfTheDay());

            mapperStub.Verify(x => x.Map<WoDViewModel>(currentSchedule.DailyWorkouts.First().WorkoutInformation), Times.Once);
        }

        [Test]
        public void GetWorkOutOfTheDay_ShouldShouldAssignBestimeToViewModelProperty()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            var currentSchedule = new WeekSchedule();
            currentSchedule.DailyWorkouts = new List<DailyWorkout>()
            {
                new DailyWorkout
                {
                    Day = "Monday",
                    WorkoutInformation = new WorkoutInformation()
                }
            };
            var bestTime = new TimeSpan(0, 15, 0);
            var model = new WoDViewModel();

            weekScheduleServiceStub.Setup(x => x.GetCurrentSchedule()).Returns(currentSchedule);
            datetimeProviderStub.Setup(x => x.GetCurrentDayOfWeek()).Returns(DayOfWeek.Monday);
            workoutServiceStub.Setup(x => x.GetBestTimeDaily(It.IsAny<DailyWorkout>())).Returns(bestTime);
            mapperStub.Setup(x => x.Map<WoDViewModel>(It.IsAny<WorkoutInformation>())).Returns(model);


            sut
                .WithCallTo(c => c.GetWorkOutOfTheDay());

            Assert.AreEqual(bestTime, model.BestTime);
        }

        [Test]
        public void SignUpForWorkout_ShouldRenderCorrectParialViewWithNoModelWhenNoCurrentWeekScheduleIsFound()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            WeekSchedule currentSchedule = null;

            weekScheduleServiceStub.Setup(x => x.GetCurrentSchedule()).Returns(currentSchedule);

            sut
                .WithCallTo(c => c.SignUpForWorkout())
                .ShouldRenderPartialView("_HomeWoDSignUp");
        }

        [Test]
        public void SignUpForWorkout_ShouldRenderCorrectPartialViewWithNoModelWhenNoWorkoutForTheDay()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            var currentSchedule = new WeekSchedule();
            currentSchedule.DailyWorkouts = new List<DailyWorkout>()
            {
                new DailyWorkout
                {
                    Day = "Tuesday",
                }
            };

            weekScheduleServiceStub.Setup(x => x.GetCurrentSchedule()).Returns(currentSchedule);
            datetimeProviderStub.Setup(x => x.GetCurrentDayOfWeek()).Returns(DayOfWeek.Monday);


            sut
                .WithCallTo(c => c.SignUpForWorkout())
                .ShouldRenderPartialView("_HomeWoDSignUp");            
        }

        [Test]
        public void SignUpForWorkout_ShouldRenderCorrectPartialViewWithCorrectModelWhenThereIsDailyWorkout()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            var id = new Guid();

            var loggedMember = new Member();
            loggedMember.Id = id;

            var currentSchedule = new WeekSchedule();
            currentSchedule.DailyWorkouts = new List<DailyWorkout>()
            {
                new DailyWorkout
                {
                    Day = "Monday",
                    SignedMembers = new List<Member>()
                    {
                        new Member
                        {
                            Id = id
                        }
                    }
                }
            };
            var userId = "peshothemonster";
            
            var model = new SignUpWoDViewModel();
            var wodModel = new HomeDailyWoDViewModel();

            weekScheduleServiceStub.Setup(x => x.GetCurrentSchedule()).Returns(currentSchedule);
            datetimeProviderStub.Setup(x => x.GetCurrentDayOfWeek()).Returns(DayOfWeek.Monday);
            memberIdProviderStub.Setup(x => x.GetLoggeedUserId()).Returns(userId);
            memberServiceStub.Setup(x => x.GetByUserId(It.IsAny<string>())).Returns(loggedMember);
            modelViewFactoryStub.Setup(x => x.CreateSignUpWoDViewModel()).Returns(model);
            mapperStub.Setup(x => x.Map<HomeDailyWoDViewModel>(It.IsAny<DailyWorkout>())).Returns(wodModel);

            sut
                .WithCallTo(c => c.SignUpForWorkout())
                .ShouldRenderPartialView("_HomeWoDSignUp")
                .WithModel(model);
        }

        [Test]
        public void SignUpForWorkout_ShouldReturnCorrectJsonResult()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            var SelectedWoDId = new Guid();
            var dailyWoD = new DailyWorkout();
            dailyWoD.StartTime = TimeOfDay.Morning;

            var userId = "goshothemonster";

            var loggedMember = new Member();
            var pending = new PendingWorkout();

            dailyWorkoutServiceStub.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(dailyWoD);
            memberIdProviderStub.Setup(x => x.GetLoggeedUserId()).Returns(userId);
            memberServiceStub.Setup(x => x.GetByUserId(It.IsAny<string>())).Returns(loggedMember);
            memberServiceStub.Setup(x => x.AddPending(It.IsAny<Member>(), It.IsAny<PendingWorkout>()));
            dailyWorkoutServiceStub.Setup(x => x.AddMemberToDailyWorkout(It.IsAny<Member>(), It.IsAny<DailyWorkout>()));
            dataModelFactoryStub.Setup(x => x.CreatePendingWorkout()).Returns(pending);

            sut
                .WithCallTo(c => c.SignUpForWorkout(SelectedWoDId))
                .ShouldReturnJson();
        }

        [Test]
        public void SignUpForWorkout_ShouldAddThePendingWorkoutToTheLoggedMemberCollection()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            var SelectedWoDId = new Guid();
            var dailyWoD = new DailyWorkout();
            dailyWoD.StartTime = TimeOfDay.Morning;

            var userId = "goshothemonster";

            var loggedMember = new Member();
            var pending = new PendingWorkout();

            dailyWorkoutServiceStub.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(dailyWoD);
            memberIdProviderStub.Setup(x => x.GetLoggeedUserId()).Returns(userId);
            memberServiceStub.Setup(x => x.GetByUserId(It.IsAny<string>())).Returns(loggedMember);
            memberServiceStub.Setup(x => x.AddPending(It.IsAny<Member>(), It.IsAny<PendingWorkout>()));
            dailyWorkoutServiceStub.Setup(x => x.AddMemberToDailyWorkout(It.IsAny<Member>(), It.IsAny<DailyWorkout>()));
            dataModelFactoryStub.Setup(x => x.CreatePendingWorkout()).Returns(pending);

            sut
                .WithCallTo(c => c.SignUpForWorkout(SelectedWoDId));

            memberServiceStub.Verify(x => x.AddPending(loggedMember, pending), Times.Once);
        }

        [Test]
        public void GetWorkoutNames_ShouldReturnCorrectJson()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            var allNames = new List<string>()
            {
                "pesho"
            };

            workoutInformationServiceStub.Setup(x => x.GetAllNames()).Returns(allNames);

            sut
                .WithCallTo(c => c.GetWorkoutNames())
                .ShouldReturnJson();
        }

        [Test]
        public void AllWorkouts_ShouldRenderDefaultViewModelWithCorrectModel()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dailyWorkoutServiceStub = new Mock<IDailyWorkoutService>();
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new WorkoutController(mapperStub.Object,
                workoutInformationServiceStub.Object,
                weekScheduleServiceStub.Object,
                datetimeProviderStub.Object,
                dailyWorkoutServiceStub.Object,
                memberIdProviderStub.Object,
                memberServiceStub.Object,
                workoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            var allWorkouts = new List<WorkoutInformation>()
            {
                new WorkoutInformation()
            };

            var model = new AllWorkoutsViewModel();
            var bestTime = new TimeSpan(0, 15, 0);
            var wodViewModel = new WoDViewModel();

            workoutInformationServiceStub.Setup(x => x.GetAll()).Returns(allWorkouts);
            modelViewFactoryStub.Setup(x => x.CreateAllWorkoutsViewModel()).Returns(model);
            workoutServiceStub.Setup(x => x.GetBestTime(It.IsAny<WorkoutInformation>())).Returns(bestTime);
            mapperStub.Setup(x => x.Map<WoDViewModel>(It.IsAny<WorkoutInformation>())).Returns(wodViewModel);

            sut
                .WithCallTo(c => c.AllWorkouts())
                .ShouldRenderDefaultView()
                .WithModel(model);
        }
    }
}
