using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Take_Home_Challenge
{
    public class Person
    {

        #region Constructors
        public Person() { }
        public Person(string name, string address, string phone, bool isActive = true)
        {
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.IsActive = isActive;
        }
        #endregion

        #region Properties
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        public virtual bool IsActive { get; set; }
        #endregion
    }
}
