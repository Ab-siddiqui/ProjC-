﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIS.Exceptions
{
    public class EmployeeException : ApplicationException
    {
        public EmployeeException()
        {

        }

        public EmployeeException(string message):base(message)
        {

        }
            

            

    }
}
