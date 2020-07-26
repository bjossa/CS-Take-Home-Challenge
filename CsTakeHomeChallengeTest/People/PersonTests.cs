using CS_Take_Home_Challenge;
using NUnit.Framework;

namespace CsTakeHomeChallengeTest.People
{
    [TestFixture]
    class PersonTests
    {
        private const string k_personName = "Gene";
        private const string k_personAddress = "679 Thurlow St";
        private const string k_personPhone = "7782396673";
        private const bool k_personIsActive = true;

        [Test]
        public void Constructor_Test()
        {
            // Act
            var systemUnderTest = new Person(k_personName
            , k_personAddress
            , k_personPhone
            , k_personIsActive);

            //Assert
            Assert.AreEqual(k_personName, systemUnderTest.Name);
            Assert.AreEqual(k_personAddress, systemUnderTest.Address);
            Assert.AreEqual(k_personPhone, systemUnderTest.Phone);
            Assert.AreEqual(k_personIsActive, systemUnderTest.IsActive);
        }
    }
}
