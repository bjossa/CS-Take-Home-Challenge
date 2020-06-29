using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Take_Home_Challenge;
using CS_Take_Home_Challenge.Factory;
using Moq;
using NUnit.Framework;

namespace CsTakeHomeChallengeTest.factory
{
    class PersonFactoryTests
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

        public void CreatePeopleViewModelsTest()
        {
            //Arrange
            var systemUnderTest = new PersonFactory();
            List<Person> people = new List<Person>() { m_mockPerson.Object };

            //Act
            ObservableCollection<IPersonViewModel> results = systemUnderTest.CreatePeopleViewModels(people);

            //Assert
            IPersonViewModel personVM = results[0];
            Assert.AreEqual(personVM.Name, k_personName);
            Assert.AreEqual(personVM.Address, k_personAddress);
            Assert.AreEqual(personVM.Phone, k_personPhone);
            Assert.AreEqual(personVM.IsActive, k_personIsActive);
        }
    }
}
