using System.ComponentModel;
using System.Windows.Input;

namespace CS_Take_Home_Challenge
{
    public class PersonViewModel : IPersonViewModel
    {

        #region Private Fields
        private Person m_person;
        #endregion

        #region Constructors
        public PersonViewModel(Person person)
        {
            m_person = person;
        }
        #endregion

        #region Properties
        #endregion

        #region Dependency Properties
        #endregion

        #region Commands

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion

        #region Specific Interface Implementation

        #region Implementation of <IPersonViewModel>
        public virtual string Name
        {
            get { return m_person.Name; }
            set 
            { 
                m_person.Name = value;
                RaisePropertyChanged_("Name");
            }
        }
        public virtual string Address 
        {
            get { return m_person.Address; }
            set
            {
                m_person.Address = value;
                RaisePropertyChanged_("Address");
            }
        }
        public virtual string Phone 
        {
            get { return m_person.Phone; }
            set
            {
                m_person.Phone = value;
                RaisePropertyChanged_("Phone");
            }
        }
        public virtual bool IsActive 
        {
            get { return m_person.IsActive; }
            set
            {
                m_person.IsActive = value;
                RaisePropertyChanged_("IsActive");
            }
        }
        #endregion

        #region Implementation of <INotifyPropertyChanged>
        private void RaisePropertyChanged_(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
