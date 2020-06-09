﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CS_Take_Home_Challenge
{
	// stores the people, handles commands, loads people upon construction,
	// also handles the visibility of the people
	class PersonFileParserViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<Person> People { get; set; }
		private PersonFileParser fileParser = new PersonFileParser();
		public ICommand ShowPeopleCommand { get; set; }
		public Visibility ArePeopleVisible
		{
			get => arePeopleVisible;
			set
			{
				arePeopleVisible = value;
				RaisePropertyChanged("ArePeopleVisible");
			}
		}

		private Visibility arePeopleVisible = Visibility.Hidden; // people start hidden

		public event PropertyChangedEventHandler PropertyChanged;

		public PersonFileParserViewModel()
		{
			loadData();
			loadCommands();
		}

		private void loadCommands()
		{
			ShowPeopleCommand = new CustomCommand(showPeople, canShowPeople);
		}

		// can show people if they are not currently visible
		private bool canShowPeople(object obj)
		{
			return ArePeopleVisible != Visibility.Visible;
		}

		// make the people visible
		private void showPeople(object obj)
		{
			ArePeopleVisible = Visibility.Visible;
		}

		private void loadData()
		{
			People = fileParser.GetAllPeople();
		}

		private void RaisePropertyChanged(string propertyName)
		{
			if (propertyName != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
