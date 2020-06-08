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
    // a class for parsing a text file of people data into List<Person>
    public class PersonFileParser
    {
        public ObservableCollection<Person> People { get; set; } // will update the UI when it changes

        public PersonFileParser()
        {
            People = new ObservableCollection<Person>();
        }


        // reads file data and populates 'people'
        public void ParseFileToPeople(string filePath)
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
            People.Add(person);
        }

    }
}
