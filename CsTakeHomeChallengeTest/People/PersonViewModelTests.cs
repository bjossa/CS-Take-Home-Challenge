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

        private const string k_propertyName = "Name";
        private const string k_propertyAddress = "Address";
        private const string k_propertyPhone = "Phone";
        private const string k_propertyIsActive = "IsActive";

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
            var systemUnderTest = new PersonViewModel(mockPerson.Object);
            switch (propertyName)
            {
                case k_propertyName:
                    systemUnderTest.GetType().GetProperty(propertyName).SetValue(systemUnderTest, k_personName);
                    Assert.AreEqual(k_personName, systemUnderTest.GetType().GetProperty(propertyName).GetValue(systemUnderTest));
                    break;
                case k_propertyAddress:
                    systemUnderTest.GetType().GetProperty(propertyName).SetValue(systemUnderTest, k_personAddress);
                    Assert.AreEqual(k_personAddress, systemUnderTest.GetType().GetProperty(propertyName).GetValue(systemUnderTest));
                    break;
                case k_propertyPhone:
                    systemUnderTest.GetType().GetProperty(propertyName).SetValue(systemUnderTest, k_personPhone);
                    Assert.AreEqual(k_personPhone, systemUnderTest.GetType().GetProperty(propertyName).GetValue(systemUnderTest));
                    break;
                case k_propertyIsActive:
                    systemUnderTest.GetType().GetProperty(propertyName).SetValue(systemUnderTest, k_personIsActive);
                    Assert.AreEqual(k_personIsActive, systemUnderTest.GetType().GetProperty(propertyName).GetValue(systemUnderTest));
                    break;
            }
        }
    }
}
