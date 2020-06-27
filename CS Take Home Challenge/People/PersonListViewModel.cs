﻿using System;
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
    class PersonListViewModel : IPersonListViewModel
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
                RaisePropertyChanged_("ArePeopleVisible");
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
        #endregion

        #region Private Methods

        private void LoadCommands_()
        {
            ShowPeopleCommand = new CustomCommand(ShowPeople_, CanShowPeople_);
        }
        private bool CanShowPeople_(object obj)
        {
            bool arePeopleVisible = ArePeopleVisible == Visibility.Visible;
            bool haveLoadedPeople = People != null;

            return !arePeopleVisible && haveLoadedPeople;
        }

        private void ShowPeople_(object obj)
        {
            ArePeopleVisible = Visibility.Visible;
        }

        private void RaisePropertyChanged_(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Specific Interface Implementation

        #region Implementation of <IPersonListViewModel>

        public ObservableCollection<IPersonViewModel> People { get; set; }
        public void AddPersonViewModel(IPersonViewModel personVM)
        {

        }
        public void RemovePersonViewModel(IPersonViewModel personVM)
        {

        }

        public void populatePeople(ObservableCollection<IPersonViewModel> peopleVMs)
        {

        }

        #endregion

        #endregion
    }
}
