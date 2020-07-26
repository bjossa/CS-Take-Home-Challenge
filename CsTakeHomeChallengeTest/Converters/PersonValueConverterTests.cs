using CS_Take_Home_Challenge;
using NUnit.Framework;

namespace CsTakeHomeChallengeTest.Converters
{
    [TestFixture]
    class PersonValueConverterTests
    {
        private const string k_white = "AntiqueWhite";
        private const string k_gray = "Gray";

        [Test]
        public void Convert_TruetoBlack()
        {
            // Arrange
            var systemUnderTest = new PersonValueConverter();

            // Act
            var result = systemUnderTest.Convert(true, null, null, null);

            // Assert
            Assert.AreEqual(result, k_white);
        }

        [Test]
        public void Convert_FalseToGray()
        {
            // Arrange
            var systemUnderTest = new PersonValueConverter();

            // Act
            var result = systemUnderTest.Convert(false, null, null, null);

            // Assert
            Assert.AreEqual(result, k_gray);
        }
    }
}
