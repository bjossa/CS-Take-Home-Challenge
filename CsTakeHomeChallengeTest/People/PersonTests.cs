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
        [Test]
        public void Constructor_Test()
        {
            // Arrange

            // Act
            var systemUnderTest = new Person("Eric", "1111 Sample Street", "6042222222", true);

            //Assert
            Assert.AreEqual(systemUnderTest.Name, "Eric");
            Assert.AreEqual(systemUnderTest.Address, "1111 Sample Street");
            Assert.AreEqual(systemUnderTest.Phone, "6042222222");
            Assert.AreEqual(systemUnderTest.IsActive, true);

        }
    }
}
