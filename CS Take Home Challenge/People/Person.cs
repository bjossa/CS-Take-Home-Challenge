namespace CS_Take_Home_Challenge
{
    public class Person :
        IPerson
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

        #region implementation of IPerson

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public bool IsActive { get; set; }

        #endregion
    }
}
