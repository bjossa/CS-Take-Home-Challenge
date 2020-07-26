using CS_Take_Home_Challenge;
using Moq;
using NUnit.Framework;
using System;

namespace CsTakeHomeChallengeTest.People
{
    [TestFixture]
    class PersonViewModelTests
    {
        private const string k_personName = "testName";
        private const string k_personAddress = "testAddress";
        private const string k_personPhone = "testPhone";
        private const bool k_personIsActive = true;

        [Test]
        public void Constructor_Test()
        {
            //Arrange
            var mockPerson = new Mock<IPerson>();
            mockPerson.SetupGet(mock => mock.Name).Returns(k_personName);
            mockPerson.SetupGet(mock => mock.Address).Returns(k_personAddress);
            mockPerson.SetupGet(mock => mock.Phone).Returns(k_personPhone);
            mockPerson.SetupGet(mock => mock.IsActive).Returns(k_personIsActive);

            //Act
            var systemUnderTest = new PersonViewModel(mockPerson.Object);

            //Assert
            Assert.AreEqual(k_personName, systemUnderTest.Name);
            Assert.AreEqual(k_personAddress, systemUnderTest.Address);
            Assert.AreEqual(k_personPhone, systemUnderTest.Phone);
            Assert.AreEqual(k_personIsActive, systemUnderTest.IsActive);
        }

        [TestCase("Name")]
        [TestCase("Address")]
        [TestCase("Phone")]
        [TestCase("IsActive")]
        public void PropertyGetSetTest(String propertyName)
        {
            var mockPerson = new Mock<IPerson>();
            mockPerson.SetupAllProperties();
            var systemUnderTest = new PersonViewModel(mockPerson.Object);
            switch (propertyName)
            {
                case "Name":
                    systemUnderTest.Name = k_personName;
                    Assert.AreEqual(k_personName, systemUnderTest.Name);
                    break;
                case "Address":
                    systemUnderTest.Address = k_personAddress;
                    Assert.AreEqual(k_personAddress, systemUnderTest.Address);
                    break;
                case "Phone":
                    systemUnderTest.Phone = k_personPhone;
                    Assert.AreEqual(k_personPhone, systemUnderTest.Phone);
                    break;
                case "IsActive":
                    systemUnderTest.IsActive = k_personIsActive;
                    Assert.AreEqual(k_personIsActive, systemUnderTest.IsActive);
                    break;
            }
        }
    }
}
