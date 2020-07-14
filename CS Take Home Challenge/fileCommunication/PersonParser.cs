using CS_Take_Home_Challenge.Factory;
using CS_Take_Home_Challenge.fileParsing;
using System;
using System.CodeDom;
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
    public class PersonParser: IPersonParser
    {

        #region private members
        private IPersonFactory m_personFactory;

        #endregion

        #region Constructors
        public PersonParser(IPersonFactory personFactory= null)
        {
            m_personFactory = personFactory ?? new PersonFactory();
        }
        #endregion

        #region Properties
        #endregion

        #region public methods
        public List<Person> ParseStringsToPeople(string[] unparsedPeople)
        {
            List<Person> people = new List<Person>();
            foreach (var unparsedPerson in unparsedPeople)
            {
                people.Add(ToPerson(unparsedPerson));
            }
            return people;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"> "name, address, phone, isValid" </param>
        public Person ToPerson(string str)
        {
            string[] properties = str.Split(new string[] { ", " }, StringSplitOptions.None);
            properties = properties.Select(x => x.Trim()).ToArray();
            Person person = m_personFactory.CreatePerson(properties[0], properties[1], properties[2], bool.Parse(properties[3]));
            return person;
        }

        #endregion

    }
}