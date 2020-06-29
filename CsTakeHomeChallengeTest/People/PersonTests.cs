using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // Arrange

            // Act
            var systemUnderTest = new Person(k_personName
            , k_personAddress
            , k_personPhone
            , k_personIsActive);

            //Assert
            Assert.AreEqual(systemUnderTest.Name, k_personName);
            Assert.AreEqual(systemUnderTest.Address, k_personAddress);
            Assert.AreEqual(systemUnderTest.Phone, k_personPhone);
            Assert.AreEqual(systemUnderTest.IsActive, k_personIsActive);

        }
    }
}
