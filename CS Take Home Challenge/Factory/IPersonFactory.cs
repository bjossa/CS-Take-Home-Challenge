﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Take_Home_Challenge.Factory
{
    public interface IPersonFactory
    {
        ObservableCollection<IPersonViewModel> CreatePeopleViewModels(ICollection<Person> people);
        Person CreatePerson(string name, string address, string phone, bool isActive = true);

        IPersonViewModel CreatePersonViewModel(Person person);
    }
}
