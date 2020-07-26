using CS_Take_Home_Challenge.Factory;
using CS_Take_Home_Challenge.fileParsing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_Take_Home_Challenge
{
    public class PersonParser :
        IPersonParser
    {

        #region private members

        private IPersonFactory m_personFactory;

        #endregion

        #region Constructors

        public PersonParser(IPersonFactory personFactory = null)
        {
            m_personFactory = personFactory ?? new PersonFactory();
        }

        #endregion

        #region public methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"> "name, address, phone, isValid" </param>
        public IPerson ToPerson(string str)
        {
            string[] properties = str.Split(new string[] { ", " }, StringSplitOptions.None);
            if (properties.Length != 4)
            {
                throw new PeopleParsingException();
            }
            properties = properties.Select(x => x.Trim()).ToArray();
            if (!bool.TryParse(properties[3], out var isActive))
            {
                throw new PeopleParsingException();
            }
            IPerson person = m_personFactory.CreatePerson(properties[0], properties[1], properties[2], isActive);
            return person;
        }
        
        #endregion

        #region implementation of IPersonParser

        public List<IPerson> ParseStringsToPeople(string[] unparsedPeople)
        {
            List<IPerson> people = new List<IPerson>();
            foreach (var unparsedPerson in unparsedPeople)
            {
                people.Add(ToPerson(unparsedPerson));
            }
            return people;
        }

        #endregion

    }
}