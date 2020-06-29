using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CS_Take_Home_Challenge
{
    //todo: should this class be an observable collection itself?
    public class PersonListViewModel : IPersonListViewModel
    {
        #region Private Fields
        private Visibility m_arePeopleVisible = Visibility.Hidden;
        #endregion

        #region Constructors
        public PersonListViewModel(ObservableCollection<IPersonViewModel> people = null)
        {
            People = people ?? new ObservableCollection<IPersonViewModel>();
            LoadCommands_();
        }
        #endregion

        #region Properties
        public Visibility ArePeopleVisible
        {
            get => m_arePeopleVisible;
            set
            {
                m_arePeopleVisible = value;
                RaisePropertyChanged_("ArePeopleVisible"); //todo: test that this was raised? (subscribe in test class?)
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Dependency Properties
        #endregion

        #region Commands
        public ICommand ShowPeopleCommand { get; set; }
        #endregion

        #region Public Methods
        public bool CanShowPeople(object obj)
        {
            bool arePeopleVisible = ArePeopleVisible == Visibility.Visible;
            bool havePeople = People.Count > 0;

            return !arePeopleVisible && havePeople;
        }

        public void ShowPeople(object obj)
        {
            ArePeopleVisible = Visibility.Visible;
        }
        #endregion

        #region Private Methods

        private void LoadCommands_()
        {
            ShowPeopleCommand = new CustomCommand(ShowPeople, CanShowPeople);
        }

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
        // todo: what happens when this person isn't present?
        public void RemovePersonViewModel(IPersonViewModel personVM)
        {
            if (People.Contains(personVM))
            {
                People.Remove(personVM);
            }
        }

        // todo: should this change the visibility of the people?
        public void populatePeople(ObservableCollection<IPersonViewModel> peopleVMs)
        {
            People.Clear(); //todo: does this work, and should we be calling RemovePersonViewModel?
            foreach (var personViewModel in peopleVMs)
            {
                AddPersonViewModel(personViewModel);
            }
        }

        #endregion

        #endregion
    }
}
