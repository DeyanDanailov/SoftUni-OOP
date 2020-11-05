
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public void Call(string number)
        {
            Console.WriteLine(!ValidCallNumber(number)
                ? "Invalid number!"
                : $"Dialing... {number}");
        }
        private static bool ValidCallNumber(string callNumber)
        {
            return Regex.IsMatch(callNumber, "^\\d+$");
        }
    }
}
