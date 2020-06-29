using CS_Take_Home_Challenge;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsTakeHomeChallengeTest.People
{
    [TestFixture]
    class PersonViewModelTests
    {
        private string k_personName = "testName";
        private string k_personAddress = "testAddress";
        private string k_personPhone = "testPhone";
        private bool k_personIsActive = true;
        private Mock<Person> m_mockPerson;

        private const string k_propertyName = "Name";
        private const string k_propertyAddress = "Address";
        private const string k_propertyPhone = "Phone";
        private const string k_propertyIsActive = "IsActive";


        [SetUp]
        public void SetUp()
        {
            m_mockPerson = new Mock<Person>();
            m_mockPerson.SetupGet(mock => mock.Name).Returns(k_personName);
            m_mockPerson.SetupGet(mock => mock.Address).Returns(k_personAddress);
            m_mockPerson.SetupGet(mock => mock.Phone).Returns(k_personPhone);
            m_mockPerson.SetupGet(mock => mock.IsActive).Returns(k_personIsActive);
        }

        [Test]
        [TestCase("Name")]
        [TestCase("Address")]
        [TestCase("Phone")]
        [TestCase("IsActive")]
        public void PropertyGetSetTest(String propertyName)
        {
            var systemUnderTest = new PersonViewModel(m_mockPerson.Object);
            switch (propertyName)
            {
                case k_propertyName:
                    systemUnderTest.GetType().GetProperty(propertyName).SetValue(systemUnderTest, k_personName);
                    Assert.AreEqual(systemUnderTest.GetType().GetProperty(propertyName).GetValue(systemUnderTest), k_personName);
                    break;
                case k_propertyAddress:
                    systemUnderTest.GetType().GetProperty(propertyName).SetValue(systemUnderTest, k_personAddress);
                    Assert.AreEqual(systemUnderTest.GetType().GetProperty(propertyName).GetValue(systemUnderTest), k_personAddress);
                    break;
                case k_propertyPhone:
                    systemUnderTest.GetType().GetProperty(propertyName).SetValue(systemUnderTest, k_personPhone);
                    Assert.AreEqual(systemUnderTest.GetType().GetProperty(propertyName).GetValue(systemUnderTest), k_personPhone);
                    break;
                case k_propertyIsActive:
                    systemUnderTest.GetType().GetProperty(propertyName).SetValue(systemUnderTest, k_personIsActive);
                    Assert.AreEqual(systemUnderTest.GetType().GetProperty(propertyName).GetValue(systemUnderTest), k_personIsActive);
                    break;
            }
        }
    }
}
