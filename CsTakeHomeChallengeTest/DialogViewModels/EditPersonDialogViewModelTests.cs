using CS_Take_Home_Challenge;
using CS_Take_Home_Challenge.DialogService;
using CS_Take_Home_Challenge.DialogService.Dialogs;
using Moq;
using NUnit.Framework;

namespace CsTakeHomeChallengeTest.DialogViewModels
{
    [TestFixture]
    class EditPersonDialogViewModelTests
    {

        private DialogCloseRequestedEventArgs testEventArgs;
        private const string k_personName = "name";
        private const string k_personAddress = "address";
        private const string k_personPhone = "phone";
        private const bool k_personIsActive = true;
        private const string k_personName2 = "name2";
        private const string k_personAddress2 = "address2";
        private const string k_personPhone2 = "phone2";
        private const bool k_personIsActive2 = false;

        [Test]
        public void Constructor_Test()
        {
            // Arrange
            var mockPersonViewModel = new Mock<IPersonViewModel>();
            mockPersonViewModel.SetupGet(mock => mock.Name).Returns(k_personName);
            mockPersonViewModel.SetupGet(mock => mock.Address).Returns(k_personAddress);
            mockPersonViewModel.SetupGet(mock => mock.Phone).Returns(k_personPhone);
            mockPersonViewModel.SetupGet(mock => mock.IsActive).Returns(k_personIsActive);

            //Act
            var systemUnderTest = new EditPersonDialogueViewModel(mockPersonViewModel.Object);

            //Assert
            Assert.AreEqual(k_personName, systemUnderTest.Name);
            Assert.AreEqual(k_personAddress, systemUnderTest.Address);
            Assert.AreEqual(k_personPhone, systemUnderTest.Phone);
            Assert.AreEqual(k_personIsActive, systemUnderTest.IsActive);
            Assert.IsNotNull(systemUnderTest.ConfirmEditPersonCommand);
            Assert.IsNotNull(systemUnderTest.CancelEditPersonCommand);
        }

        [Test]
        public void ConfirmEditPerson_PersonViewModelShouldBeUpdated()
        {

            // Arrange
            var mockPersonViewModel = new Mock<IPersonViewModel>();
            mockPersonViewModel.SetupGet(mock => mock.Name).Returns(k_personName);
            mockPersonViewModel.SetupGet(mock => mock.Address).Returns(k_personAddress);
            mockPersonViewModel.SetupGet(mock => mock.Phone).Returns(k_personPhone);
            mockPersonViewModel.SetupGet(mock => mock.IsActive).Returns(k_personIsActive);
            mockPersonViewModel.SetupProperty(mock => mock.Name);
            mockPersonViewModel.SetupProperty(mock => mock.Address);
            mockPersonViewModel.SetupProperty(mock => mock.Phone);
            mockPersonViewModel.SetupProperty(mock => mock.IsActive);
            var systemUnderTest = new EditPersonDialogueViewModel(mockPersonViewModel.Object);
            systemUnderTest.Name = k_personName2;
            systemUnderTest.Address = k_personAddress2;
            systemUnderTest.Phone = k_personPhone2;
            systemUnderTest.IsActive = k_personIsActive2;
            systemUnderTest.CloseRequested += TestEventHandler;

            //Act
            systemUnderTest.ConfirmEditPerson(null);

            //Assert
            Assert.AreEqual(k_personName2, mockPersonViewModel.Object.Name);
            Assert.AreEqual(k_personAddress2, mockPersonViewModel.Object.Address);
            Assert.AreEqual(k_personPhone2, mockPersonViewModel.Object.Phone);
            Assert.AreEqual(k_personIsActive2, mockPersonViewModel.Object.IsActive);
            Assert.IsNotNull(testEventArgs);
            Assert.AreEqual(true, testEventArgs.DialogResult);
        }

        [Test]
        public void CancelEditPerson_PersonViewModelIsUnchanged()
        {
            // Arrange
            var mockPersonViewModel = new Mock<IPersonViewModel>();
            mockPersonViewModel.SetupGet(mock => mock.Name).Returns(k_personName);
            mockPersonViewModel.SetupGet(mock => mock.Address).Returns(k_personAddress);
            mockPersonViewModel.SetupGet(mock => mock.Phone).Returns(k_personPhone);
            mockPersonViewModel.SetupGet(mock => mock.IsActive).Returns(k_personIsActive);
            var systemUnderTest = new EditPersonDialogueViewModel(mockPersonViewModel.Object);
            systemUnderTest.Name = k_personName2;
            systemUnderTest.Address = k_personAddress2;
            systemUnderTest.Phone = k_personPhone2;
            systemUnderTest.IsActive = k_personIsActive2;
            systemUnderTest.CloseRequested += TestEventHandler;

            //Act
            systemUnderTest.CancelEditPerson(null);

            //Assert
            Assert.AreEqual(k_personName, mockPersonViewModel.Object.Name);
            Assert.AreEqual(k_personAddress, mockPersonViewModel.Object.Address);
            Assert.AreEqual(k_personPhone, mockPersonViewModel.Object.Phone);
            Assert.AreEqual(k_personIsActive, mockPersonViewModel.Object.IsActive);
            Assert.IsNotNull(testEventArgs);
            Assert.AreEqual(false, testEventArgs.DialogResult);
        }

        public void TestEventHandler(object sender, DialogCloseRequestedEventArgs e)
        {
            testEventArgs = e;
        }
    }
}