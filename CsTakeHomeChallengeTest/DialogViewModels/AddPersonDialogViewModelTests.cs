using CS_Take_Home_Challenge;
using CS_Take_Home_Challenge.DialogService;
using CS_Take_Home_Challenge.DialogService.Dialogs;
using CS_Take_Home_Challenge.Factory;
using Moq;
using NUnit.Framework;

namespace CsTakeHomeChallengeTest.DialogViewModels
{
    [TestFixture]
    class AddPersonDialogViewModelTests
    {

        private DialogCloseRequestedEventArgs testEventArgs;
        private const string k_emptyString = "";

        [Test]
        public void Constructor_Test()
        {
            //Act
            var systemUnderTest = new AddPersonDialogueViewModel();

            //Assert
            Assert.AreEqual("", systemUnderTest.Name);
            Assert.AreEqual("", systemUnderTest.Address);
            Assert.AreEqual("", systemUnderTest.Phone);
            Assert.AreEqual(true, systemUnderTest.IsActive);
            Assert.IsNotNull(systemUnderTest.AddPersonCommand);
            Assert.IsNotNull(systemUnderTest.CancelAddPersonCommand);
        }

        [Test]
        public void AddPerson_AddedPersonViewModelShouldBeCorrect()
        {

            // Arrange
            var mockFactory = new Mock<IPersonFactory>();
            var systemUnderTest = new AddPersonDialogueViewModel(mockFactory.Object);
            var mockPerson = new Mock<IPerson>();
            mockFactory.Setup(mock => mock.CreatePerson(k_emptyString, k_emptyString, k_emptyString, true)).Returns(mockPerson.Object).Verifiable();
            var mockPersonViewModel = new Mock<IPersonViewModel>();
            mockFactory.Setup(mock => mock.CreatePersonViewModel(mockPerson.Object)).Returns(mockPersonViewModel.Object);
            systemUnderTest.CloseRequested += TestEventHandler;

            //Act
            systemUnderTest.AddPerson(null);

            //Assert
            Assert.AreEqual(mockPersonViewModel.Object, systemUnderTest.AddedPersonViewModel);
            mockFactory.Verify(mock => mock.CreatePerson(k_emptyString, k_emptyString, k_emptyString, true), Times.Once);
            mockFactory.Verify(mock => mock.CreatePersonViewModel(mockPerson.Object), Times.Once);
            Assert.IsNotNull(testEventArgs);
            Assert.AreEqual(true, testEventArgs.DialogResult);
        }

        [Test]
        public void CancelAddPerson_AddedPersonViewModelShouldBeNull()
        {
            // Arrange
            var systemUnderTest = new AddPersonDialogueViewModel();
            systemUnderTest.CloseRequested += TestEventHandler;

            //Act
            systemUnderTest.CancelAddPerson(null);

            //Assert
            Assert.IsNull(systemUnderTest.AddedPersonViewModel);
            Assert.IsNotNull(testEventArgs);
            Assert.AreEqual(false, testEventArgs.DialogResult);
        }

        private void TestEventHandler(object sender, DialogCloseRequestedEventArgs e)
        {
            testEventArgs = e;
        }

    }
}
