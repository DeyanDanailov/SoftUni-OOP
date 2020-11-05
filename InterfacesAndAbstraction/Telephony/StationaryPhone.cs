
using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {

            if (number.Any(c => char.IsLetter(c) ))
            {
                return "Invalid number!";
            }
            else
                return $"Dialing... {number}";
        }
    }
}
