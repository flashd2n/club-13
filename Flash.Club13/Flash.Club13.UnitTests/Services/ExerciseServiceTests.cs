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
    public class ExerciseServiceTests
    {
        [Test]
        public void Constructor_ShouldThrowWhenInvalidExerciseRepoIsPassed()
        {
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentException>(() => new ExerciseService(null, unitOfWorkStub.Object));
        }

        [Test]
        public void Constructor_ShouldThrowWhenInvalidUnitOfWorkIsPassed()
        {
            var exercisesRepoStub = new Mock<IEfRepostory<Exercise>>();

            Assert.Throws<ArgumentException>(() => new ExerciseService(exercisesRepoStub.Object, null));
        }

        [Test]
        public void Constructor_ShouldNotThrowWhenAllParametersAreValid()
        {
            var exercisesRepoStub = new Mock<IEfRepostory<Exercise>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            Assert.DoesNotThrow(() => new ExerciseService(exercisesRepoStub.Object, unitOfWorkStub.Object));
        }

        [Test]
        public void Constructor_ShouldCreateCorrectServiceWhenAllParametersAreValid()
        {
            var exercisesRepoStub = new Mock<IEfRepostory<Exercise>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new ExerciseService(exercisesRepoStub.Object, unitOfWorkStub.Object);

            Assert.IsInstanceOf<ExerciseService>(sut);
        }

        [Test]
        public void GetAll_ShouldCallExerciseRepoAllPropertyOnce()
        {
            var exercisesRepoStub = new Mock<IEfRepostory<Exercise>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var dbSetStub = new List<Exercise>().AsQueryable();

            var sut = new ExerciseService(exercisesRepoStub.Object, unitOfWorkStub.Object);

            exercisesRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetAll();

            exercisesRepoStub.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetAll_ShouldReturnAnICollectionOfExercises()
        {
            var exercisesRepoStub = new Mock<IEfRepostory<Exercise>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var dbSetStub = new Mock<IList<Exercise>>().As<IQueryable<Exercise>>();

            var sut = new ExerciseService(exercisesRepoStub.Object, unitOfWorkStub.Object);

            exercisesRepoStub.Setup(x => x.All).Returns(dbSetStub.Object);

            var result = sut.GetAll();

            Assert.IsInstanceOf(typeof(ICollection<Exercise>), result);
        }

        [Test]
        public void GetAllExerciseNames_ShouldExerciseRepoAllPropertyOnce()
        {
            var exercisesRepoStub = new Mock<IEfRepostory<Exercise>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var dbSetStub = new List<Exercise>().AsQueryable();

            var sut = new ExerciseService(exercisesRepoStub.Object, unitOfWorkStub.Object);

            exercisesRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetAllExerciseNames();

            exercisesRepoStub.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetAllExerciseNames_ShouldICollectionOfStrings()
        {
            var exercisesRepoStub = new Mock<IEfRepostory<Exercise>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<Exercise>();
            var exercise = new Exercise();
            exercise.Name = "gosho";
            list.Add(exercise);

            var dbSetStub = list.AsQueryable();

            var sut = new ExerciseService(exercisesRepoStub.Object, unitOfWorkStub.Object);

            exercisesRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetAllExerciseNames();

            Assert.IsInstanceOf(typeof(ICollection<string>), result);
        }

        [Test]
        public void GetAllExerciseNames_ShouldReturnICollectionOfTwoStringsWhenTwoExercisesArePresentInTheRepo()
        {
            var exercisesRepoStub = new Mock<IEfRepostory<Exercise>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<Exercise>();
            var exerciseOne = new Exercise();
            exerciseOne.Name = "gosho";
            var exerciseTwo = new Exercise
            {
                Name = "pesho"
            };
            list.Add(exerciseOne);
            list.Add(exerciseTwo);

            var dbSetStub = list.AsQueryable();

            var sut = new ExerciseService(exercisesRepoStub.Object, unitOfWorkStub.Object);

            exercisesRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetAllExerciseNames();

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetById_ShouldCallExercisesRepoAllPropertyOnce()
        {
            var exercisesRepoStub = new Mock<IEfRepostory<Exercise>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var dbSetStub = new List<Exercise>().AsQueryable();
            var id = new Guid();

            var sut = new ExerciseService(exercisesRepoStub.Object, unitOfWorkStub.Object);

            exercisesRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetById(id);

            exercisesRepoStub.Verify(x => x.All, Times.Once);
        }

        [Test]
        public void GetById_ShouldReturnNullWhenNoEntryMatchesTheId()
        {
            var exercisesRepoStub = new Mock<IEfRepostory<Exercise>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<Exercise>();
            var exercise = new Exercise();
            list.Add(exercise);

            var dbSetStub = list.AsQueryable();

            var sut = new ExerciseService(exercisesRepoStub.Object, unitOfWorkStub.Object);

            exercisesRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var newId = new Guid();

            var result = sut.GetById(newId);

            Assert.IsNull(result);
        }

        [Test]
        public void GetById_ShouldReturnCorrectEntryWhenIdMatchesThePasedId()
        {
            var exercisesRepoStub = new Mock<IEfRepostory<Exercise>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var list = new List<Exercise>();
            var exercise = new Exercise();
            list.Add(exercise);

            var dbSetStub = list.AsQueryable();

            var sut = new ExerciseService(exercisesRepoStub.Object, unitOfWorkStub.Object);

            exercisesRepoStub.Setup(x => x.All).Returns(dbSetStub);

            var result = sut.GetById(exercise.Id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Exercise>(result);
            Assert.AreSame(result, exercise);
        }

        [Test]
        public void Update_ShouldThrowWhenInvalidExerciseIsPassed()
        {
            var exercisesRepoStub = new Mock<IEfRepostory<Exercise>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new ExerciseService(exercisesRepoStub.Object, unitOfWorkStub.Object);

            exercisesRepoStub.Setup(x => x.Update(It.IsAny<Exercise>()));
            unitOfWorkStub.Setup(x => x.Commit());

            Assert.Throws<ArgumentException>(() => sut.Update(null));
        }

        [Test]
        public void Update_ShouldCallRepoUpdateOnceWithCorrectExercise()
        {
            var exercisesRepoStub = new Mock<IEfRepostory<Exercise>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new ExerciseService(exercisesRepoStub.Object, unitOfWorkStub.Object);

            exercisesRepoStub.Setup(x => x.Update(It.IsAny<Exercise>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var exercise = new Exercise();

            sut.Update(exercise);

            exercisesRepoStub.Verify(x => x.Update(exercise), Times.Once);
        }

        [Test]
        public void Update_ShouldCallUnitOfWorkCommitOnce()
        {
            var exercisesRepoStub = new Mock<IEfRepostory<Exercise>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new ExerciseService(exercisesRepoStub.Object, unitOfWorkStub.Object);

            exercisesRepoStub.Setup(x => x.Update(It.IsAny<Exercise>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var exercise = new Exercise();

            sut.Update(exercise);

            unitOfWorkStub.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void AddExercise_ShouldThrowWhenInvalidExerciseIsPassed()
        {
            var exercisesRepoStub = new Mock<IEfRepostory<Exercise>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new ExerciseService(exercisesRepoStub.Object, unitOfWorkStub.Object);

            exercisesRepoStub.Setup(x => x.Add(It.IsAny<Exercise>()));
            unitOfWorkStub.Setup(x => x.Commit());

            Assert.Throws<ArgumentException>(() => sut.AddExercise(null));
        }

        [Test]
        public void AddExercise_ShouldCallRepoAddOnceWithCorrectExercise()
        {
            var exercisesRepoStub = new Mock<IEfRepostory<Exercise>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new ExerciseService(exercisesRepoStub.Object, unitOfWorkStub.Object);

            exercisesRepoStub.Setup(x => x.Add(It.IsAny<Exercise>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var exercise = new Exercise();

            sut.AddExercise(exercise);

            exercisesRepoStub.Verify(x => x.Add(exercise), Times.Once);
        }

        [Test]
        public void AddExercise_ShouldCallUnitOfWorkCommitOnce()
        {
            var exercisesRepoStub = new Mock<IEfRepostory<Exercise>>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();

            var sut = new ExerciseService(exercisesRepoStub.Object, unitOfWorkStub.Object);

            exercisesRepoStub.Setup(x => x.Update(It.IsAny<Exercise>()));
            unitOfWorkStub.Setup(x => x.Commit());

            var exercise = new Exercise();

            sut.AddExercise(exercise);

            unitOfWorkStub.Verify(x => x.Commit(), Times.Once);
        }
    }
}
