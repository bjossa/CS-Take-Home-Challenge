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
    [TestFixture]
    class PersonFactoryTests
    {
        private string k_personName = "name";
        private string k_personAddress = "address";
        private string k_personPhone = "phone";
        private bool k_personIsActive = true;
        private Mock<IPerson> m_mockPerson;

        [SetUp]
        public void SetUp()
        {
            m_mockPerson = new Mock<IPerson>();
            m_mockPerson.SetupGet(mock => mock.Name).Returns(k_personName);
            m_mockPerson.SetupGet(mock => mock.Address).Returns(k_personAddress);
            m_mockPerson.SetupGet(mock => mock.Phone).Returns(k_personPhone);
            m_mockPerson.SetupGet(mock => mock.IsActive).Returns(k_personIsActive);
        }

        [Test]
        public void CreatePeopleViewModelsTest()
        {
            //Arrange
            var systemUnderTest = new PersonFactory();
            List<IPerson> people = new List<IPerson>() { m_mockPerson.Object };

            //Act
            ObservableCollection<IPersonViewModel> results = systemUnderTest.CreatePeopleViewModels(people);

            //Assert
            Assert.IsNotNull(results);
            IPersonViewModel personVM = results[0];
            Assert.AreEqual(personVM.Name, k_personName);
            Assert.AreEqual(personVM.Address, k_personAddress);
            Assert.AreEqual(personVM.Phone, k_personPhone);
            Assert.AreEqual(personVM.IsActive, k_personIsActive);
        }

        [Test]
        public void CreatePersonTest()
        {
            //Arrange
            var systemUnderTest = new PersonFactory();

            //Act
            IPerson result = systemUnderTest.CreatePerson(k_personName, k_personAddress, k_personPhone, k_personIsActive);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Name, k_personName);
            Assert.AreEqual(result.Address, k_personAddress);
            Assert.AreEqual(result.Phone, k_personPhone);
            Assert.AreEqual(result.IsActive, k_personIsActive);
        }

        [Test]
        public void CreatePersonViewModelTest()
        {
            //Arrange
            var systemUnderTest = new PersonFactory();

            //Act
            IPersonViewModel result = systemUnderTest.CreatePersonViewModel(m_mockPerson.Object);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Name, k_personName);
            Assert.AreEqual(result.Address, k_personAddress);
            Assert.AreEqual(result.Phone, k_personPhone);
            Assert.AreEqual(result.IsActive, k_personIsActive);
        }
    }
}
