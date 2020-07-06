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
            LoadCommands_();
            IsReadOnly = true;
        }
        #endregion

        #region Properties
        #endregion

        #region Dependency Properties
        #endregion

        #region Commands

        #endregion

        #region Public Methods
        public void ChangePersonEditability(object o)
        {
            IsReadOnly = !IsReadOnly;
        }
        #endregion

        #region Private Methods
        private void LoadCommands_()
        {
            ChangePersonEditabilityCommand = new CustomCommand(ChangePersonEditability, (o) => { return true; });
        }
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

        private bool m_isReadOnly;
        public virtual bool IsReadOnly
        {
            get
            {
                return m_isReadOnly;
            }
            set
            {
                m_isReadOnly = value;
                RaisePropertyChanged_("IsReadOnly");
            }
        }

        public ICommand ChangePersonEditabilityCommand { get; set; }
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
