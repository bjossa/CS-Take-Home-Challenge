using CS_Take_Home_Challenge;
using CS_Take_Home_Challenge.Factory;
using CS_Take_Home_Challenge.fileParsing;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsTakeHomeChallengeTest.mainWindow
{
    [TestFixture]
    class MainWindowViewModelTests
    {
        private const string k_filePath = "randomString";

        [Test]
        public void ConstructorTest()
        {
            var systemUnderTest = new MainWindowViewModel();
            Assert.IsNotNull(systemUnderTest.InputFilePathCommand);
        }

        [Test]
        public void InputFilePathTest()
        {
            //Arrange
            var factoryMock = new Mock<IPersonFactory>();
            var parserMock = new Mock<IPersonParser>();
            var personListVMMock = new Mock<IPersonListViewModel>();
            var mockPerson1 = new Mock<Person>();
            var mockPerson2 = new Mock<Person>();
            var mockPersonVM1 = new Mock<IPersonViewModel>();
            var mockPersonVM2 = new Mock<IPersonViewModel>();
            List<Person> mockPeople = new List<Person>(){ mockPerson1.Object, mockPerson2.Object };
            ObservableCollection<IPersonViewModel> mockPeopleVMs = new ObservableCollection<IPersonViewModel>() { mockPersonVM1.Object, mockPersonVM2.Object };

            var systemUnderTest = new MainWindowViewModel(personListVMMock.Object, parserMock.Object, factoryMock.Object);

            parserMock.Setup(mock => mock.LoadPeopleFromFile(k_filePath, null)).Returns(mockPeople).Verifiable();
            factoryMock.Setup(mock => mock.CreatePeopleViewModels(mockPeople)).Returns(mockPeopleVMs).Verifiable();
            personListVMMock.Setup(mock => mock.populatePeople(mockPeopleVMs)).Verifiable();

            //Act
            systemUnderTest.InputFileFromPath(k_filePath);

            //Assert
            parserMock.Verify(mock => mock.LoadPeopleFromFile(k_filePath, null), Times.Once);
            factoryMock.Verify(mock => mock.CreatePeopleViewModels(mockPeople), Times.Once);
            personListVMMock.Verify(mock => mock.populatePeople(mockPeopleVMs), Times.Once);
        }

        // todo: any unhappy paths to test?
	}
}
