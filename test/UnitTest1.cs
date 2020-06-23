using CS_Take_Home_Challenge;
using NUnit.Framework;

namespace test
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void myTest()
        {
            //Assert.AreEqual(1, (3-2));
            // Arrange
            var systemUnderTest = new PersonValueConverter();

            //// Act
            //var result = systemUnderTest.Convert(true, null, null, null);

            //// Assert
            //Assert.AreEqual(result, "Black");
        }
    }
}