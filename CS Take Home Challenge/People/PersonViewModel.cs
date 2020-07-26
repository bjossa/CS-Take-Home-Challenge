using System.ComponentModel;

namespace CS_Take_Home_Challenge
{
    public class PersonViewModel :
        IPersonViewModel
    {

        #region Private Fields

        private IPerson m_person;

        #endregion

        #region Constructors

        public PersonViewModel(IPerson person)
        {
            m_person = person;
        }

        #endregion

        #region private methods

        private void RaisePropertyChanged_(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Implementation of IPersonViewModel

        public string Name
        {
            get { return m_person.Name; }
            set
            {
                m_person.Name = value;
                RaisePropertyChanged_(nameof(Name));
            }
        }
        public string Address
        {
            get { return m_person.Address; }
            set
            {
                m_person.Address = value;
                RaisePropertyChanged_(nameof(Address));
            }
        }
        public string Phone
        {
            get { return m_person.Phone; }
            set
            {
                m_person.Phone = value;
                RaisePropertyChanged_(nameof(Phone));
            }
        }
        public bool IsActive
        {
            get { return m_person.IsActive; }
            set
            {
                m_person.IsActive = value;
                RaisePropertyChanged_(nameof(IsActive));
            }
        }
        #endregion

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
