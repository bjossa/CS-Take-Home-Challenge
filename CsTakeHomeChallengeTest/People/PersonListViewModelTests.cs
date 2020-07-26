using CS_Take_Home_Challenge;
using Moq;
using NUnit.Framework;
using System.Collections.ObjectModel;

namespace CsTakeHomeChallengeTest.People
{
    [TestFixture]
    class PersonListViewModelTests
    {
        private const string k_personName = "name";
        private const string k_personAddress = "address";
        private const string k_personPhone = "phone";
        private Mock<IPersonViewModel> m_mockPersonVM;

        [SetUp]
        public void SetUp()
        {
            m_mockPersonVM = new Mock<IPersonViewModel>();
            m_mockPersonVM.SetupGet(mock => mock.Name).Returns(k_personName);
            m_mockPersonVM.SetupGet(mock => mock.Address).Returns(k_personAddress);
            m_mockPersonVM.SetupGet(mock => mock.Phone).Returns(k_personPhone);
            m_mockPersonVM.SetupGet(mock => mock.IsActive).Returns(true);
        }

        [Test]
        public void Constructor_Test()
        {
            var systemUnderTest = new PersonListViewModel();
            Assert.IsNotNull(systemUnderTest.People);
        }

        [Test]
        public void AddPersonViewModelTest()
        {
            // Arrange
            var systemUnderTest = new PersonListViewModel();

            //Act
            systemUnderTest.AddPersonViewModel(m_mockPersonVM.Object);

            //Assert
            Assert.IsTrue(systemUnderTest.People.Contains(m_mockPersonVM.Object));
        }

        [Test]
        public void RemovePersonViewModelTest()
        {
            // Arrange
            var systemUnderTest = new PersonListViewModel();
            systemUnderTest.AddPersonViewModel(m_mockPersonVM.Object);

            //Act
            systemUnderTest.RemovePersonViewModel(m_mockPersonVM.Object);

            //Assert
            Assert.IsFalse(systemUnderTest.People.Contains(m_mockPersonVM.Object));
        }

        [Test]
        public void populatePeopleTest()
        {
            //Arrange
            var systemUnderTest = new PersonListViewModel();
            systemUnderTest.AddPersonViewModel(m_mockPersonVM.Object);

            // create another 3 personViewModels
            var mockPersonVM2 = new Mock<IPersonViewModel>();
            var mockPersonVM3 = new Mock<IPersonViewModel>();

            ObservableCollection<IPersonViewModel> peopleVMs = new ObservableCollection<IPersonViewModel>() { mockPersonVM2.Object, mockPersonVM3.Object };

            //Act
            systemUnderTest.populatePeople(peopleVMs);

            //Assert
            Assert.IsFalse(systemUnderTest.People.Contains(m_mockPersonVM.Object));
            Assert.IsTrue(systemUnderTest.People.Contains(mockPersonVM2.Object));
            Assert.IsTrue(systemUnderTest.People.Contains(mockPersonVM3.Object));
        }
    }
}
