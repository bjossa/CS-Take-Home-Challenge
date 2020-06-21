using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace CS_Take_Home_Challenge
{
    class PersonViewModel : IPersonViewModel
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

        #region Implementation of <InterfaceName>
        public string Name
        {
            get { return m_person.Name; }
            set { m_person.Name = value; }
        }
        public string Address 
        {
            get { return m_person.Address; }
            set { m_person.Address = value; }
        }
        public string Phone 
        {
            get { return m_person.Phone; }
            set { m_person.Phone = value; }
        }
        public bool IsActive 
        {
            get { return m_person.IsActive; }
            set { m_person.IsActive = value; }
        }
        #endregion

        #endregion
    }
}
