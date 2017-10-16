using Flash.Club13.Data.Repository;
using Flash.Club13.Data.UnitOfWork;
using Flash.Club13.Models;
using Flash.Club13.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flash.Club13.UnitTests.Services
{
    [TestFixture]
    public class PendingWorkoutServiceTests
    {
        [Test]
        public void Constructor_ShouldThrowWhenInvalidPendingWorkoutRepoIsPassed()
        {
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentException>(() => new PendingWorkoutService(null, unitOfWorkStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenInvalidUnitOfWorkIsPassed()
        {
            var pendingWorkoutsStub = new Mock<IEfRepostory<PendingWorkout>>();

            Assert.Throws<ArgumentException>(() => new PendingWorkoutService(pendingWorkoutsStub.Object, null));
        }

        [Test]
        public void Constructor_ShouldNotThrowWhenAllParametersAreValid()
        {
            var pendingWorkoutsStub = new Mock<IEfRepostory<PendingWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            Assert.DoesNotThrow(() => new PendingWorkoutService(pendingWorkoutsStub.Object, unitOfWorkStub.Object));
        }

        [Test]
        public void Constructor_ShouldCreateCorrectServiceWhenAllParametersAreValid()
        {
            var pendingWorkoutsStub = new Mock<IEfRepostory<PendingWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new PendingWorkoutService(pendingWorkoutsStub.Object, unitOfWorkStub.Object);

            Assert.IsInstanceOf<PendingWorkoutService>(sut);
        }

        [Test]
        public void GetAll_ShouldCallPendingWorkoutsRepoAllPropertyOnce()
        {
            var pendingWorkoutsStub = new Mock<IEfRepostory<PendingWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var dbSetStub = new List<PendingWorkout>().AsQueryable();

            var sut = new PendingWorkoutService(pendingWorkoutsStub.Object, unitOfWorkStub.Object);

            pendingWorkoutsStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetAll();

            pendingWorkoutsStub.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetAll_ShouldReturnAnICollectionOfPendingWorkouts()
        {
            var pendingWorkoutsStub = new Mock<IEfRepostory<PendingWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var dbSetStub = new Mock<IList<PendingWorkout>>().As<IQueryable<PendingWorkout>>();

            var sut = new PendingWorkoutService(pendingWorkoutsStub.Object, unitOfWorkStub.Object);

            pendingWorkoutsStub.Setup(x => x.All).Returns(dbSetStub.Object);

            var result = sut.GetAll();

            Assert.IsInstanceOf(typeof(ICollection<PendingWorkout>), result);
        }

        [Test]
        public void GetById_ShouldCallPendingWorkoutsRepoAllPropertyOnce()
        {
            var pendingWorkoutsStub = new Mock<IEfRepostory<PendingWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var dbSetStub = new List<PendingWorkout>().AsQueryable();
            var id = new Guid();

            var sut = new PendingWorkoutService(pendingWorkoutsStub.Object, unitOfWorkStub.Object);

            pendingWorkoutsStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetById(id);

            pendingWorkoutsStub.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetById_ShouldReturnNullWhenNoEntryMatchesTheId()
        {
            var pendingWorkoutsStub = new Mock<IEfRepostory<PendingWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<PendingWorkout>();
            var workout = new PendingWorkout();
            list.Add(workout);

            var dbSetStub = list.AsQueryable();

            var sut = new PendingWorkoutService(pendingWorkoutsStub.Object, unitOfWorkStub.Object);

            pendingWorkoutsStub.Setup(x => x.All).Returns(dbSetStub);

            var newId = new Guid();

            var result = sut.GetById(newId);

            Assert.IsNull(result);
        }

        [Test]
        public void GetById_ShouldReturnCorrectEntryWhenIdMatchesThePasedId()
        {
            var pendingWorkoutsStub = new Mock<IEfRepostory<PendingWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<PendingWorkout>();
            var workout = new PendingWorkout();
            list.Add(workout);

            var dbSetStub = list.AsQueryable();

            var sut = new PendingWorkoutService(pendingWorkoutsStub.Object, unitOfWorkStub.Object);

            pendingWorkoutsStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetById(workout.Id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<PendingWorkout>(result);
            Assert.AreSame(result, workout);
        }

        [Test]
        public void Update_ShouldThrowWhenInvalidPendingWorkoutIsPassed()
        {
            var pendingWorkoutsStub = new Mock<IEfRepostory<PendingWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new PendingWorkoutService(pendingWorkoutsStub.Object, unitOfWorkStub.Object);

            pendingWorkoutsStub.Setup(x => x.Update(It.IsAny<PendingWorkout>()));
            unitOfWorkStub.Setup(x => x.Commit());

            Assert.Throws<ArgumentException>(() => sut.Update(null));
        }

        [Test]
        public void Update_ShouldCallRepoUpdateOnceWithCorrectExercise()
        {
            var pendingWorkoutsStub = new Mock<IEfRepostory<PendingWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new PendingWorkoutService(pendingWorkoutsStub.Object, unitOfWorkStub.Object);

            pendingWorkoutsStub.Setup(x => x.Update(It.IsAny<PendingWorkout>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new PendingWorkout();

            sut.Update(workout);

            pendingWorkoutsStub.Verify(x => x.Update(workout), Times.Once);
        }

        [Test]
        public void Update_ShouldCallUnitOfWorkCommitOnce()
        {
            var pendingWorkoutsStub = new Mock<IEfRepostory<PendingWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new PendingWorkoutService(pendingWorkoutsStub.Object, unitOfWorkStub.Object);

            pendingWorkoutsStub.Setup(x => x.Update(It.IsAny<PendingWorkout>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new PendingWorkout();

            sut.Update(workout);

            unitOfWorkStub.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void AddPending_ShouldThrowWhenInvalidWorkoutIsPassed()
        {
            var pendingWorkoutsStub = new Mock<IEfRepostory<PendingWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new PendingWorkoutService(pendingWorkoutsStub.Object, unitOfWorkStub.Object);

            pendingWorkoutsStub.Setup(x => x.Add(It.IsAny<PendingWorkout>()));
            unitOfWorkStub.Setup(x => x.Commit());

            Assert.Throws<ArgumentException>(() => sut.AddPending(null));
        }

        [Test]
        public void AddPending_ShouldCallRepoAddOnceWithCorrectWorkout()
        {
            var pendingWorkoutsStub = new Mock<IEfRepostory<PendingWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new PendingWorkoutService(pendingWorkoutsStub.Object, unitOfWorkStub.Object);

            pendingWorkoutsStub.Setup(x => x.Add(It.IsAny<PendingWorkout>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var exercise = new PendingWorkout();

            sut.AddPending(exercise);

            pendingWorkoutsStub.Verify(x => x.Add(exercise), Times.Once);
        }

        [Test]
        public void AddPending_ShouldCallUnitOfWorkCommitOnce()
        {
            var pendingWorkoutsStub = new Mock<IEfRepostory<PendingWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new PendingWorkoutService(pendingWorkoutsStub.Object, unitOfWorkStub.Object);

            pendingWorkoutsStub.Setup(x => x.Update(It.IsAny<PendingWorkout>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var exercise = new PendingWorkout();

            sut.AddPending(exercise);

            unitOfWorkStub.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void MarkPendingAsCompleted_ShouldThrowWhenInvalidWorkoutIsPassed()
        {
            var pendingWorkoutsStub = new Mock<IEfRepostory<PendingWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new PendingWorkoutService(pendingWorkoutsStub.Object, unitOfWorkStub.Object);

            Assert.Throws<ArgumentException>(() => sut.MarkPendingAsCompleted(null));
        }

        [Test]
        public void MarkPendingAsCompleted_ShouldMarkTheWorkoutAsCompleted()
        {
            var pendingWorkoutsStub = new Mock<IEfRepostory<PendingWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new PendingWorkoutService(pendingWorkoutsStub.Object, unitOfWorkStub.Object);

            pendingWorkoutsStub.Setup(x => x.Update(It.IsAny<PendingWorkout>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new PendingWorkout();

            sut.MarkPendingAsCompleted(workout);

            Assert.AreEqual(true, workout.IsCompleted);
        }

        [Test]
        public void MarkPendingAsCompleted_ShouldCallRepoUpdateOnce()
        {
            var pendingWorkoutsStub = new Mock<IEfRepostory<PendingWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new PendingWorkoutService(pendingWorkoutsStub.Object, unitOfWorkStub.Object);

            pendingWorkoutsStub.Setup(x => x.Update(It.IsAny<PendingWorkout>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new PendingWorkout();

            sut.MarkPendingAsCompleted(workout);

            pendingWorkoutsStub.Verify(x => x.Update(workout), Times.Once);
        }

        [Test]
        public void MarkPendingAsCompleted_ShouldCallUnitOfWorkCommitOnce()
        {
            var pendingWorkoutsStub = new Mock<IEfRepostory<PendingWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new PendingWorkoutService(pendingWorkoutsStub.Object, unitOfWorkStub.Object);

            pendingWorkoutsStub.Setup(x => x.Update(It.IsAny<PendingWorkout>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new PendingWorkout();

            sut.MarkPendingAsCompleted(workout);

            unitOfWorkStub.Verify(x => x.Commit(), Times.Once);
        }
    }
}
