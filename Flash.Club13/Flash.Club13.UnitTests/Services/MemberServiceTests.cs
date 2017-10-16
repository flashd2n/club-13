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
    public class MemberServiceTests
    {
        [Test]
        public void Constructor_ShouldThrowWhenInvalidMemberRepoIsPassed()
        {
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentException>(() => new MemberService(null, unitOfWorkStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenInvalidUnitOfWorkIsPassed()
        {
            var membersRepoStub = new Mock<IEfRepostory<Member>>();

            Assert.Throws<ArgumentException>(() => new MemberService(membersRepoStub.Object, null));
        }

        [Test]
        public void Constructor_ShouldNotThrowWhenAllParametersAreValid()
        {
            var membersRepoStub = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            Assert.DoesNotThrow(() => new MemberService(membersRepoStub.Object, unitOfWorkStub.Object));
        }

        [Test]
        public void Constructor_ShouldCreateCorrectServiceWhenAllParametersAreValid()
        {
            var membersRepoStub = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new MemberService(membersRepoStub.Object, unitOfWorkStub.Object);

            Assert.IsInstanceOf<MemberService>(sut);
        }

        [Test]
        public void GetByUserId_ShouldThrowWhenInvalidIdIsPassed()
        {
            var membersRepoStub = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<Member>();
            var member = new Member();
            member.UserId = "gosho";
            list.Add(member);

            var dbSetStub = list.AsQueryable();

            var sut = new MemberService(membersRepoStub.Object, unitOfWorkStub.Object);

            membersRepoStub.Setup(x => x.All).Returns(dbSetStub);

            Assert.Throws<ArgumentException>(() => sut.GetByUserId(null));
        }

        [Test]
        public void GetByUserId_ShouldReturnNullWhenNoUserWithProvidedIdIsFound()
        {
            var membersRepoStub = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var validId = "pesho";

            var list = new List<Member>();
            var member = new Member();
            member.UserId = "gosho";
            list.Add(member);

            var dbSetStub = list.AsQueryable();

            var sut = new MemberService(membersRepoStub.Object, unitOfWorkStub.Object);

            membersRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetByUserId(validId);

            Assert.IsNull(result);
        }

        [Test]
        public void GetByUserId_ShouldReturnCorrectMemberInstanceWhenProvidedIdMatches()
        {
            var membersRepoStub = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var validId = "gosho";

            var list = new List<Member>();
            var member = new Member();
            member.UserId = "gosho";
            list.Add(member);

            var dbSetStub = list.AsQueryable();

            var sut = new MemberService(membersRepoStub.Object, unitOfWorkStub.Object);

            membersRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetByUserId(validId);

            Assert.IsInstanceOf<Member>(result);
            Assert.AreSame(member, result);

        }

        [Test]
        public void GetTotalMemberCount_ShouldReturnZeroWhenNoMembersInTheRepo()
        {
            var membersRepoStub = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<Member>();

            var dbSetStub = list.AsQueryable();

            var sut = new MemberService(membersRepoStub.Object, unitOfWorkStub.Object);

            membersRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetTotalMemberCount();

            Assert.AreEqual(0, result);
        }

        [Test]
        public void GetTotalMemberCount_ShouldReturnTwoWhenTwoMembersInTheRepo()
        {
            var membersRepoStub = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<Member>();
            var memberOne = new Member();
            list.Add(memberOne);
            var memberTwo = new Member();
            list.Add(memberTwo);

            var dbSetStub = list.AsQueryable();

            var sut = new MemberService(membersRepoStub.Object, unitOfWorkStub.Object);

            membersRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetTotalMemberCount();

            Assert.AreEqual(2, result);
        }


        [Test]
        public void GetById_ShouldCallMembersRepoAllPropertyOnce()
        {
            var membersRepoStub = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var dbSetStub = new List<Member>().AsQueryable();
            var id = new Guid();

            var sut = new MemberService(membersRepoStub.Object, unitOfWorkStub.Object);

            membersRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetById(id);

            membersRepoStub.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetById_ShouldReturnNullWhenNoEntryMatchesTheId()
        {
            var membersRepoStub = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<Member>();
            var member = new Member();
            list.Add(member);

            var dbSetStub = list.AsQueryable();

            var sut = new MemberService(membersRepoStub.Object, unitOfWorkStub.Object);

            membersRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var newId = new Guid();

            var result = sut.GetById(newId);

            Assert.IsNull(result);
        }

        [Test]
        public void GetById_ShouldReturnCorrectEntryWhenIdMatchesThePasedId()
        {
            var membersRepoStub = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<Member>();
            var member = new Member();
            list.Add(member);

            var dbSetStub = list.AsQueryable();

            var sut = new MemberService(membersRepoStub.Object, unitOfWorkStub.Object);

            membersRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetById(member.Id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Member>(result);
            Assert.AreSame(result, member);
        }

        [Test]
        public void Update_ShouldThrowWhenInvalidMemberIsPassed()
        {
            var membersRepoStub = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new MemberService(membersRepoStub.Object, unitOfWorkStub.Object);

            membersRepoStub.Setup(x => x.Update(It.IsAny<Member>()));
            unitOfWorkStub.Setup(x => x.Commit());

            Assert.Throws<ArgumentException>(() => sut.Update(null));
        }

        [Test]
        public void Update_ShouldCallRepoUpdateOnceWithCorrectExercise()
        {
            var membersRepoStub = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new MemberService(membersRepoStub.Object, unitOfWorkStub.Object);

            membersRepoStub.Setup(x => x.Update(It.IsAny<Member>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var exercise = new Member();

            sut.Update(exercise);

            membersRepoStub.Verify(x => x.Update(exercise), Times.Once);
        }

        [Test]
        public void Update_ShouldCallUnitOfWorkCommitOnce()
        {
            var membersRepoStub = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new MemberService(membersRepoStub.Object, unitOfWorkStub.Object);

            membersRepoStub.Setup(x => x.Update(It.IsAny<Member>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var exercise = new Member();

            sut.Update(exercise);

            unitOfWorkStub.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void AddPending_ShouldThrowWhenInvalidMemberIsPassed()
        {
            var membersRepoMock = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var sut = new MemberService(membersRepoMock.Object, unitOfWorkStub.Object);

            var workout = new PendingWorkout();

            Assert.Throws<ArgumentException>(() => sut.AddPending(null, workout));
        }

        [Test]
        public void AddPending_ShouldThrowWhenInvalidWorkoutIsPassed()
        {
            var membersRepoMock = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var sut = new MemberService(membersRepoMock.Object, unitOfWorkStub.Object);

            var member = new Member();

            Assert.Throws<ArgumentException>(() => sut.AddPending(member, null));
        }

        [Test]
        public void AddPending_ShouldAddWorkoutToMemberPendingWorkouts()
        {
            var membersRepoMock = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var sut = new MemberService(membersRepoMock.Object, unitOfWorkStub.Object);

            var pendingWorkout = new PendingWorkout();
            var member = new Member();

            sut.AddPending(member, pendingWorkout);

            Assert.AreEqual(1, member.PendingWorkouts.Count);
            Assert.AreSame(pendingWorkout, member.PendingWorkouts.First());
        }

        [Test]
        public void AddPending_ShouldCallUpdateRepoOnce()
        {
            var membersRepoMock = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var sut = new MemberService(membersRepoMock.Object, unitOfWorkStub.Object);

            membersRepoMock.Setup(x => x.Update(It.IsAny<Member>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var pendingWorkout = new PendingWorkout();
            var member = new Member();

            sut.AddPending(member, pendingWorkout);

            membersRepoMock.Verify(x => x.Update(member), Times.Once);
        }

        [Test]
        public void AddPending_ShouldCallUnitOfWorkCommitOnce()
        {
            var membersRepoMock = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var sut = new MemberService(membersRepoMock.Object, unitOfWorkStub.Object);

            membersRepoMock.Setup(x => x.Update(It.IsAny<Member>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var pendingWorkout = new PendingWorkout();
            var member = new Member();

            sut.AddPending(member, pendingWorkout);

            unitOfWorkStub.Verify(x => x.Commit(), Times.Once);
        }




        [Test]
        public void AddWorkout_ShouldThrowWhenInvalidMemberIsPassed()
        {
            var membersRepoMock = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var sut = new MemberService(membersRepoMock.Object, unitOfWorkStub.Object);

            var workout = new Workout();

            Assert.Throws<ArgumentException>(() => sut.AddWorkout(null, workout));
        }

        [Test]
        public void AddWorkout_ShouldThrowWhenInvalidWorkoutIsPassed()
        {
            var membersRepoMock = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var sut = new MemberService(membersRepoMock.Object, unitOfWorkStub.Object);

            var member = new Member();

            Assert.Throws<ArgumentException>(() => sut.AddWorkout(member, null));
        }

        [Test]
        public void AddWorkout_ShouldAddWorkoutToMemberWorkouts()
        {
            var membersRepoMock = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var sut = new MemberService(membersRepoMock.Object, unitOfWorkStub.Object);

            var workout = new Workout();
            var member = new Member();

            sut.AddWorkout(member, workout);

            Assert.AreEqual(1, member.Workouts.Count);
            Assert.AreSame(workout, member.Workouts.First());
        }

        [Test]
        public void AddWorkout_ShouldCallUpdateRepoOnce()
        {
            var membersRepoMock = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var sut = new MemberService(membersRepoMock.Object, unitOfWorkStub.Object);

            membersRepoMock.Setup(x => x.Update(It.IsAny<Member>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new Workout();
            var member = new Member();

            sut.AddWorkout(member, workout);

            membersRepoMock.Verify(x => x.Update(member), Times.Once);
        }

        [Test]
        public void AddWorkout_ShouldCallUnitOfWorkCommitOnce()
        {
            var membersRepoMock = new Mock<IEfRepostory<Member>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var sut = new MemberService(membersRepoMock.Object, unitOfWorkStub.Object);

            membersRepoMock.Setup(x => x.Update(It.IsAny<Member>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var workout = new Workout();
            var member = new Member();

            sut.AddWorkout(member, workout);

            unitOfWorkStub.Verify(x => x.Commit(), Times.Once);
        }

    }
}
