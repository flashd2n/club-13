using NUnit.Framework;

namespace Flash.Club13.Tests
{
    [TestFixture]
    public class Testing
    {
        [Test]
        public void TestingTestFunctionality()
        {
            var a = 42;
            var b = 72;

            Assert.AreNotEqual(a, b);
        }
    }
}
