using CS_Take_Home_Challenge;
using CS_Take_Home_Challenge.DialogService;
using CS_Take_Home_Challenge.DialogService.Dialogs;
using CS_Take_Home_Challenge.Factory;
using CS_Take_Home_Challenge.fileCommunication;
using CS_Take_Home_Challenge.fileParsing;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CsTakeHomeChallengeTest.mainWindow
{
    [TestFixture]
    class MainWindowViewModelTests
    {
        private const string k_invalidFilePath = "notAFilePath";
        private const string k_validFilePath = "ValidFilePath";
        private const string k_fakePersonString = "FakePerson";
        private Mock<IPersonFactory> m_mockFactory;
        private Mock<IDialogService> m_mockDialogService;
        private Mock<IPersonParser> m_mockParser;
        private Mock<IFileProxy> m_mockFileProxy;
        private Mock<IPersonListViewModel> m_mockPersonListVM;
        private Mock<IFileWrapper> m_fileWrapper;

        [SetUp]
        public void SetUp()
        {
            m_mockFactory = new Mock<IPersonFactory>();
            m_mockDialogService = new Mock<IDialogService>();
            m_mockParser = new Mock<IPersonParser>();
            m_mockFileProxy = new Mock<IFileProxy>();
            m_mockPersonListVM = new Mock<IPersonListViewModel>();
            m_fileWrapper = new Mock<IFileWrapper>();
        }

        [Test]
        public void ConstructorTest_ActualParameters()
        {
            // Act
            var systemUnderTest = new MainWindowViewModel(m_mockDialogService.Object, null, m_mockParser.Object, m_mockFactory.Object, m_mockFileProxy.Object, m_fileWrapper.Object);

            //Assert
            Assert.IsNotNull(systemUnderTest.InputFilePathCommand);
            Assert.IsNotNull(systemUnderTest.DisplayAddPersonDialogueCommand);
            Assert.IsNotNull(systemUnderTest.DisplayEditPersonDialogueCommand);
            Assert.IsNotNull(systemUnderTest.RemovePersonCommand);
            Assert.IsFalse(systemUnderTest.HaveLoadedPeople);
        }

        [Test]
        public void ConstructorTest_NullParameters()
        {
            // Act
            var systemUnderTest = new MainWindowViewModel();

            //Assert
            Assert.IsNotNull(systemUnderTest.InputFilePathCommand);
            Assert.IsNotNull(systemUnderTest.DisplayAddPersonDialogueCommand);
            Assert.IsNotNull(systemUnderTest.DisplayEditPersonDialogueCommand);
            Assert.IsNotNull(systemUnderTest.RemovePersonCommand);
            Assert.IsNotNull(systemUnderTest.PersonListVM);
            Assert.IsFalse(systemUnderTest.HaveLoadedPeople);
        }

        [Test]
        public async Task LoadPeopleAsyncTest()
        {
            // Arrange
            var mockPerson1 = new Mock<IPerson>();
            var mockPerson2 = new Mock<IPerson>();
            List<IPerson> people = new List<IPerson> { mockPerson1.Object, mockPerson2.Object };
            var mockPersonVM1 = new Mock<IPersonViewModel>();
            var mockPersonVM2 = new Mock<IPersonViewModel>();
            ObservableCollection<IPersonViewModel> peopleVMs = new ObservableCollection<IPersonViewModel> { mockPersonVM1.Object, mockPersonVM2.Object };
            m_mockFactory.Setup(mock => mock.CreatePeopleViewModels(people)).Returns(peopleVMs).Verifiable();
            string[] fakePeopleStrings = new string[] { k_fakePersonString };
            m_mockFileProxy.Setup(mock => mock.ReadLinesFromFile()).Returns(fakePeopleStrings).Verifiable();
            m_mockParser.Setup(mock => mock.ParseStringsToPeople(fakePeopleStrings)).Returns(people).Verifiable();
            m_mockPersonListVM.Setup(mock => mock.populatePeople(peopleVMs)).Verifiable();
            var systemUnderTest = new MainWindowViewModel(null
                , m_mockPersonListVM.Object
                , m_mockParser.Object
                , m_mockFactory.Object
                , m_mockFileProxy.Object);

            //Act
            await systemUnderTest.LoadPeopleAsync();

            // Assert
            m_mockFileProxy.Verify(x => x.ReadLinesFromFile(), Times.Once);
            m_mockFactory.Verify(mock => mock.CreatePeopleViewModels(people), Times.Once);
            m_mockParser.Verify(mock => mock.ParseStringsToPeople(fakePeopleStrings), Times.Once);
            m_mockPersonListVM.Verify(mock => mock.populatePeople(peopleVMs), Times.Once);
            Assert.IsTrue(systemUnderTest.HaveLoadedPeople);
        }

        [Test]
        public void OpenFileCommunication_ValidFilePath()
        {
            //Arrange
            m_fileWrapper.Setup(mock => mock.FileExists(It.IsAny<string>())).Returns(true);
            var systemUnderTest = new MainWindowViewModel(wrapper: m_fileWrapper.Object);

            //Act
            bool result = systemUnderTest.OpenFileCommunication(k_validFilePath);

            //Assert
            Assert.IsTrue(result);
            m_fileWrapper.Verify(mock => mock.FileExists(k_validFilePath), Times.Once);
        }

        [Test]
        public void OpenFileCommunication_InvalidFilePath()
        {
            //Arrange
            m_fileWrapper.Setup(mock => mock.FileExists(It.IsAny<string>())).Returns(false);
            var systemUnderTest = new MainWindowViewModel(wrapper: m_fileWrapper.Object);

            //Act
            bool result = systemUnderTest.OpenFileCommunication(k_invalidFilePath);

            //Assert
            Assert.IsFalse(result);
            m_fileWrapper.Verify(mock => mock.FileExists(k_invalidFilePath), Times.Once);
        }

        [Test]
        public void DisplayAddPersonDialogTest_AddedTest()
        {
            // Arrange
            var systemUnderTest = new MainWindowViewModel(m_mockDialogService.Object, m_mockPersonListVM.Object);
            m_mockDialogService.Setup(mock => mock.ShowDialog(It.IsAny<AddPersonDialogueViewModel>())).Returns(true).Verifiable();
            m_mockPersonListVM.Setup(mock => mock.AddPersonViewModel(It.IsAny<PersonViewModel>())).Verifiable();

            //Act
            systemUnderTest.DisplayAddPersonDialogue(null);

            //Assert
            m_mockDialogService.Verify(mock => mock.ShowDialog(It.IsAny<AddPersonDialogueViewModel>()), Times.Once);
            m_mockPersonListVM.Verify(mock => mock.AddPersonViewModel(It.IsAny<PersonViewModel>()), Times.Once);

        }

        [Test]
        public void DisplayAddPersonDialogTest_CancelledTest()
        {
            // Arrange
            var systemUnderTest = new MainWindowViewModel(m_mockDialogService.Object, m_mockPersonListVM.Object);
            m_mockDialogService.Setup(mock => mock.ShowDialog(It.IsAny<AddPersonDialogueViewModel>())).Returns(false).Verifiable();
            m_mockPersonListVM.Setup(mock => mock.AddPersonViewModel(It.IsAny<PersonViewModel>())).Verifiable();

            //Act
            systemUnderTest.DisplayAddPersonDialogue(null);

            //Assert
            m_mockDialogService.Verify(mock => mock.ShowDialog(It.IsAny<AddPersonDialogueViewModel>()), Times.Once);
            m_mockPersonListVM.Verify(mock => mock.AddPersonViewModel(It.IsAny<PersonViewModel>()), Times.Never);
        }

        [Test]
        public void DisplayEditPersonDialogTest()
        {
            // Arrange
            var systemUnderTest = new MainWindowViewModel(m_mockDialogService.Object);
            var mockPersonViewModel = new Mock<IPersonViewModel>();
            mockPersonViewModel.Setup(mock => mock.Name).Returns("");
            mockPersonViewModel.Setup(mock => mock.Address).Returns("");
            mockPersonViewModel.Setup(mock => mock.Phone).Returns("");
            mockPersonViewModel.Setup(mock => mock.IsActive).Returns(true);
            systemUnderTest.SelectedPerson = mockPersonViewModel.Object;
            m_mockDialogService.Setup(mock => mock.ShowDialog(It.IsAny<EditPersonDialogueViewModel>())).Verifiable();

            //Act
            systemUnderTest.DisplayEditPersonDialogue(null);

            //Assert
            m_mockDialogService.Verify(mock => mock.ShowDialog(It.IsAny<EditPersonDialogueViewModel>()), Times.Once);
        }

        [Test]
        public void CanRemovePersonTest_SelectedPersonIsNull()
        {
            var systemUnderTest = new MainWindowViewModel();
            bool result = systemUnderTest.CanRemovePerson(null);
            Assert.IsFalse(result);
        }

        [Test]
        public void CanRemovePersonTest_SelectedPersonIsNotNull()
        {
            // Arrange
            var systemUnderTest = new MainWindowViewModel();
            var mockPersonViewModel = new Mock<IPersonViewModel>();
            systemUnderTest.SelectedPerson = mockPersonViewModel.Object;

            //Act
            bool result = systemUnderTest.CanRemovePerson(null);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanDisplayEditPersonDialogTest_SelectedPersonIsNull()
        {
            var systemUnderTest = new MainWindowViewModel();
            bool result = systemUnderTest.CanDisplayEditPersonDialogue(null);
            Assert.IsFalse(result);
        }

        [Test]
        public void CanDisplayEditPersonDialogTest_SelectedPersonIsNotActive()
        {
            // Arrange
            var systemUnderTest = new MainWindowViewModel();
            var mockPersonViewModel = new Mock<IPersonViewModel>();
            mockPersonViewModel.Setup(mock => mock.IsActive).Returns(false);
            systemUnderTest.SelectedPerson = mockPersonViewModel.Object;

            //Act
            bool result = systemUnderTest.CanDisplayEditPersonDialogue(null);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CanDisplayEditPersonDialogTest_SelectedPersonIsActive()
        {
            // Arrange
            var systemUnderTest = new MainWindowViewModel();
            var mockPersonViewModel = new Mock<IPersonViewModel>();
            mockPersonViewModel.Setup(mock => mock.IsActive).Returns(true);
            systemUnderTest.SelectedPerson = mockPersonViewModel.Object;

            //Act
            bool result = systemUnderTest.CanDisplayEditPersonDialogue(null);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RemovePersonTest()
        {
            //Arrange
            var mockPersonViewModel = new Mock<IPersonViewModel>();
            var systemUnderTest = new MainWindowViewModel(null, m_mockPersonListVM.Object);
            systemUnderTest.SelectedPerson = mockPersonViewModel.Object;
            m_mockPersonListVM.Setup(mock => mock.RemovePersonViewModel(mockPersonViewModel.Object)).Verifiable();

            // Act
            systemUnderTest.RemovePerson(null);

            //Assert
            m_mockPersonListVM.Verify(mock => mock.RemovePersonViewModel(mockPersonViewModel.Object), Times.Once);
        }
    }
}
