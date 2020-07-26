using CS_Take_Home_Challenge;
using CS_Take_Home_Challenge.Factory;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CsTakeHomeChallengeTest
{
    [TestFixture]
    class PersonParserTests
    {
        private const string k_personString = "Gene,   679 Thurlow St,  7782396673, true";
        private const string k_personString2 = "Frond,  123 Main St,     6042391234, false";
        private const string k_personName = "Gene";
        private const string k_personAddress = "679 Thurlow St";
        private const string k_personPhone = "7782396673";
        private const bool k_personIsActive = true;
        private const string k_personName2 = "Frond";
        private const string k_personAddress2 = "123 Main St";
        private const string k_personPhone2 = "6042391234";
        private const bool k_personIsActive2 = false;
        private const string k_personStringInvalidNoBool = "Gene,   679 Thurlow St,  7782396673, randomString";
        private const string k_personStringInvalidMissingComma = "Gene,   679 Thurlow St,  7782396673 true";


        [Test]
        public void ParseStringsToPeople_ValidFileData_OutputsListOfPeople()
        {
            //Arrange
            var mockPerson1 = new Mock<IPerson>();
            var mockPerson2 = new Mock<IPerson>();
            var mockFactory = new Mock<IPersonFactory>();
            mockFactory.Setup(mock => mock.CreatePerson(k_personName, k_personAddress, k_personPhone, k_personIsActive)).Returns(mockPerson1.Object).Verifiable();
            mockFactory.Setup(mock => mock.CreatePerson(k_personName2, k_personAddress2, k_personPhone2, k_personIsActive2)).Returns(mockPerson2.Object).Verifiable();
            string[] unparsedPeople =
                {
                k_personString,
                k_personString2,
                };
            var systemUnderTest = new PersonParser(mockFactory.Object);

            //Act
            List<IPerson> result = systemUnderTest.ParseStringsToPeople(unparsedPeople);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(mockPerson1.Object, result[0]);
            Assert.AreEqual(mockPerson2.Object, result[1]);
            mockFactory.Verify(mock => mock.CreatePerson(k_personName, k_personAddress, k_personPhone, k_personIsActive), Times.Once);
            mockFactory.Verify(mock => mock.CreatePerson(k_personName2, k_personAddress2, k_personPhone2, k_personIsActive2), Times.Once);
        }

        [Test]
        public void ToPersonValidTest()
        {
            //Arrange
            var mockPerson = new Mock<IPerson>();
            var mockFactory = new Mock<IPersonFactory>();
            mockFactory.Setup(mock => mock.CreatePerson(k_personName, k_personAddress, k_personPhone, k_personIsActive)).Returns(mockPerson.Object).Verifiable();
            var systemUnderTest = new PersonParser(mockFactory.Object);

            //Act
            IPerson result = systemUnderTest.ToPerson(k_personString);

            //Assert
            Assert.AreEqual(mockPerson.Object, result);
            mockFactory.Verify(mock => mock.CreatePerson(k_personName, k_personAddress, k_personPhone, k_personIsActive), Times.Once);
        }

        [Test]
        public void ToPerson_InvalidString()
        {
            //Arrange
            var systemUnderTest = new PersonParser();

            //Act/Assert
            Assert.Throws(typeof(PeopleParsingException), () => { systemUnderTest.ToPerson(k_personStringInvalidMissingComma); });
            Assert.Throws(typeof(PeopleParsingException), () => { systemUnderTest.ToPerson(k_personStringInvalidNoBool); });
        }
    }
}
