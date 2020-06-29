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
    class PersonViewModelTests
    {
        private string k_personName = "name";
        private string k_personAddress = "address";
        private string k_personPhone = "phone";
        private bool k_personIsActive = true;
        private Mock<Person> m_mockPerson;

        [SetUp]
        public void SetUp()
        {
            m_mockPerson = new Mock<Person>();
            m_mockPerson.SetupGet(mock => mock.Name).Returns(k_personName);
            m_mockPerson.SetupGet(mock => mock.Address).Returns(k_personAddress);
            m_mockPerson.SetupGet(mock => mock.Phone).Returns(k_personPhone);
            m_mockPerson.SetupGet(mock => mock.IsActive).Returns(k_personIsActive);
        }

        [TestCase("Name")]
        [TestCase("Address")]
        [TestCase("Phone")]
        [TestCase("IsActive")]
        public void PropertyGetSetTest(String propertyName)
        {
            var systemUnderTest = new PersonViewModel(m_mockPerson.Object);
            switch (propertyName)
            {
                case "Name":
                    systemUnderTest.GetType().GetProperty(propertyName).SetValue(systemUnderTest, k_personName);
                    Assert.AreEqual(systemUnderTest.GetType().GetProperty(propertyName).GetValue(systemUnderTest), k_personName);
                    break;
                case "Address":
                    systemUnderTest.GetType().GetProperty(propertyName).SetValue(systemUnderTest, k_personAddress);
                    Assert.AreEqual(systemUnderTest.GetType().GetProperty(propertyName).GetValue(systemUnderTest), k_personAddress);
                    break;
                case "Phone":
                    systemUnderTest.GetType().GetProperty(propertyName).SetValue(systemUnderTest, k_personPhone);
                    Assert.AreEqual(systemUnderTest.GetType().GetProperty(propertyName).GetValue(systemUnderTest), k_personPhone);
                    break;
                case "IsActive":
                    systemUnderTest.GetType().GetProperty(propertyName).SetValue(systemUnderTest, k_personIsActive);
                    Assert.AreEqual(systemUnderTest.GetType().GetProperty(propertyName).GetValue(systemUnderTest), k_personIsActive);
                    break;
            }
        }
    }
}
