using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain.Entities
{
    public class InvalidAccountException : Exception
    {
        public InvalidAccountException(string message) : base(message)
        {
        }
    }
}
