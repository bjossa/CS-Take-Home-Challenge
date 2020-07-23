﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Take_Home_Challenge.Factory
{
    public class PersonFactory: IPersonFactory
    {
        public ObservableCollection<IPersonViewModel> CreatePeopleViewModels(ICollection<IPerson> people)
        {
            ObservableCollection<IPersonViewModel> peopleVMs = new ObservableCollection<IPersonViewModel>();
            foreach (var person in people)
            {
                peopleVMs.Add(new PersonViewModel(person));
            }
            return peopleVMs;
        }

        public IPerson CreatePerson(string name, string address, string phone, bool isActive = true)
        {
            return new Person(name, address, phone, isActive);
        }

        public IPersonViewModel CreatePersonViewModel(IPerson person)
        {
            return new PersonViewModel(person);
        }
    }
}
