﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CS_Take_Home_Challenge
{
    public interface IPersonListViewModel: INotifyPropertyChanged
    {
        ObservableCollection<IPersonViewModel> People { get; set; }
        void AddPersonViewModel(IPersonViewModel personVM);
        void RemovePersonViewModel(IPersonViewModel personVM);
        // todo: instead, dont pass around lists of interfaces, create them one at a time.
        void populatePeople(ObservableCollection<IPersonViewModel> peopleVMs);
    }
}
