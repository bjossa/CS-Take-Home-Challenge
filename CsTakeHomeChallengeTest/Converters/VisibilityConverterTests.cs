using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CS_Take_Home_Challenge;
using NUnit.Framework;

namespace CsTakeHomeChallengeTest.Converters
{
    [TestFixture]
    public class VisibilityConverterTests
    {
        [Test]
        public void Convert_FalseToCollapsed()
        {
            // Arrange
            var systemUnderTest = new VisibilityConverter();

            // Act
            var result = systemUnderTest.Convert(false, null, null, null);

            // Assert
            Assert.AreEqual(result, Visibility.Collapsed);
        }

        [Test]
        public void Convert_TrueToVisible()
        {
            // Arrange
            var systemUnderTest = new VisibilityConverter();

            // Act
            var result = systemUnderTest.Convert(true, null, null, null);

            // Assert
            Assert.AreEqual(result, Visibility.Visible);
        }
    }
}
