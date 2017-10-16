using Flash.Club13.Data.Repository;
using Flash.Club13.Data.UnitOfWork;
using Flash.Club13.Models;
using Flash.Club13.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash.Club13.UnitTests.Services
{
    [TestFixture]
    public class WorkoutInformationServiceTests
    {

        [Test]
        public void Constructor_ShouldThrowWhenInvalidWorkoutInformationRepoIsPassed()
        {
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentException>(() => new WorkoutInformationService(null, unitOfWorkStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenInvalidUnitOfWorkIsPassed()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();

            Assert.Throws<ArgumentException>(() => new WorkoutInformationService(workoutInformationRepoStub.Object, null));
        }

        [Test]
        public void Constructor_ShouldNotThrowWhenAllParametersAreValid()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            Assert.DoesNotThrow(() => new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object));
        }

        [Test]
        public void Constructor_ShouldCreateCorrectServiceWhenAllParametersAreValid()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            Assert.IsInstanceOf<WorkoutInformationService>(sut);
        }


        [Test]
        public void GetAll_ShouldCallWorkoutInformationRepoAllPropertyOnce()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var dbSetStub = new List<WorkoutInformation>().AsQueryable();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            workoutInformationRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetAll();

            workoutInformationRepoStub.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetAll_ShouldReturnAnICollectionOfWorkoutInformation()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var dbSetStub = new Mock<IList<WorkoutInformation>>().As<IQueryable<WorkoutInformation>>();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            workoutInformationRepoStub.Setup(x => x.All).Returns(dbSetStub.Object);

            var result = sut.GetAll();

            Assert.IsInstanceOf(typeof(ICollection<WorkoutInformation>), result);
        }

        [Test]
        public void GetAllNames_ShouldCallWorkoutInformationRepoAllPropertyOnce()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var dbSetStub = new List<WorkoutInformation>().AsQueryable();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            workoutInformationRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetAllNames();

            workoutInformationRepoStub.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetAllNames_ShouldReturnICollectionOfStrings()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<WorkoutInformation>();
            var workout = new WorkoutInformation();
            workout.Name = "murph";
            list.Add(workout);

            var dbSetStub = list.AsQueryable();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            workoutInformationRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetAllNames();

            Assert.IsInstanceOf(typeof(ICollection<string>), result);
        }

        [Test]
        public void GetAllNames_ShouldReturnICollectionOfTwoStringsWhenTwoExercisesArePresentInTheRepo()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<WorkoutInformation>();
            var workoutOne = new WorkoutInformation();
            workoutOne.Name = "gosho";
            var workoutTwo = new WorkoutInformation
            {
                Name = "pesho"
            };
            list.Add(workoutOne);
            list.Add(workoutTwo);

            var dbSetStub = list.AsQueryable();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            workoutInformationRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetAllNames();

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetByName_ShouldThrowWhenInvalidNameIsPassed()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            Assert.Throws<ArgumentException>(() => sut.GetByName(null));
        }

        [Test]
        public void GetByName_ShouldReturnNullWhenNameIsNotFound()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<WorkoutInformation>();
            var workoutOne = new WorkoutInformation();
            workoutOne.Name = "gosho";
            var workoutTwo = new WorkoutInformation
            {
                Name = "pesho"
            };
            list.Add(workoutOne);
            list.Add(workoutTwo);

            var dbSetStub = list.AsQueryable();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            workoutInformationRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetByName("stamat");

            Assert.IsNull(result);
        }

        [Test]
        public void GetByName_ShouldReturnCorrectWorkoutInformationWhenNameIsFound()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<WorkoutInformation>();
            var workoutOne = new WorkoutInformation();
            workoutOne.Name = "gosho";
            var workoutTwo = new WorkoutInformation
            {
                Name = "pesho"
            };
            list.Add(workoutOne);
            list.Add(workoutTwo);

            var dbSetStub = list.AsQueryable();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            workoutInformationRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetByName("gosho");

            Assert.AreSame(result, workoutOne);
        }


        [Test]
        public void Update_ShouldThrowWhenInvalidWorkoutInformationIsPassed()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            workoutInformationRepoStub.Setup(x => x.Update(It.IsAny<WorkoutInformation>()));
            unitOfWorkStub.Setup(x => x.Commit());

            Assert.Throws<ArgumentException>(() => sut.Update(null));
        }

        [Test]
        public void Update_ShouldCallRepoUpdateOnceWithCorrectWorkout()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            workoutInformationRepoStub.Setup(x => x.Update(It.IsAny<WorkoutInformation>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new WorkoutInformation();

            sut.Update(workout);

            workoutInformationRepoStub.Verify(x => x.Update(workout), Times.Once);
        }

        [Test]
        public void Update_ShouldCallUnitOfWorkCommitOnce()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            workoutInformationRepoStub.Setup(x => x.Update(It.IsAny<WorkoutInformation>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new WorkoutInformation();

            sut.Update(workout);

            unitOfWorkStub.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void AddWorkoutInformation_ShouldThrowWhenInvalidWorkoutInformationIsPassed()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            workoutInformationRepoStub.Setup(x => x.Add(It.IsAny<WorkoutInformation>()));
            unitOfWorkStub.Setup(x => x.Commit());

            Assert.Throws<ArgumentException>(() => sut.AddWorkoutInformation(null));
        }

        [Test]
        public void AddWorkoutInformation_ShouldCallRepoAddOnceWithCorrectWorkout()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            workoutInformationRepoStub.Setup(x => x.Add(It.IsAny<WorkoutInformation>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new WorkoutInformation();

            sut.AddWorkoutInformation(workout);

            workoutInformationRepoStub.Verify(x => x.Add(workout), Times.Once);
        }

        [Test]
        public void AddWorkoutInformation_ShouldCallUnitOfWorkCommitOnce()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            workoutInformationRepoStub.Setup(x => x.Update(It.IsAny<WorkoutInformation>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new WorkoutInformation();

            sut.AddWorkoutInformation(workout);

            unitOfWorkStub.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void InsertMultipleExercisesToWorkoutInformation_ShouldThrowWhenPassedWorkoutInformationAndExercisesAreInvalid()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            workoutInformationRepoStub.Setup(x => x.Update(It.IsAny<WorkoutInformation>()));
            unitOfWorkStub.Setup(x => x.Commit());

            Assert.Throws<ArgumentException>(() => sut.InsertMultipleExercisesToWorkoutInformation(null, null));
        }

        [Test]
        public void InsertMultipleExercisesToWorkoutInformation_ShouldThrowWhenPassedWorkoutInformationIsInvalid()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            workoutInformationRepoStub.Setup(x => x.Update(It.IsAny<WorkoutInformation>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var exercises = new List<Exercise>();

            Assert.Throws<ArgumentException>(() => sut.InsertMultipleExercisesToWorkoutInformation(null, exercises));
        }

        [Test]
        public void InsertMultipleExercisesToWorkoutInformation_ShouldThrowWhenPassedExercisesAreInvalid()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            workoutInformationRepoStub.Setup(x => x.Update(It.IsAny<WorkoutInformation>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new WorkoutInformation();

            Assert.Throws<ArgumentException>(() => sut.InsertMultipleExercisesToWorkoutInformation(workout, null));
        }

        [Test]
        public void InsertMultipleExercisesToWorkoutInformation_ShouldInsertTwoExercisesInTheWorkoutWhenTheExercisesCollectionHasTwoElements()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            workoutInformationRepoStub.Setup(x => x.Update(It.IsAny<WorkoutInformation>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new WorkoutInformation();
            var exercises = new List<Exercise>();
            var exerciseOne = new Exercise();
            var exerciseTwo = new Exercise();

            exercises.Add(exerciseOne);
            exercises.Add(exerciseTwo);

            sut.InsertMultipleExercisesToWorkoutInformation(workout, exercises);

            Assert.AreEqual(2, workout.Exercises.Count);
        }

        [Test]
        public void InsertMultipleExercisesToWorkoutInformation_CallUpdateOnTHeRepo()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            workoutInformationRepoStub.Setup(x => x.Update(It.IsAny<WorkoutInformation>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new WorkoutInformation();
            var exercises = new List<Exercise>();
            var exerciseOne = new Exercise();
            var exerciseTwo = new Exercise();

            exercises.Add(exerciseOne);
            exercises.Add(exerciseTwo);

            sut.InsertMultipleExercisesToWorkoutInformation(workout, exercises);

            workoutInformationRepoStub.Verify(x => x.Update(It.IsAny<WorkoutInformation>()), Times.Once);
        }

        [Test]
        public void InsertMultipleExercisesToWorkoutInformation_CallCommitOnTheUnitOfWork()
        {
            var workoutInformationRepoStub = new Mock<IEfRepostory<WorkoutInformation>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new WorkoutInformationService(workoutInformationRepoStub.Object, unitOfWorkStub.Object);

            workoutInformationRepoStub.Setup(x => x.Update(It.IsAny<WorkoutInformation>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new WorkoutInformation();
            var exercises = new List<Exercise>();
            var exerciseOne = new Exercise();
            var exerciseTwo = new Exercise();

            exercises.Add(exerciseOne);
            exercises.Add(exerciseTwo);

            sut.InsertMultipleExercisesToWorkoutInformation(workout, exercises);

            unitOfWorkStub.Verify(x => x.Commit(), Times.Once);
        }
    }
}
