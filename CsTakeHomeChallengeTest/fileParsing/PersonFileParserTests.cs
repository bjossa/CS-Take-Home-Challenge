using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Take_Home_Challenge;
using NUnit.Framework;
using Moq;

namespace CsTakeHomeChallengeTest.fileParsing
{
    [TestFixture]
    class PersonFileParserTests
    {
        private const string k_personString1 = "Gene,   679 Thurlow St,  7782396673, true";
        private const string k_personString2 = "Frond,  123 Main St,     6042391234, false";
        private const string k_personName = "Gene";
        private const string k_personAddress = "679 Thurlow St";
        private const string k_personPhone = "7782396673";
        private const bool k_personIsActive = true;
        private const string k_filePath = "nonSenseString";
        private const string k_personStringInvalidNoBool = "Gene,   679 Thurlow St,  7782396673, randomString";
        private const string k_personStringInvalidMissingComma = "Gene,   679 Thurlow St,  7782396673 true";


        [Test]
        public void LoadPeopleFromFile_ValidFileData_OutputsListOfPeople()
        {
            //Arrange

            string[] unparsedPeople =
                {
                k_personString1,
                k_personString2,
                };
            var systemUnderTest = new PersonParser();

            //Act
            List<Person> result = systemUnderTest.LoadPeopleFromFile(null, unparsedPeople);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 2);
            Person person1 = result[0];
            Assert.AreEqual(person1.Name, k_personName);
            Assert.AreEqual(person1.Address, k_personAddress);
            Assert.AreEqual(person1.Phone, k_personPhone);
            Assert.AreEqual(person1.IsActive, k_personIsActive);

        }

        [Test]
        public void LoadPeopleFromFile_inValidFileData_ThrowsException()
        {
            //Arrange
            var systemUnderTest = new PersonParser();

            //Act/Assert
            Assert.Throws(typeof(FileCommunicationException ), () => { systemUnderTest.LoadPeopleFromFile(k_filePath, null); });

        }
        [Test]
        public void LoadPeopleFromFile_inValidArguments_ThrowsException()
        {
            //Arrange
            var systemUnderTest = new PersonParser();

            //Act/Assert
            Assert.Throws(typeof(FileCommunicationException ), () => { systemUnderTest.LoadPeopleFromFile(null, null); });
        }

        [Test]
        public void ToPersonValidTest()
        {
            //Arrange
            var systemUnderTest = new PersonParser();

            //Act
            Person result = systemUnderTest.ToPerson(k_personString1);

            //Assert
            Assert.AreEqual(result.Name, k_personName);
            Assert.AreEqual(result.Address, k_personAddress);
            Assert.AreEqual(result.Phone, k_personPhone);
            Assert.AreEqual(result.IsActive, k_personIsActive);
        }

        [Test]
        public void ToPersonInvalidShouldThrowException()
        {
            //Arrange
            var systemUnderTest = new PersonParser();

            //Act/Assert
            Assert.Throws(typeof(FileCommunicationException ), () => { systemUnderTest.ToPerson(k_personStringInvalidMissingComma); });
            Assert.Throws(typeof(FileCommunicationException ), () => { systemUnderTest.ToPerson(k_personStringInvalidNoBool); });
        }
    }
}
