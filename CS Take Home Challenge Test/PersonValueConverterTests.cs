using CS_Take_Home_Challenge;
using NUnit.Framework;

namespace CS_Take_Home_Challenge_Test
{
    [TestFixture]
    public class PersonValueConverterTests
    {

        [Test]
        public void Convert_TruetoBlack()
        {
            // Arrange
            var systemUnderTest = new PersonValueConverter();

            // Act
            var result = systemUnderTest.Convert(true, null, null, null);

            // Assert
            Assert.AreEqual(result, "Black");
        }
    }
}
