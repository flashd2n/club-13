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
    public class WorkoutServiceTests
    {
        [Test]
        public void Constructor_ShouldThrowWhenInvalidWorkoutsRepoIsPassed()
        {
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentException>(() => new WorkoutService(null, unitOfWorkStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenInvalidUnitOfWorkIsPassed()
        {
            var exercisesRepoStub = new Mock<IEfRepostory<Workout>>();

            Assert.Throws<ArgumentException>(() => new WorkoutService(exercisesRepoStub.Object, null));
        }

        [Test]
        public void Constructor_ShouldNotThrowWhenAllParametersAreValid()
        {
            var workoutsRepoStub = new Mock<IEfRepostory<Workout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            Assert.DoesNotThrow(() => new WorkoutService(workoutsRepoStub.Object, unitOfWorkStub.Object));
        }

        [Test]
        public void Constructor_ShouldCreateCorrectServiceWhenAllParametersAreValid()
        {
            var workoutsRepoStub = new Mock<IEfRepostory<Workout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new WorkoutService(workoutsRepoStub.Object, unitOfWorkStub.Object);

            Assert.IsInstanceOf<WorkoutService>(sut);
        }

        [Test]
        public void GetBestTimeDaily_ShouldThrowWhenInvalidDailyIsProvided()
        {
            var workoutsRepoStub = new Mock<IEfRepostory<Workout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new WorkoutService(workoutsRepoStub.Object, unitOfWorkStub.Object);

            Assert.Throws<ArgumentException>(() => sut.GetBestTimeDaily(null));
        }

        [Test]
        public void GetBestTimeDaily_ShouldReturnNullWhenWorkoutRepoIsEmpty()
        {
            var workoutsRepoStub = new Mock<IEfRepostory<Workout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<Workout>();

            var dbSetStub = list.AsQueryable();

            var daily = new DailyWorkout();

            var sut = new WorkoutService(workoutsRepoStub.Object, unitOfWorkStub.Object);

            workoutsRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetBestTimeDaily(daily);

            Assert.IsNull(result);
        }

        [Test]
        public void GetBestTimeDaily_ShouldReturnBestTimeWhenTwoWorkoutsArePresentInTheRepo()
        {
            var workoutsRepoStub = new Mock<IEfRepostory<Workout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<Workout>();
            var workoutOne = new Workout();
            workoutOne.WorkoutInformation = new WorkoutInformation
            {
                Name = "w1"
            };
            workoutOne.Time = new TimeSpan(0, 10, 0);

            var workoutTwo = new Workout();
            workoutTwo.WorkoutInformation = new WorkoutInformation
            {
                Name = "w1"
            };
            workoutTwo.Time = new TimeSpan(0, 20, 0);

            list.Add(workoutOne);
            list.Add(workoutTwo);
            var dbSetStub = list.AsQueryable();

            var daily = new DailyWorkout();
            daily.WorkoutInformation = new WorkoutInformation
            {
                Name = "w1"
            };

            var sut = new WorkoutService(workoutsRepoStub.Object, unitOfWorkStub.Object);

            workoutsRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetBestTimeDaily(daily);

            Assert.AreEqual(result, workoutOne.Time);
        }




        [Test]
        public void GetBestTime_ShouldThrowWhenInvalidDailyIsProvided()
        {
            var workoutsRepoStub = new Mock<IEfRepostory<Workout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new WorkoutService(workoutsRepoStub.Object, unitOfWorkStub.Object);

            Assert.Throws<ArgumentException>(() => sut.GetBestTime(null));
        }

        [Test]
        public void GetBestTime_ShouldReturnNullWhenWorkoutRepoIsEmpty()
        {
            var workoutsRepoStub = new Mock<IEfRepostory<Workout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<Workout>();

            var dbSetStub = list.AsQueryable();

            var daily = new WorkoutInformation();

            var sut = new WorkoutService(workoutsRepoStub.Object, unitOfWorkStub.Object);

            workoutsRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetBestTime(daily);

            Assert.IsNull(result);
        }

        [Test]
        public void GetBestTime_ShouldReturnBestTimeWhenTwoWorkoutsArePresentInTheRepo()
        {
            var workoutsRepoStub = new Mock<IEfRepostory<Workout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<Workout>();
            var workoutOne = new Workout();
            workoutOne.WorkoutInformation = new WorkoutInformation
            {
                Name = "w1"
            };
            workoutOne.Time = new TimeSpan(0, 10, 0);

            var workoutTwo = new Workout();
            workoutTwo.WorkoutInformation = new WorkoutInformation
            {
                Name = "w1"
            };
            workoutTwo.Time = new TimeSpan(0, 20, 0);

            list.Add(workoutOne);
            list.Add(workoutTwo);
            var dbSetStub = list.AsQueryable();

            var workoutQuery = new WorkoutInformation();
            workoutQuery.Name = "w1";

            var sut = new WorkoutService(workoutsRepoStub.Object, unitOfWorkStub.Object);

            workoutsRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetBestTime(workoutQuery);

            Assert.AreEqual(result, workoutOne.Time);
        }

        [Test]
        public void GetTotalWorkouts_ShouldReturnZeroWhenNoWorkoutsInTheRepo()
        {
            var workoutsRepoStub = new Mock<IEfRepostory<Workout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<Workout>();

            var dbSetStub = list.AsQueryable();

            var daily = new WorkoutInformation();

            var sut = new WorkoutService(workoutsRepoStub.Object, unitOfWorkStub.Object);

            workoutsRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetTotalWorkouts();

            Assert.AreEqual(0, result);
        }

        [Test]
        public void GetTotalWorkouts_ShouldReturnOneWhenOneWorkoutIsInTheRepo()
        {
            var workoutsRepoStub = new Mock<IEfRepostory<Workout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<Workout>();
            var workout = new Workout();
            list.Add(workout);

            var dbSetStub = list.AsQueryable();

            var daily = new WorkoutInformation();

            var sut = new WorkoutService(workoutsRepoStub.Object, unitOfWorkStub.Object);

            workoutsRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetTotalWorkouts();

            Assert.AreEqual(1, result);
        }

    }
}
