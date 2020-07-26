using System.ComponentModel;

namespace CS_Take_Home_Challenge
{
    public interface IPersonViewModel :
        INotifyPropertyChanged
    {
        string Name { get; set; }

        string Address { get; set; }

        string Phone { get; set; }

        bool IsActive { get; set; }
    }
}
