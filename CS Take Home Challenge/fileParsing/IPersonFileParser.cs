﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Take_Home_Challenge.fileParsing
{
    interface IPersonFileParser
    {
        List<Person> LoadPeopleFromFile(string filePath);
    }
}