using CS_Take_Home_Challenge.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Take_Home_Challenge.fileParsing
{
    public interface IPersonParser
    {
        List<Person> ParseStringsToPeople(string[] unparsedPeople = null);
    }
}
