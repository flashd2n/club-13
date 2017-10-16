using Flash.Club13.Data.Repository;
using Flash.Club13.Data.UnitOfWork;
using Flash.Club13.Interfaces.Providers;
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
    public class WeekScheduleServiceTests
    {
        [Test]
        public void Constructor_ShouldThrowWhenInvalidWeekScheduleIsProvided()
        {
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            Assert.Throws<ArgumentException>(() => new WeekScheduleService(null, unitOfWorkStub.Object, datetimeProviderStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenInvalidUnitOfWorkIsProvided()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            Assert.Throws<ArgumentException>(() => new WeekScheduleService(weekScheduleStub.Object, null, datetimeProviderStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenInvalidDatetimeProviderIsProvided()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentException>(() => new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, null));
        }

        [Test]
        public void Constructor_ShouldNotThrowWhenAllArgumentsAreValid()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            Assert.DoesNotThrow(() => new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object));
        }

        [Test]
        public void Constructor_ShouldCreateCorrectInstanceOfTheSerivce()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            Assert.IsInstanceOf<WeekScheduleService>(sut);
        }

        [Test]
        public void GetAll_ShouldCallWeekScheduleRepoAllPropertyOnce()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var dbSetStub = new List<WeekSchedule>().AsQueryable();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            weekScheduleStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetAll();

            weekScheduleStub.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetAll_ShouldReturnAnICollectionOfWeekSchedules()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();
            var dbSetStub = new Mock<IList<WeekSchedule>>().As<IQueryable<WeekSchedule>>();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            weekScheduleStub.Setup(x => x.All).Returns(dbSetStub.Object);

            var result = sut.GetAll();

            Assert.IsInstanceOf(typeof(ICollection<WeekSchedule>), result);
        }

        [Test]
        public void GetById_ShouldCallWeekSchedulesRepoAllPropertyOnce()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var dbSetStub = new List<WeekSchedule>().AsQueryable();
            var id = new Guid();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            weekScheduleStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetById(id);

            weekScheduleStub.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetById_ShouldReturnNullWhenNoEntryMatchesTheId()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var list = new List<WeekSchedule>();
            var weekSchedule = new WeekSchedule();
            list.Add(weekSchedule);

            var dbSetStub = list.AsQueryable();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            weekScheduleStub.Setup(x => x.All).Returns(dbSetStub);

            var newId = new Guid();

            var result = sut.GetById(newId);

            Assert.IsNull(result);
        }

        [Test]
        public void GetById_ShouldReturnCorrectEntryWhenIdMatchesThePasedId()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var list = new List<WeekSchedule>();
            var weekSchedule = new WeekSchedule();
            list.Add(weekSchedule);

            var dbSetStub = list.AsQueryable();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            weekScheduleStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetById(weekSchedule.Id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<WeekSchedule>(result);
            Assert.AreSame(result, weekSchedule);
        }

        [Test]
        public void GetAllDescending_ShouldCallWeekScheduleRepoAllPropertyOnce()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var dbSetStub = new List<WeekSchedule>().AsQueryable();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            weekScheduleStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetAllDescending();

            weekScheduleStub.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetAllDescending_ShouldReturnTwoWeekSchedulesInCorrectOrder()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var list = new List<WeekSchedule>();

            var weekScheduleOne = new WeekSchedule
            {
                WeekStart = new DateTime(2017, 10, 10)
            };

            var weekScheduleTwo = new WeekSchedule
            {
                WeekStart = new DateTime(2017, 11, 11)
            };

            list.Add(weekScheduleOne);
            list.Add(weekScheduleTwo);

            var dbSetStub = list.AsQueryable();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            weekScheduleStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetAllDescending();

            Assert.AreEqual(2, result.Count);
            Assert.AreSame(weekScheduleTwo, result.First());
        }

        [Test]
        public void GetCurrentSchedule_ShouldCallWeekScheduleRepoAllPropertyOnce()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var dbSetStub = new List<WeekSchedule>().AsQueryable();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            weekScheduleStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetCurrentSchedule();

            weekScheduleStub.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetCurrentSchedule_ShouldReturnInstanceOfWeekSchedule()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var today = new DateTime(2017, 10, 5);

            var list = new List<WeekSchedule>();

            var weekScheduleOne = new WeekSchedule
            {
                WeekStart = new DateTime(2017, 10, 2),
                WeekEnd = new DateTime(2017, 10, 8)
            };

            var weekScheduleTwo = new WeekSchedule
            {
                WeekStart = new DateTime(2017, 10, 9),
                WeekEnd = new DateTime(2017, 10, 15)
            };

            list.Add(weekScheduleOne);
            list.Add(weekScheduleTwo);

            var dbSetStub = list.AsQueryable();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            weekScheduleStub.Setup(x => x.All).Returns(dbSetStub);
            datetimeProviderStub.Setup(x => x.GetToday()).Returns(today);

            var result = sut.GetCurrentSchedule();

            Assert.IsInstanceOf<WeekSchedule>(result);
        }

        [Test]
        public void GetCurrentSchedule_ShouldReturnCorrectSchedule()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var today = new DateTime(2017, 10, 5);

            var list = new List<WeekSchedule>();

            var weekScheduleOne = new WeekSchedule
            {
                WeekStart = new DateTime(2017, 10, 2),
                WeekEnd = new DateTime(2017, 10, 8)
            };

            var weekScheduleTwo = new WeekSchedule
            {
                WeekStart = new DateTime(2017, 10, 9),
                WeekEnd = new DateTime(2017, 10, 15)
            };

            list.Add(weekScheduleOne);
            list.Add(weekScheduleTwo);

            var dbSetStub = list.AsQueryable();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            weekScheduleStub.Setup(x => x.All).Returns(dbSetStub);
            datetimeProviderStub.Setup(x => x.GetToday()).Returns(today);

            var result = sut.GetCurrentSchedule();

            Assert.AreSame(weekScheduleOne, result);
        }

        [Test]
        public void Update_ShouldThrowWhenInvalidWeekScheduleIsPassed()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            weekScheduleStub.Setup(x => x.Update(It.IsAny<WeekSchedule>()));
            unitOfWorkStub.Setup(x => x.Commit());

            Assert.Throws<ArgumentException>(() => sut.Update(null));
        }

        [Test]
        public void Update_ShouldCallRepoUpdateOnceWithCorrectWeekSchedule()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            weekScheduleStub.Setup(x => x.Update(It.IsAny<WeekSchedule>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var weekschedule = new WeekSchedule();

            sut.Update(weekschedule);

            weekScheduleStub.Verify(x => x.Update(weekschedule), Times.Once);
        }

        [Test]
        public void Update_ShouldCallUnitOfWorkCommitOnce()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            weekScheduleStub.Setup(x => x.Update(It.IsAny<WeekSchedule>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var weekSchedule = new WeekSchedule();

            sut.Update(weekSchedule);

            unitOfWorkStub.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void AddWeekSchedule_ShouldThrowWhenInvalidWeekScheduleIsPassed()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            weekScheduleStub.Setup(x => x.Add(It.IsAny<WeekSchedule>()));
            unitOfWorkStub.Setup(x => x.Commit());

            Assert.Throws<ArgumentException>(() => sut.AddWeekSchedule(null));
        }

        [Test]
        public void AddWeekSchedule_ShouldCallRepoAddOnceWithCorrectWeekSchedule()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            weekScheduleStub.Setup(x => x.Add(It.IsAny<WeekSchedule>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var weekSchedule = new WeekSchedule();

            sut.AddWeekSchedule(weekSchedule);

            weekScheduleStub.Verify(x => x.Add(weekSchedule), Times.Once);
        }

        [Test]
        public void AddWeekSchedule_ShouldCallUnitOfWorkCommitOnce()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            weekScheduleStub.Setup(x => x.Update(It.IsAny<WeekSchedule>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var weekSchedule = new WeekSchedule();

            sut.AddWeekSchedule(weekSchedule);

            unitOfWorkStub.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void AddDailiesToSchedule_ShouldThrowwhenInvalidScheduleIsPassed()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            Assert.Throws<ArgumentException>(() => sut.AddDailiesToSchedule(null));
        }

        [Test]
        public void AddDailiesToSchedule_ShouldAddTwoWorkoutsToDailyWorkoutsWhenTwoWorkoutsAreProvided()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            var schedule = new WeekSchedule();
            var workoutOne = new DailyWorkout();
            var workoutTwo = new DailyWorkout();
            
            weekScheduleStub.Setup(x => x.Update(It.IsAny<WeekSchedule>()));
            unitOfWorkStub.Setup(x => x.Commit());

            sut.AddDailiesToSchedule(schedule, workoutOne, workoutTwo);

            Assert.AreEqual(2, schedule.DailyWorkouts.Count);

        }

        [Test]
        public void AddDailiesToSchedule_ShouldNotAddAnythingWhenNoWorkoutsAreProvided()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            var schedule = new WeekSchedule();

            weekScheduleStub.Setup(x => x.Update(It.IsAny<WeekSchedule>()));
            unitOfWorkStub.Setup(x => x.Commit());

            sut.AddDailiesToSchedule(schedule);

            Assert.AreEqual(0, schedule.DailyWorkouts.Count);
        }

        [Test]
        public void AddDailiesToSchedule_ShouldCallUpdateOnTheRepo()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            var schedule = new WeekSchedule();
            var workoutOne = new DailyWorkout();
            var workoutTwo = new DailyWorkout();

            weekScheduleStub.Setup(x => x.Update(It.IsAny<WeekSchedule>()));
            unitOfWorkStub.Setup(x => x.Commit());

            sut.AddDailiesToSchedule(schedule, workoutOne, workoutTwo);

            weekScheduleStub.Verify(x => x.Update(It.IsAny<WeekSchedule>()), Times.Once);
        }

        [Test]
        public void AddDailiesToSchedule_ShouldCallCommitOnTheUnitOfWork()
        {
            var weekScheduleStub = new Mock<IEfRepostory<WeekSchedule>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var datetimeProviderStub = new Mock<IDatetimeProvider>();

            var sut = new WeekScheduleService(weekScheduleStub.Object, unitOfWorkStub.Object, datetimeProviderStub.Object);

            var schedule = new WeekSchedule();
            var workoutOne = new DailyWorkout();
            var workoutTwo = new DailyWorkout();

            weekScheduleStub.Setup(x => x.Update(It.IsAny<WeekSchedule>()));
            unitOfWorkStub.Setup(x => x.Commit());

            sut.AddDailiesToSchedule(schedule, workoutOne, workoutTwo);

            unitOfWorkStub.Verify(x => x.Commit(), Times.Once);
        }

    }
}
