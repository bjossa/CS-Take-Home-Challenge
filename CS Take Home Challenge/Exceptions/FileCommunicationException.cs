﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Take_Home_Challenge
{
    public class FileCommunicationException : Exception
    {
        public FileCommunicationException (string message): base(message)
        {

        }

        public FileCommunicationException () : base()
        {

        }
    }
}
