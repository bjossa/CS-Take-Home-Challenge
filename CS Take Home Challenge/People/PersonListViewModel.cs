using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CS_Take_Home_Challenge
{
    class PersonListViewModel : IPersonListViewModel
    {
        #region Private Fields
        private Visibility m_arePeopleVisible = Visibility.Hidden;
        #endregion

        #region Constructors
        #endregion

        #region Properties
        public Visibility ArePeopleVisible
        {
            get => m_arePeopleVisible;
            set
            {
                m_arePeopleVisible = value;
                RaisePropertyChanged("ArePeopleVisible");
            }
        }
        public ObservableCollection<IPersonViewModel> People { get; set; }
        #endregion

        #region Dependency Properties
        #endregion

        #region Commands
        public ICommand ShowPeopleCommand = new CustomCommand(showPeople, canShowPeople);
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        private bool canShowPeople(object obj)
        {
            bool arePeopleVisible = ArePeopleVisible == Visibility.Visible;
            bool haveLoadedPeople = People != null;

            return !arePeopleVisible && haveLoadedPeople;
        }

        private void showPeople(object obj)
        {
            ArePeopleVisible = Visibility.Visible;
        }
        #endregion

        #region Specific Interface Implementation

        #region Implementation of <InterfaceName>

        #endregion

        #endregion
    }
}
