using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Take_Home_Challenge
{
    public class PeopleParsingException : Exception
    {
        public PeopleParsingException(string message): base(message)
        {

        }

        public PeopleParsingException() : base()
        {

        }
    }
}
