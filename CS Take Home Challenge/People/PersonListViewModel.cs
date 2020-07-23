using CS_Take_Home_Challenge.DialogService;
using CS_Take_Home_Challenge.DialogService.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace CS_Take_Home_Challenge
{
    public class PersonListViewModel : IPersonListViewModel
    {
        #region Private Fields
        #endregion

        #region Constructors
        public PersonListViewModel(ObservableCollection<IPersonViewModel> people = null)
        {
            People = people ?? new ObservableCollection<IPersonViewModel>();
        }
        #endregion

        #region Properties

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Dependency Properties
        #endregion

        #region Commands
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods

        private void RaisePropertyChanged_(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Specific Interface Implementation

        #region Implementation of <IPersonListViewModel>

        public ObservableCollection<IPersonViewModel> People { get; set; }

        public void AddPersonViewModel(IPersonViewModel personVM)
        {
            People.Add(personVM);
        }

        public void RemovePersonViewModel(IPersonViewModel personVM)
        {
            if (People.Contains(personVM))
            {
                People.Remove(personVM);
            }
        }

        public void populatePeople(ObservableCollection<IPersonViewModel> peopleVMs)
        {
            People.Clear();
            foreach (var personViewModel in peopleVMs)
            {
                AddPersonViewModel(personViewModel);
            }
        }

        #endregion

        #endregion
    }
}
