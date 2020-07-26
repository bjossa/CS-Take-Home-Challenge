using CS_Take_Home_Challenge.fileCommunication;
using NUnit.Framework;
using System.IO;
using Moq;

namespace CsTakeHomeChallengeTest.FileCommunication
{
    [TestFixture]
    class FileProxyTests
    {
        private const string k_filePath = "ValidFilePath";

        [Test]
        public void ReadLinesFromFile_ValidFilePath()
        {
            // Arrange
            var mockWrapper = new Mock<IFileWrapper>();
            var systemUnderTest = new FileProxy(k_filePath, mockWrapper.Object);
            string[] peopleStrings = new string[]
            {
                "Tina,   38 Beatty St,    6045603491, true"
                , "Louise, 9 Beatty St,     7780651112, true"
                , "Bob,    21 Robson St,    6046502342, true"
                , "Linda,  56 Pacific Blvd, 7780569123, true"
                , "Gene,   679 Thurlow St,  7782396673, true"
                , "Frond,  123 Main St,     6042391234, false"
                , "Mort,   203 Main St,     6041234567, false"
                , "Teddy,  302 Nelson St,   7783491103, true"
                , "Gayle,  222 Smithe St,   6049873214, true"
                , "Ollie,  89 Cambie St,    6049876543, true"
            };
            mockWrapper.Setup(mock => mock.ReadAllLinesFromFile(It.IsAny<string>())).Returns(peopleStrings).Verifiable();

            //Act
            string[] results = systemUnderTest.ReadLinesFromFile();

            //Assert
            for (int i = 0; i < results.Length; i++)
            {
                Assert.AreEqual(peopleStrings[i], results[i]);
            }
            mockWrapper.Verify(mock => mock.ReadAllLinesFromFile(k_filePath), Times.Once);
        }
    }
}
