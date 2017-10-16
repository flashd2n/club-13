using Flash.Club13.Interfaces.Services;
using Flash.Club13.Web.Controllers;
using Flash.Club13.Web.Infrastructure.Factories;
using Flash.Club13.Web.Models.Home;
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
    public class HomeControllerTests
    {
        [Test]
        public void Constructor_ShouldCreateCorrectInstanceWhenAllParametersAreValid()
        {
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new HomeController(memberServiceStub.Object, workoutServiceStub.Object, modelViewFactoryStub.Object);

            Assert.IsInstanceOf<HomeController>(sut);
        }

        [Test]
        public void Constructor_ShouldThrowWhenMemberServiceIsInvalid()
        {
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            Assert.Throws<ArgumentException>(() => new HomeController(null, workoutServiceStub.Object, modelViewFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldWorkoutServiceIsInvalid()
        {
            var memberServiceStub = new Mock<IMemberService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();


            Assert.Throws<ArgumentException>(() => new HomeController(memberServiceStub.Object, null, modelViewFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenModelViewFacotryIsInvalid()
        {
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            
            Assert.Throws<ArgumentException>(() => new HomeController(memberServiceStub.Object, workoutServiceStub.Object, null));
        }

        [Test]
        public void Index_ShouldRenderDefaultView()
        {
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new HomeController(memberServiceStub.Object, workoutServiceStub.Object, modelViewFactoryStub.Object);

            sut
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();

        }

        [Test]
        public void TotalMembers_ShouldRenderCorrectPartialViewWithModel()
        {
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new HomeController(memberServiceStub.Object, workoutServiceStub.Object, modelViewFactoryStub.Object);

            var model = new TotalMembersViewModel();

            memberServiceStub.Setup(x => x.GetTotalMemberCount()).Returns(42);
            modelViewFactoryStub.Setup(x => x.CreateTotalMembersViewModel(It.IsAny<int>())).Returns(model);

            sut
                .WithCallTo(c => c.TotalMembers())
                .ShouldRenderPartialView("_TotalMembersPartial")
                .WithModel(model);
        }

        [Test]
        public void TotalMembers_ShouldCallMemberServiceGEtMemberCountOnce()
        {
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new HomeController(memberServiceStub.Object, workoutServiceStub.Object, modelViewFactoryStub.Object);

            var model = new TotalMembersViewModel();

            memberServiceStub.Setup(x => x.GetTotalMemberCount()).Returns(42);
            modelViewFactoryStub.Setup(x => x.CreateTotalMembersViewModel(It.IsAny<int>())).Returns(model);

            sut
                .WithCallTo(c => c.TotalMembers());

            memberServiceStub.Verify(x => x.GetTotalMemberCount(), Times.Once);
        }

        [Test]
        public void TotalMembers_ShouldCallMopdelViewFactoryCreateTotalMembersViewModelOnceWithCorrectParameter()
        {
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new HomeController(memberServiceStub.Object, workoutServiceStub.Object, modelViewFactoryStub.Object);

            var model = new TotalMembersViewModel();

            memberServiceStub.Setup(x => x.GetTotalMemberCount()).Returns(42);
            modelViewFactoryStub.Setup(x => x.CreateTotalMembersViewModel(It.IsAny<int>())).Returns(model);

            sut
                .WithCallTo(c => c.TotalMembers());

            modelViewFactoryStub.Verify(x => x.CreateTotalMembersViewModel(42), Times.Once);
        }


        [Test]
        public void TotalWorkouts_ShouldRenderCorrectPartialViewWithModel()
        {
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new HomeController(memberServiceStub.Object, workoutServiceStub.Object, modelViewFactoryStub.Object);

            var model = new TotalWorkoutsViewModel();

            workoutServiceStub.Setup(x => x.GetTotalWorkouts()).Returns(42);
            modelViewFactoryStub.Setup(x => x.CreateTotalWorkoutsViewModel(It.IsAny<int>())).Returns(model);

            sut
                .WithCallTo(c => c.TotalWorkouts())
                .ShouldRenderPartialView("_TotalWorkoutsPartial")
                .WithModel(model);
        }


        [Test]
        public void TotalWorkouts_ShouldCallWorkouotServiceGEtWorkoutCountOnce()
        {
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new HomeController(memberServiceStub.Object, workoutServiceStub.Object, modelViewFactoryStub.Object);

            var model = new TotalWorkoutsViewModel();

            workoutServiceStub.Setup(x => x.GetTotalWorkouts()).Returns(42);
            modelViewFactoryStub.Setup(x => x.CreateTotalWorkoutsViewModel(It.IsAny<int>())).Returns(model);

            sut
                .WithCallTo(c => c.TotalWorkouts());

            workoutServiceStub.Verify(x => x.GetTotalWorkouts(), Times.Once);
        }

        [Test]
        public void TotalWorkouts_ShouldCallMopdelViewFactoryCreateTotalWorkoutsViewModelOnceWithCorrectParameter()
        {
            var memberServiceStub = new Mock<IMemberService>();
            var workoutServiceStub = new Mock<IWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new HomeController(memberServiceStub.Object, workoutServiceStub.Object, modelViewFactoryStub.Object);

            var model = new TotalWorkoutsViewModel();

            workoutServiceStub.Setup(x => x.GetTotalWorkouts()).Returns(42);
            modelViewFactoryStub.Setup(x => x.CreateTotalWorkoutsViewModel(It.IsAny<int>())).Returns(model);

            sut
                .WithCallTo(c => c.TotalWorkouts());

            modelViewFactoryStub.Verify(x => x.CreateTotalWorkoutsViewModel(42), Times.Once);
        }

    }
}
