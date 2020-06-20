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
    public class PersonFileParser
    {

        #region private members
        private string m_filePath;
        #endregion

        #region Constructors
        public PersonFileParser()
        {
            People = new ObservableCollection<Person>();
            m_filePath = "C:\\Users\\erico\\OneDrive\\Desktop\\Data.txt";
        }
        #endregion

        #region Properties
        public ObservableCollection<Person> People { get; set; }
        #endregion

        #region public methods

        public ObservableCollection<Person> GetAllPeople()
        {
            ParseFileToPeople();
            return People;
        }
        #endregion

        #region private methods
        private void ParseFileToPeople()
        {
            string[] unparsedPeople = File.ReadAllLines(m_filePath);

            foreach (var unparsedPerson in unparsedPeople)
            {
                ConvertStringToPersonAndAddToPeople(unparsedPerson);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"> "name, address, phone, isValid" </param>
        private void ConvertStringToPersonAndAddToPeople(string str)
        {
            string[] properties = str.Split(new string[] { ", " }, StringSplitOptions.None);
            properties = properties.Select(x => x.Trim()).ToArray();
            Person person = new Person(properties[0], properties[1], properties[2], bool.Parse(properties[3]));
            People.Add(person);
        }

        #endregion

    }
}