using AutoMapper;
using Flash.Club13.Interfaces.Services;
using Flash.Club13.Models;
using Flash.Club13.Web.Areas.Administration.Controllers;
using Flash.Club13.Web.Areas.Administration.Models;
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
    public class ManagerControllerTests
    {
        [Test]
        public void Constructor_ShouldCreateCorrectInstanceWhenAllParametersAreValid()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object);

            Assert.IsInstanceOf<ManagerController>(sut);
        }

        [Test]
        public void Constructor_ShouldThrowWhenMapperIsInvalid()
        {
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();
            
            Assert.Throws<ArgumentException>(() => new ManagerController(null, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenExerciseServiceIsInvalid()
        {
            var mapperStub = new Mock<IMapper>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            Assert.Throws<ArgumentException>(() => new ManagerController(mapperStub.Object, null, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object));
            
        }

        [Test]
        public void Constructor_ShouldThrowWhenWorkoutInformationServiceIsInvalid()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            Assert.Throws<ArgumentException>(() => new ManagerController(mapperStub.Object, exerciseServiceStub.Object, null, weekScheduleServiceStub.Object, modelViewFactoryStub.Object));
            
        }

        [Test]
        public void Constructor_ShouldThrowWhenWeekScheduleServiceIsInvalid()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            Assert.Throws<ArgumentException>(() => new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, null, modelViewFactoryStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenModelViewFactoryIsInvalid()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();

            Assert.Throws<ArgumentException>(() => new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, null));
        }

        [Test]
        public void Index_ShouldRenderDefaultView()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object);

            sut
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
            
        }

        [Test]
        public void CreateExercise_ShouldRenderDefaultView()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object);

            sut
                .WithCallTo(c => c.CreateExercise())
                .ShouldRenderDefaultView();
        }

        [Test]
        public void CreateExercisePost_ShouldRedirectToIndexActionWhenModelIsValid()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object);

            var exerciseViewModel = new CreateExerciseViewModel();

            var exerciseDataModel = new Exercise();

            mapperStub.Setup(x => x.Map<Exercise>(It.IsAny<CreateExerciseViewModel>())).Returns(exerciseDataModel);

            exerciseServiceStub.Setup(x => x.AddExercise(It.IsAny<Exercise>()));

            sut
                .WithCallTo(x => x.CreateExercise(exerciseViewModel))
                .ShouldRedirectTo(c => c.Index());
        }

        [Test]
        public void CreateExercisePost_ShouldRenderDefaultViewWhenModelIsNotValid()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object);

            var exerciseViewModel = new CreateExerciseViewModel();

            var exerciseDataModel = new Exercise();

            mapperStub.Setup(x => x.Map<Exercise>(It.IsAny<CreateExerciseViewModel>())).Returns(exerciseDataModel);

            exerciseServiceStub.Setup(x => x.AddExercise(It.IsAny<Exercise>()));

            sut
                .WithModelErrors()
                .WithCallTo(x => x.CreateExercise(exerciseViewModel))
                .ShouldRenderDefaultView();
        }

        [Test]
        public void CreateExercisePost_ShouldPassModeViewToMapper()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object);

            var exerciseViewModel = new CreateExerciseViewModel();

            var exerciseDataModel = new Exercise();

            mapperStub.Setup(x => x.Map<Exercise>(It.IsAny<CreateExerciseViewModel>())).Returns(exerciseDataModel);

            exerciseServiceStub.Setup(x => x.AddExercise(It.IsAny<Exercise>()));

            sut
                .WithCallTo(x => x.CreateExercise(exerciseViewModel));

            mapperStub.Verify(x => x.Map<Exercise>(exerciseViewModel), Times.Once);
        }

        [Test]
        public void CreateExercisePost_ShouldCallExerciseServiceCreateExerciseWithMappedModel()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object);

            var exerciseViewModel = new CreateExerciseViewModel();

            var exerciseDataModel = new Exercise();

            mapperStub.Setup(x => x.Map<Exercise>(It.IsAny<CreateExerciseViewModel>())).Returns(exerciseDataModel);

            exerciseServiceStub.Setup(x => x.AddExercise(It.IsAny<Exercise>()));

            sut
                .WithCallTo(x => x.CreateExercise(exerciseViewModel));

            exerciseServiceStub.Verify(x => x.AddExercise(exerciseDataModel), Times.Once);
        }

        [Test]
        public void CreateWorkout_ShouldRedirectToIndexWhenModelIsValid()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object);

            var workoutViewModel = new CreateWorkoutViewModel();
            workoutViewModel.AllExercises = new List<ExerciseMutipleSelectionViewModel>()
            {
                new ExerciseMutipleSelectionViewModel
                {
                    IsSelected = true,
                    Id = new Guid()
                }
            };

            var workoutDataModel = new WorkoutInformation();
            var exercise = new Exercise();

            mapperStub.Setup(x => x.Map<WorkoutInformation>(It.IsAny<CreateWorkoutViewModel>())).Returns(workoutDataModel);
            workoutInformationServiceStub.Setup(x => x.AddWorkoutInformation(It.IsAny<WorkoutInformation>()));
            exerciseServiceStub.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(exercise);
            workoutInformationServiceStub.Setup(x => x.InsertMultipleExercisesToWorkoutInformation(It.IsAny<WorkoutInformation>(), It.IsAny<ICollection<Exercise>>()));

            sut
                .WithCallTo(x => x.CreateWorkout(workoutViewModel))
                .ShouldRedirectTo(c => c.Index());

        }

        [Test]
        public void CreateWorkout_ShouldRedirectToCreateWorkoutGetWhenModelIsNotValid()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object);

            var workoutViewModel = new CreateWorkoutViewModel();
            workoutViewModel.AllExercises = new List<ExerciseMutipleSelectionViewModel>()
            {
                new ExerciseMutipleSelectionViewModel
                {
                    IsSelected = true,
                    Id = new Guid()
                }
            };

            var workoutDataModel = new WorkoutInformation();
            var exercise = new Exercise();

            mapperStub.Setup(x => x.Map<WorkoutInformation>(It.IsAny<CreateWorkoutViewModel>())).Returns(workoutDataModel);
            workoutInformationServiceStub.Setup(x => x.AddWorkoutInformation(It.IsAny<WorkoutInformation>()));
            exerciseServiceStub.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(exercise);
            workoutInformationServiceStub.Setup(x => x.InsertMultipleExercisesToWorkoutInformation(It.IsAny<WorkoutInformation>(), It.IsAny<ICollection<Exercise>>()));

            sut
                .WithModelErrors()
                .WithCallTo(x => x.CreateWorkout(workoutViewModel))
                .ShouldRedirectTo(c => c.CreateWorkout());
        }

        [Test]
        public void CreateWorkout_ShouldCallMapperWithViewModel()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object);

            var workoutViewModel = new CreateWorkoutViewModel();
            workoutViewModel.AllExercises = new List<ExerciseMutipleSelectionViewModel>()
            {
                new ExerciseMutipleSelectionViewModel
                {
                    IsSelected = true,
                    Id = new Guid()
                }
            };

            var workoutDataModel = new WorkoutInformation();
            var exercise = new Exercise();

            mapperStub.Setup(x => x.Map<WorkoutInformation>(It.IsAny<CreateWorkoutViewModel>())).Returns(workoutDataModel);
            workoutInformationServiceStub.Setup(x => x.AddWorkoutInformation(It.IsAny<WorkoutInformation>()));
            exerciseServiceStub.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(exercise);
            workoutInformationServiceStub.Setup(x => x.InsertMultipleExercisesToWorkoutInformation(It.IsAny<WorkoutInformation>(), It.IsAny<ICollection<Exercise>>()));

            sut
                .WithCallTo(x => x.CreateWorkout(workoutViewModel));

            mapperStub.Verify(x => x.Map<WorkoutInformation>(workoutViewModel), Times.Once);
        }

        [Test]
        public void CreateWorkout_ShouldCallAddWorkoutInformationWithDataModelFromMapper()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object);

            var workoutViewModel = new CreateWorkoutViewModel();
            workoutViewModel.AllExercises = new List<ExerciseMutipleSelectionViewModel>()
            {
                new ExerciseMutipleSelectionViewModel
                {
                    IsSelected = true,
                    Id = new Guid()
                }
            };

            var workoutDataModel = new WorkoutInformation();
            var exercise = new Exercise();

            mapperStub.Setup(x => x.Map<WorkoutInformation>(It.IsAny<CreateWorkoutViewModel>())).Returns(workoutDataModel);
            workoutInformationServiceStub.Setup(x => x.AddWorkoutInformation(It.IsAny<WorkoutInformation>()));
            exerciseServiceStub.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(exercise);
            workoutInformationServiceStub.Setup(x => x.InsertMultipleExercisesToWorkoutInformation(It.IsAny<WorkoutInformation>(), It.IsAny<ICollection<Exercise>>()));

            sut
                .WithCallTo(x => x.CreateWorkout(workoutViewModel));

            workoutInformationServiceStub.Verify(x => x.AddWorkoutInformation(workoutDataModel), Times.Once);
        }

        [Test]
        public void CreateWorkout_ShouldCallExerciseServiceGetByIdOnceWhenOnlyOneSelectedExercise()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object);

            var workoutViewModel = new CreateWorkoutViewModel();
            workoutViewModel.AllExercises = new List<ExerciseMutipleSelectionViewModel>()
            {
                new ExerciseMutipleSelectionViewModel
                {
                    IsSelected = true,
                    Id = new Guid()
                }
            };

            var workoutDataModel = new WorkoutInformation();
            var exercise = new Exercise();

            mapperStub.Setup(x => x.Map<WorkoutInformation>(It.IsAny<CreateWorkoutViewModel>())).Returns(workoutDataModel);
            workoutInformationServiceStub.Setup(x => x.AddWorkoutInformation(It.IsAny<WorkoutInformation>()));
            exerciseServiceStub.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(exercise);
            workoutInformationServiceStub.Setup(x => x.InsertMultipleExercisesToWorkoutInformation(It.IsAny<WorkoutInformation>(), It.IsAny<ICollection<Exercise>>()));

            sut
                .WithCallTo(x => x.CreateWorkout(workoutViewModel));

            exerciseServiceStub.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Once);
        }

        [Test]
        public void CreateWorkout_ShouldCallInsertIntoWorkoutInformationServiceCorrectDataModel()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object);

            var workoutViewModel = new CreateWorkoutViewModel();
            workoutViewModel.AllExercises = new List<ExerciseMutipleSelectionViewModel>()
            {
                new ExerciseMutipleSelectionViewModel
                {
                    IsSelected = true,
                    Id = new Guid()
                }
            };

            var workoutDataModel = new WorkoutInformation();
            var exercise = new Exercise();

            mapperStub.Setup(x => x.Map<WorkoutInformation>(It.IsAny<CreateWorkoutViewModel>())).Returns(workoutDataModel);
            workoutInformationServiceStub.Setup(x => x.AddWorkoutInformation(It.IsAny<WorkoutInformation>()));
            exerciseServiceStub.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(exercise);
            workoutInformationServiceStub.Setup(x => x.InsertMultipleExercisesToWorkoutInformation(It.IsAny<WorkoutInformation>(), It.IsAny<ICollection<Exercise>>()));

            sut
                .WithCallTo(x => x.CreateWorkout(workoutViewModel));

            workoutInformationServiceStub.Verify(x => x.InsertMultipleExercisesToWorkoutInformation(workoutDataModel, It.IsAny<ICollection<Exercise>>()), Times.Once);
        }

        [Test]
        public void CreateSchedule_ShouldRenderDefaultView()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object);

            sut
                .WithCallTo(c => c.CreateSchedule())
                .ShouldRenderDefaultView();
        }

        [Test]
        public void AllUsers_ShouldRenderAllUsersView()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object);

            sut
                .WithCallTo(c => c.AllUsers())
                .ShouldRenderView("AllUsers");
        }

        [Test]
        public void CreateSchedule_ShouldRedirectToScheduleControllerEditActionWhenModelIsValid()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object);

            var scheduleViewModel = new CreateWeekScheduleViewModel();
            var weekScheduleDataModel = new WeekSchedule();

            mapperStub.Setup(x => x.Map<WeekSchedule>(It.IsAny<CreateWeekScheduleViewModel>())).Returns(weekScheduleDataModel);
            weekScheduleServiceStub.Setup(x => x.AddWeekSchedule(It.IsAny<WeekSchedule>()));

            sut
                .WithCallTo(c => c.CreateSchedule(scheduleViewModel))
                .ShouldRedirectToRoute("");

        }

        [Test]
        public void CreateSchedule_ShouldRedirectCreateScheduleGetWhenModelIsInvalid()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object);

            var scheduleViewModel = new CreateWeekScheduleViewModel();
            var weekScheduleDataModel = new WeekSchedule();

            mapperStub.Setup(x => x.Map<WeekSchedule>(It.IsAny<CreateWeekScheduleViewModel>())).Returns(weekScheduleDataModel);
            weekScheduleServiceStub.Setup(x => x.AddWeekSchedule(It.IsAny<WeekSchedule>()));

            sut
                .WithModelErrors()
                .WithCallTo(c => c.CreateSchedule(scheduleViewModel))
                .ShouldRedirectTo(c => c.CreateSchedule());
        }

        [Test]
        public void CreateSchedule_CallMapperWithViewModel()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object);

            var scheduleViewModel = new CreateWeekScheduleViewModel();
            var weekScheduleDataModel = new WeekSchedule();

            mapperStub.Setup(x => x.Map<WeekSchedule>(It.IsAny<CreateWeekScheduleViewModel>())).Returns(weekScheduleDataModel);
            weekScheduleServiceStub.Setup(x => x.AddWeekSchedule(It.IsAny<WeekSchedule>()));

            sut
                .WithCallTo(c => c.CreateSchedule(scheduleViewModel));

            mapperStub.Verify(x => x.Map<WeekSchedule>(scheduleViewModel), Times.Once);
        }

        [Test]
        public void CreateSchedule_ShouldCallWeekScheduleAddWeekScheduleWithDataModelFromMapper()
        {
            var mapperStub = new Mock<IMapper>();
            var exerciseServiceStub = new Mock<IExerciseService>();
            var workoutInformationServiceStub = new Mock<IWorkoutInformationService>();
            var weekScheduleServiceStub = new Mock<IWeekScheduleService>();
            var modelViewFactoryStub = new Mock<IModelViewFactory>();

            var sut = new ManagerController(mapperStub.Object, exerciseServiceStub.Object, workoutInformationServiceStub.Object, weekScheduleServiceStub.Object, modelViewFactoryStub.Object);

            var scheduleViewModel = new CreateWeekScheduleViewModel();
            var weekScheduleDataModel = new WeekSchedule();

            mapperStub.Setup(x => x.Map<WeekSchedule>(It.IsAny<CreateWeekScheduleViewModel>())).Returns(weekScheduleDataModel);
            weekScheduleServiceStub.Setup(x => x.AddWeekSchedule(It.IsAny<WeekSchedule>()));

            sut
                .WithCallTo(c => c.CreateSchedule(scheduleViewModel));

            weekScheduleServiceStub.Verify(x => x.AddWeekSchedule(weekScheduleDataModel), Times.Once);
        }

    }
}
