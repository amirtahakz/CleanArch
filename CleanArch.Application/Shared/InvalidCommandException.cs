﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Shared
{
    public class InvalidCommandException : BaseCommandException
    {
        public InvalidCommandException()
        {
        }

        public InvalidCommandException(string message) : base(message)
        {
        }
    }
}
