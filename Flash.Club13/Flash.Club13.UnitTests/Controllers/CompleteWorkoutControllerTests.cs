using AutoMapper;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Models;
using Flash.Club13.Web.Controllers;
using Flash.Club13.Web.Infrastructure.Factories;
using Flash.Club13.Web.Infrastructure.Providers;
using Flash.Club13.Web.Models.CompleteWorkout;
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
    public class CompleteWorkoutControllerTests
    {
        [Test]
        public void Constructor_ShouldCreateCorrectInstanceWhenAllParametersAreValid()
        {
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var mapperStub = new Mock<IMapper>();
            var pendingWorkoutServiceStub = new Mock<IPendingWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new CompleteWorkoutController(memberIdProviderStub.Object,
                memberServiceStub.Object,
                mapperStub.Object,
                pendingWorkoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            Assert.IsInstanceOf<CompleteWorkoutController>(sut);
        }

        [Test]
        public void Constructor_ShouldThrowWhenMemberIdProviderIsInvalid()
        {
            var memberServiceStub = new Mock<IMemberService>();
            var mapperStub = new Mock<IMapper>();
            var pendingWorkoutServiceStub = new Mock<IPendingWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();
            
            Assert.Throws<ArgumentException>(() => new CompleteWorkoutController(null,
                memberServiceStub.Object,
                mapperStub.Object,
                pendingWorkoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenMemberServiceIsInvalid()
        {
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var mapperStub = new Mock<IMapper>();
            var pendingWorkoutServiceStub = new Mock<IPendingWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();
            
            Assert.Throws<ArgumentException>(() => new CompleteWorkoutController(memberIdProviderStub.Object,
                null,
                mapperStub.Object,
                pendingWorkoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenMapperIsInvalid()
        {
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var pendingWorkoutServiceStub = new Mock<IPendingWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();
            
            Assert.Throws<ArgumentException>(() => new CompleteWorkoutController(memberIdProviderStub.Object,
                memberServiceStub.Object,
                null,
                pendingWorkoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenPendingWorkoutServiceIsInvalid()
        {
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var mapperStub = new Mock<IMapper>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            Assert.Throws<ArgumentException>(() => new CompleteWorkoutController(memberIdProviderStub.Object,
                memberServiceStub.Object,
                mapperStub.Object,
                null,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenModelViewFactoryIsInvalid()
        {
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var mapperStub = new Mock<IMapper>();
            var pendingWorkoutServiceStub = new Mock<IPendingWorkoutService>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();
            
            Assert.Throws<ArgumentException>(() => new CompleteWorkoutController(memberIdProviderStub.Object,
                memberServiceStub.Object,
                mapperStub.Object,
                pendingWorkoutServiceStub.Object,
                null,
                dataModelFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenDataModelFactoryIsNull()
        {
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var mapperStub = new Mock<IMapper>();
            var pendingWorkoutServiceStub = new Mock<IPendingWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            Assert.Throws<ArgumentException>(() => new CompleteWorkoutController(memberIdProviderStub.Object,
                memberServiceStub.Object,
                mapperStub.Object,
                pendingWorkoutServiceStub.Object,
                modelViewFactoryStub.Object,
                null));
        }

        [Test]
        public void All_ShouldRenderDefaultViewWithCorrectModel()
        {
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var mapperStub = new Mock<IMapper>();
            var pendingWorkoutServiceStub = new Mock<IPendingWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new CompleteWorkoutController(memberIdProviderStub.Object,
                memberServiceStub.Object,
                mapperStub.Object,
                pendingWorkoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            var userId = "goshotheaweome";
            var loggedMember = new Member();
            loggedMember.PendingWorkouts = new List<PendingWorkout>()
            {
                new PendingWorkout
                {
                    IsCompleted = false
                }
            };
            var model = new AllPendingViewModel();
            var pendingViewModel = new AllPendingSingleWorkoutViewModel();

            memberIdProviderStub.Setup(x => x.GetLoggeedUserId()).Returns(userId);
            memberServiceStub.Setup(x => x.GetByUserId(It.IsAny<string>())).Returns(loggedMember);
            modelViewFactoryStub.Setup(s => s.CreateAllPendingViewModel()).Returns(model);
            mapperStub.Setup(x => x.Map<AllPendingSingleWorkoutViewModel>(It.IsAny<PendingWorkout>())).Returns(pendingViewModel);

            sut
                .WithCallTo(c => c.All())
                .ShouldRenderDefaultView()
                .WithModel(model);
        }

        [Test]
        public void Complete_ShouldRenderDefaultViewWithModelIdWhenModelIsNotValid()
        {
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var mapperStub = new Mock<IMapper>();
            var pendingWorkoutServiceStub = new Mock<IPendingWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new CompleteWorkoutController(memberIdProviderStub.Object,
                memberServiceStub.Object,
                mapperStub.Object,
                pendingWorkoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            var model = new CompleteViewModel();
            model.Id = new Guid();

            sut
                .WithModelErrors()
                .WithCallTo(c => c.Complete(model))
                .ShouldRenderDefaultView();
        }

        [Test]
        public void Complete_ShouldRedirectToCorrectActionWhenModelIsValid()
        {
            var memberIdProviderStub = new Mock<IMemberIdProvider>();
            var memberServiceStub = new Mock<IMemberService>();
            var mapperStub = new Mock<IMapper>();
            var pendingWorkoutServiceStub = new Mock<IPendingWorkoutService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            var dataModelFactoryStub = new Mock<IDataModelFactory>();

            var sut = new CompleteWorkoutController(memberIdProviderStub.Object,
                memberServiceStub.Object,
                mapperStub.Object,
                pendingWorkoutServiceStub.Object,
                modelViewFactoryStub.Object,
                dataModelFactoryStub.Object);

            var model = new CompleteViewModel();
            model.Id = new Guid();
            model.Minutes = 15;
            model.Seconds = 10;
            var pending = new PendingWorkout();
            pending.Member = new Member();
            pending.DailyWorkout = new DailyWorkout
            {
                WorkoutInformation = new WorkoutInformation()
            };

            var workout = new Workout();

            pendingWorkoutServiceStub.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(pending);
            pendingWorkoutServiceStub.Setup(x => x.MarkPendingAsCompleted(It.IsAny<PendingWorkout>()));
            dataModelFactoryStub.Setup(x => x.CreateWorkout()).Returns(workout);
            memberServiceStub.Setup(x => x.AddWorkout(It.IsAny<Member>(), It.IsAny<Workout>()));


            sut
                .WithCallTo(c => c.Complete(model))
                .ShouldRedirectTo(c => c.All());
        }

    }
}
