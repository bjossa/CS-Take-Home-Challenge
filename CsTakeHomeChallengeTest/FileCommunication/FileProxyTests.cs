using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Take_Home_Challenge;
using CS_Take_Home_Challenge.fileCommunication;
using NUnit.Framework;

namespace CsTakeHomeChallengeTest.FileCommunication
{
    [TestFixture]
    class FileProxyTests
    {
        private const string k_filePath = "C:\\Users\\Work\\Desktop\\Data.txt";

        [Test]
        public void ReadLinesFromFile_InvalidFilePath_ThrowsException()
        {
            var systemUnderTest = new FileProxy("notafilepath");
            Assert.Throws(typeof(FileCommunicationException), () => { systemUnderTest.ReadLinesFromFile(); });
        }

        [Test]
        public void ReadLinesFromFile_ValidFilePath()
        {
            // Arrange
            var systemUnderTest = new FileProxy(k_filePath);
            string[] expectedResults = new string[]
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

            //Act
            string[] results = systemUnderTest.ReadLinesFromFile();

            //Assert
            for (int i = 0; i < results.Length; i++)
            {
                Assert.AreEqual(expectedResults[i], results[i]);
            }
        }
    }
}
