using CS_Take_Home_Challenge;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CsTakeHomeChallengeTest.People
{
    class PersonListViewModelTests
    {
        private string k_personName = "name";
        private string k_personAddress = "address";
        private string k_personPhone = "phone";
        private string k_personName2 = "name2";
        private string k_personAddress2 = "address2";
        private string k_personPhone2 = "phone2";
        private Mock<PersonViewModel> m_mockPersonVM;

        [SetUp]
        public void SetUp()
        {
            m_mockPersonVM = new Mock<PersonViewModel>();
            m_mockPersonVM.SetupGet(mock => mock.Name).Returns(k_personName);
            m_mockPersonVM.SetupGet(mock => mock.Address).Returns(k_personAddress);
            m_mockPersonVM.SetupGet(mock => mock.Phone).Returns(k_personPhone);
            m_mockPersonVM.SetupGet(mock => mock.IsActive).Returns(true);
        }

        public void Constructor_Test()
        {
            var systemUnderTest = new PersonListViewModel();
            Assert.IsNotNull(systemUnderTest.People);
        }


        public void ArePeopleVisibleTest()
        {
            var systemUnderTest = new PersonListViewModel();
            systemUnderTest.ArePeopleVisible = Visibility.Visible;
            Assert.AreEqual(systemUnderTest.ArePeopleVisible, Visibility.Visible);
        }

        public void CanShowPeopleTrue()
        {
            //Arrange
            var systemUnderTest = new PersonListViewModel();
            systemUnderTest.AddPersonViewModel(m_mockPersonVM.Object);
            systemUnderTest.ArePeopleVisible = Visibility.Hidden;

            //Act
            bool result = systemUnderTest.CanShowPeople(null);

            //Assert
            Assert.IsTrue(result);
        }

        public void CanShowPeopleNoPersonReturnsFalse()
        {
            //Arrange
            var systemUnderTest = new PersonListViewModel();
            systemUnderTest.ArePeopleVisible = Visibility.Hidden;

            //Act
            bool result = systemUnderTest.CanShowPeople(null);

            //Assert
            Assert.IsFalse(result);
        }

        public void CanShowPeopleAlreadyVisibleReturnsFalse()
        {
            //Arrange
            var systemUnderTest = new PersonListViewModel();
            systemUnderTest.AddPersonViewModel(m_mockPersonVM.Object);
            systemUnderTest.ArePeopleVisible = Visibility.Visible;

            //Act
            bool result = systemUnderTest.CanShowPeople(null);

            //Assert
            Assert.IsFalse(result);
        }

        public void CanShowPeopleNoPeopleAndAlreadyVisibleReturnsFalse()
        {
            //Arrange
            var systemUnderTest = new PersonListViewModel();
            systemUnderTest.ArePeopleVisible = Visibility.Visible;

            //Act
            bool result = systemUnderTest.CanShowPeople(null);

            //Assert
            Assert.IsFalse(result);
        }

        public void AddPersonViewModelTest()
        {
            // Arrange
            var systemUnderTest = new PersonListViewModel();

            //Act
            systemUnderTest.AddPersonViewModel(m_mockPersonVM.Object);

            //Assert
            Assert.IsTrue(systemUnderTest.People.Contains(m_mockPersonVM.Object));
        }

        public void RemovePersonViewModelValidTest()
        {
            // Arrange
            var systemUnderTest = new PersonListViewModel();
            systemUnderTest.AddPersonViewModel(m_mockPersonVM.Object);

            //Act
            systemUnderTest.RemovePersonViewModel(m_mockPersonVM.Object);

            //Assert
            Assert.IsFalse(systemUnderTest.People.Contains(m_mockPersonVM.Object));
        }

        public void populatePeopleTest()
        {
            //Arrange
            var systemUnderTest = new PersonListViewModel();
            systemUnderTest.AddPersonViewModel(m_mockPersonVM.Object);

            // create another personViewModel
            var mockPersonVM2 = new Mock<PersonViewModel>();
            mockPersonVM2.SetupGet(mock => mock.Name).Returns(k_personName2);
            mockPersonVM2.SetupGet(mock => mock.Address).Returns(k_personAddress2);
            mockPersonVM2.SetupGet(mock => mock.Phone).Returns(k_personPhone2);
            mockPersonVM2.SetupGet(mock => mock.IsActive).Returns(true);

            ObservableCollection<IPersonViewModel> peopleVMs = new ObservableCollection<IPersonViewModel>() { mockPersonVM2.Object };

            //Act
            systemUnderTest.populatePeople(peopleVMs);

            //Assert
            Assert.IsFalse(systemUnderTest.People.Contains(m_mockPersonVM.Object));
            Assert.IsTrue(systemUnderTest.People.Contains(mockPersonVM2.Object));
        }
    }
}
