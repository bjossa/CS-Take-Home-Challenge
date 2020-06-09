using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Take_Home_Challenge
{
    // a class for parsing a text file of people data into ObservableCollection<Person>
    // this class is part of the model in our MVVM pattern
    public class PersonFileParser
    {
        public ObservableCollection<Person> people { get; set; }
        private string filePath = "C:\\Users\\Work\\Desktop\\Data.txt";

        public PersonFileParser()
        {
            people = new ObservableCollection<Person>();
        }

        public ObservableCollection<Person> GetAllPeople()
        {
            ParseFileToPeople();
            return people;
        }


        // reads file data and populates 'people'
        private void ParseFileToPeople()
        {
            string[] unparsedPeople = File.ReadAllLines(filePath);
            // go through each unparsedPerson and convert them to people instances
            foreach (var unparsedPerson in unparsedPeople)
            {
                ConvertStringToPersonAndAddToPeople_(unparsedPerson);
            }
        }

        // given a string of the form "name, address, phone, isValid", create an instance of a Person with these attributes and add it to 'people'
        private void ConvertStringToPersonAndAddToPeople_(string str)
        {
            string[] properties = str.Split(new string[] { ", " }, StringSplitOptions.None); //{name, address, phone, isValid}
            properties = properties.Select(x => x.Trim()).ToArray();
            Person person = new Person(properties[0], properties[1], properties[2], bool.Parse(properties[3]));
            people.Add(person);
        }

    }
}
