using System.Collections.Generic;

namespace CS_Take_Home_Challenge.fileParsing
{
    public interface IPersonParser
    {
        List<IPerson> ParseStringsToPeople(string[] unparsedPeople = null);
    }
}
