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
    public class DailyWorkoutServiceTests
    {
        [Test]
        public void Constructor_ShouldNotThrowWhenValidParametersArePassed()
        {
            var dailyWorkoutRepoStub = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            Assert.DoesNotThrow(() => new DailyWorkoutService(dailyWorkoutRepoStub.Object, unitOfWorkStub.Object));
        }

        [Test]
        public void Constructor_ShouldCreateCorrectInstanceWhenValidParametersArePassed()
        {
            var dailyWorkoutRepoStub = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new DailyWorkoutService(dailyWorkoutRepoStub.Object, unitOfWorkStub.Object);

            Assert.IsInstanceOf(typeof(DailyWorkoutService), sut);
        }

        [Test]
        public void Constructor_ShouldThrowWhenInvalidDailyWorkoutRepoIsPassed()
        {
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentException>(() => new DailyWorkoutService(null, unitOfWorkStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenInvalidUnitOfWorkIsPassed()
        {
            var dailyWorkoutRepoStub = new Mock<IEfRepostory<DailyWorkout>>();

            Assert.Throws<ArgumentException>(() => new DailyWorkoutService(dailyWorkoutRepoStub.Object, null));
        }

        [Test]
        public void Constructor_ShouldThrowWhenAllPassedParametersAreInvalid()
        {
            Assert.Throws<ArgumentException>(() => new DailyWorkoutService(null, null));
        }

        [Test]
        public void GetAll_ShouldCallDailyWokrooutRepoAllPropertyOnce()
        {
            var dailyWorkoutRepoMock = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var dbSetStub = new List<DailyWorkout>().AsQueryable();

            var sut = new DailyWorkoutService(dailyWorkoutRepoMock.Object, unitOfWorkStub.Object);
            
            dailyWorkoutRepoMock.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetAll();

            dailyWorkoutRepoMock.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetAll_ShouldReturnAnICollectionOfDailyWorkouts()
        {
            var dailyWorkoutRepoMock = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var dbSetStub = new Mock<IList<DailyWorkout>>().As<IQueryable<DailyWorkout>>();

            var sut = new DailyWorkoutService(dailyWorkoutRepoMock.Object, unitOfWorkStub.Object);

            dailyWorkoutRepoMock.Setup(x => x.All).Returns(dbSetStub.Object);

            var result = sut.GetAll();

            Assert.IsInstanceOf(typeof(ICollection<DailyWorkout>), result);
        }

        [Test]
        public void GetById_ShouldCallDailyWokrooutRepoAllPropertyOnce()
        {
            var dailyWorkoutRepoMock = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var dbSetStub = new List<DailyWorkout>().AsQueryable();
            var id = new Guid();

            var sut = new DailyWorkoutService(dailyWorkoutRepoMock.Object, unitOfWorkStub.Object);

            dailyWorkoutRepoMock.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetById(id);

            dailyWorkoutRepoMock.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetById_ShouldReturnNullWhenNoEntryMatchesTheId()
        {
            var dailyWorkoutRepoMock = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<DailyWorkout>();
            var dailyWorkout = new DailyWorkout();
            list.Add(dailyWorkout);

            var dbSetStub = list.AsQueryable();

            var sut = new DailyWorkoutService(dailyWorkoutRepoMock.Object, unitOfWorkStub.Object);

            dailyWorkoutRepoMock.Setup(x => x.All).Returns(dbSetStub);

            var newId = new Guid();

            var result = sut.GetById(newId);

            Assert.IsNull(result);
        }

        [Test]
        public void GetById_ShouldReturnCorrectEntryWhenIdMatchesThePasedId()
        {
            var dailyWorkoutRepoMock = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<DailyWorkout>();
            var dailyWorkout = new DailyWorkout();
            list.Add(dailyWorkout);

            var dbSetStub = list.AsQueryable();

            var sut = new DailyWorkoutService(dailyWorkoutRepoMock.Object, unitOfWorkStub.Object);

            dailyWorkoutRepoMock.Setup(x => x.All).Returns(dbSetStub);
            
            var result = sut.GetById(dailyWorkout.Id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<DailyWorkout>(result);
            Assert.AreSame(result, dailyWorkout);
        }

        [Test]
        public void Update_ShouldThrowWhenInvalidDailyWorkoutIsPassed()
        {
            var dailyWorkoutRepoMock = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new DailyWorkoutService(dailyWorkoutRepoMock.Object, unitOfWorkStub.Object);

            dailyWorkoutRepoMock.Setup(x => x.Update(It.IsAny<DailyWorkout>()));
            unitOfWorkStub.Setup(x => x.Commit());

            Assert.Throws<ArgumentException>(() => sut.Update(null));
        }

        [Test]
        public void Update_ShouldCallRepoUpdateOnceWithCorrectDailyWorkout()
        {
            var dailyWorkoutRepoMock = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new DailyWorkoutService(dailyWorkoutRepoMock.Object, unitOfWorkStub.Object);

            dailyWorkoutRepoMock.Setup(x => x.Update(It.IsAny<DailyWorkout>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new DailyWorkout();

            sut.Update(workout);

            dailyWorkoutRepoMock.Verify(x => x.Update(workout), Times.Once);
        }

        [Test]
        public void Update_ShouldCallUnitOfWorkCommitOnce()
        {
            var dailyWorkoutRepoMock = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new DailyWorkoutService(dailyWorkoutRepoMock.Object, unitOfWorkStub.Object);

            dailyWorkoutRepoMock.Setup(x => x.Update(It.IsAny<DailyWorkout>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new DailyWorkout();

            sut.Update(workout);

            unitOfWorkStub.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void AddDailyWorkout_ShouldThrowWhenInvalidWorkoutIsPassed()
        {
            var dailyWorkoutRepoMock = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new DailyWorkoutService(dailyWorkoutRepoMock.Object, unitOfWorkStub.Object);

            dailyWorkoutRepoMock.Setup(x => x.Add(It.IsAny<DailyWorkout>()));
            unitOfWorkStub.Setup(x => x.Commit());

            Assert.Throws<ArgumentException>(() => sut.AddDailyWorkout(null));
        }

        [Test]
        public void AddDailyWorkout_ShouldCallRepoAddOnceWithCorrectDailyWorkout()
        {
            var dailyWorkoutRepoMock = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new DailyWorkoutService(dailyWorkoutRepoMock.Object, unitOfWorkStub.Object);

            dailyWorkoutRepoMock.Setup(x => x.Add(It.IsAny<DailyWorkout>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new DailyWorkout();

            sut.AddDailyWorkout(workout);

            dailyWorkoutRepoMock.Verify(x => x.Add(workout), Times.Once);
        }

        [Test]
        public void AddDailyWorkout_ShouldCallUnitOfWorkCommitOnce()
        {
            var dailyWorkoutRepoMock = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new DailyWorkoutService(dailyWorkoutRepoMock.Object, unitOfWorkStub.Object);

            dailyWorkoutRepoMock.Setup(x => x.Update(It.IsAny<DailyWorkout>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new DailyWorkout();

            sut.AddDailyWorkout(workout);

            unitOfWorkStub.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void AddMemberToDailyWorkout_ShouldThrowWhenInvalidMemberIsPassed()
        {
            var dailyWorkoutRepoMock = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var sut = new DailyWorkoutService(dailyWorkoutRepoMock.Object, unitOfWorkStub.Object);

            var workout = new DailyWorkout();

            Assert.Throws<ArgumentException>(() => sut.AddMemberToDailyWorkout(null, workout));
        }

        [Test]
        public void AddMemberToDailyWorkout_ShouldThrowWhenInvalidWorkoutIsPassed()
        {
            var dailyWorkoutRepoMock = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var sut = new DailyWorkoutService(dailyWorkoutRepoMock.Object, unitOfWorkStub.Object);

            var member = new Member();

            Assert.Throws<ArgumentException>(() => sut.AddMemberToDailyWorkout(member, null));

        }

        [Test]
        public void AddMemberToDailyWorkout_ShouldAddMemberToWorkoutSignedMembersCollection()
        {
            var dailyWorkoutRepoMock = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var sut = new DailyWorkoutService(dailyWorkoutRepoMock.Object, unitOfWorkStub.Object);

            var workout = new DailyWorkout();
            var member = new Member();

            sut.AddMemberToDailyWorkout(member, workout);

            Assert.AreEqual(1, workout.SignedMembers.Count);
            Assert.AreSame(member, workout.SignedMembers.First());
        }

        [Test]
        public void AddMemberToDailyWorkout_ShouldCallRepoUpdateOnceWithCorrectDailyWorkout()
        {
            var dailyWorkoutRepoMock = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var sut = new DailyWorkoutService(dailyWorkoutRepoMock.Object, unitOfWorkStub.Object);

            dailyWorkoutRepoMock.Setup(x => x.Update(It.IsAny<DailyWorkout>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new DailyWorkout();
            var member = new Member();

            sut.AddMemberToDailyWorkout(member, workout);

            dailyWorkoutRepoMock.Verify(x => x.Update(workout), Times.Once);
        }

        [Test]
        public void AddMemberToDailyWorkout_ShouldCallUnitOfWorkCommitOnce()
        {
            var dailyWorkoutRepoMock = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var sut = new DailyWorkoutService(dailyWorkoutRepoMock.Object, unitOfWorkStub.Object);

            dailyWorkoutRepoMock.Setup(x => x.Update(It.IsAny<DailyWorkout>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new DailyWorkout();
            var member = new Member();

            sut.AddMemberToDailyWorkout(member, workout);

            unitOfWorkStub.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void AddAllDailyWorkouts_ShouldCallUnitOfWorkCommitWhenWorkoutsAdded()
        {
            var dailyWorkoutRepoMock = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var sut = new DailyWorkoutService(dailyWorkoutRepoMock.Object, unitOfWorkStub.Object);

            var workoutOne = new DailyWorkout();
            var workoutTwo = new DailyWorkout();

            unitOfWorkStub.Setup(x => x.Commit());
            dailyWorkoutRepoMock.Setup(x => x.Add(It.IsAny<DailyWorkout>()));

            sut.AddAllDailyWorkouts(workoutOne, workoutTwo);

            unitOfWorkStub.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void AddAllDailyWorkouts_ShouldAddTwoWorkoutsToRepoWhenTwoWorkoutsArePassed()
        {
            var dailyWorkoutRepoMock = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var sut = new DailyWorkoutService(dailyWorkoutRepoMock.Object, unitOfWorkStub.Object);

            var workoutOne = new DailyWorkout();
            var workoutTwo = new DailyWorkout();

            unitOfWorkStub.Setup(x => x.Commit());
            dailyWorkoutRepoMock.Setup(x => x.Add(It.IsAny<DailyWorkout>()));

            sut.AddAllDailyWorkouts(workoutOne, workoutTwo);

            dailyWorkoutRepoMock.Verify(x => x.Add(It.IsAny<DailyWorkout>()), Times.Exactly(2));
        }

        [Test]
        public void AddAllDailyWorkouts_ShouldAddOneWorkoutToRepoWhenOneWorkoutIsPassed()
        {
            var dailyWorkoutRepoMock = new Mock<IEfRepostory<DailyWorkout>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var sut = new DailyWorkoutService(dailyWorkoutRepoMock.Object, unitOfWorkStub.Object);

            var workout = new DailyWorkout();

            unitOfWorkStub.Setup(x => x.Commit());
            dailyWorkoutRepoMock.Setup(x => x.Add(It.IsAny<DailyWorkout>()));

            sut.AddAllDailyWorkouts(workout);

            dailyWorkoutRepoMock.Verify(x => x.Add(It.IsAny<DailyWorkout>()), Times.Once);
        }

    }
}
