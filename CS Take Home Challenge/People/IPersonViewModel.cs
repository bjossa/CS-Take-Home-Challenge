using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CS_Take_Home_Challenge
{
    public interface IPersonViewModel : INotifyPropertyChanged
    {
        string Name { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        bool IsActive { get; set; }

        bool IsReadOnly {get; set;}

        ICommand ChangePersonEditabilityCommand { get; set; }
	}
}
