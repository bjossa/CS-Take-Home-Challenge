using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CS_Take_Home_Challenge;
using NUnit.Framework;
using Moq;

namespace CsTakeHomeChallengeUnitTests.fileParsing
{
    [TestFixture]
    class PersonFileParserTests
    {
        public void LoadPeopleFromFile_ValidFileData_OutputsListOfPeople()
        {
            //Arrange

            string[] unparsedPeople =
                {
                "Gene,   679 Thurlow St,  7782396673, true",
                "Frond,  123 Main St,     6042391234, false"
                };
            var systemUnderTest = new PersonFileParser();

            //Act
            List<Person> result = systemUnderTest.LoadPeopleFromFile(null, unparsedPeople);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 2);
            Person person1 = result[0];
            Assert.AreEqual(person1.Name, "Gene");
            Assert.AreEqual(person1.Address, "679 Thurlow St");
            Assert.AreEqual(person1.Phone, "7782396673");
            Assert.AreEqual(person1.IsActive, true);

        }

        public void LoadPeopleFromFile_inValidFileData_ThrowsException()
        {
            //Arrange
            string filePath = "nonSenseString";
            var systemUnderTest = new PersonFileParser();

            //Act/Assert
            Assert.Throws(typeof(Exception), () => { systemUnderTest.LoadPeopleFromFile(filePath, null); });

        }
        public void LoadPeopleFromFile_inValidArguments_ThrowsException()
        {
            //Arrange
            var systemUnderTest = new PersonFileParser();

            //Act/Assert
            Assert.Throws(typeof(Exception), () => { systemUnderTest.LoadPeopleFromFile(null, null); });
        }

        public void ToPersonValidTest()
        {
            //Arrange
            string personString = "Gene,   679 Thurlow St,  7782396673, true";
            var systemUnderTest = new PersonFileParser();

            //Act
            Person result = systemUnderTest.ToPerson(personString);

            //Assert
            Assert.AreEqual(result.Name, "Gene");
            Assert.AreEqual(result.Address, "679 Thurlow St");
            Assert.AreEqual(result.Phone, "7782396673");
            Assert.AreEqual(result.IsActive, true);

        }

        public void ToPersonInvalidShouldThrowException()
        {
            //Arrange
            string personString1 = "Gene,   679 Thurlow St,  7782396673 true";
            string personString2 = "Gene,   679 Thurlow St,  7782396673, randomString";
            var systemUnderTest = new PersonFileParser();

            //Act/Assert
            Assert.Throws(typeof(Exception), () => { systemUnderTest.ToPerson(personString1); });
            Assert.Throws(typeof(Exception), () => { systemUnderTest.ToPerson(personString2); });

        }
    }
}
