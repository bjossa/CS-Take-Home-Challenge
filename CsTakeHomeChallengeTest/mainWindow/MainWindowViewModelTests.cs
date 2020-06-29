using CS_Take_Home_Challenge;
using CS_Take_Home_Challenge.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsTakeHomeChallengeTest.mainWindow
{
    class MainWindowViewModelTests
    {

        public void ConstructorTest()
        {
            var systemUnderTest = new MainWindowViewModel();
            Assert.IsNotNull(systemUnderTest.InputFilePathCommand);
        }

        public void InputFilePathTest()
        {
            //Arrange
            var factoryMock = new Mock<PersonFactory>();
            var parserMock = new Mock<PersonFileParser>();
            var personListVMMock = new Mock<PersonListViewModel>();
            var mockPerson1 = new Mock<Person>();
            var mockPerson2 = new Mock<Person>();
            var mockPersonVM1 = new Mock<PersonViewModel>();
            var mockPersonVM2 = new Mock<PersonViewModel>();
            List<Person> mockPeople = new List<Person>(){ mockPerson1.Object, mockPerson2.Object };
            ObservableCollection<IPersonViewModel> mockPeopleVMs = new ObservableCollection<IPersonViewModel>() { mockPersonVM1.Object, mockPersonVM2.Object };
            string filePath = "randomString";

            var systemUnderTest = new MainWindowViewModel(personListVMMock.Object, parserMock.Object, factoryMock.Object);

            parserMock.Setup(mock => mock.LoadPeopleFromFile(filePath, null)).Returns(mockPeople).Verifiable();
            factoryMock.Setup(mock => mock.CreatePeopleViewModels(mockPeople)).Returns(mockPeopleVMs).Verifiable();
            personListVMMock.Setup(mock => mock.populatePeople(mockPeopleVMs)).Verifiable();

            //Act
            systemUnderTest.InputFileFromPath(filePath);

            //Assert
            parserMock.Verify(mock => mock.LoadPeopleFromFile(filePath, null), Times.Once);
            factoryMock.Verify(mock => mock.CreatePeopleViewModels(mockPeople), Times.Once);
            personListVMMock.Verify(mock => mock.populatePeople(mockPeopleVMs), Times.Once);
        }

        // todo: any unhappy paths to test?
	}
}
