

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {

        public void Call(string number)
        {
            Console.WriteLine(!ValidCallNumber(number)
                ? "Invalid number!"
                : $"Calling... {number}");
        }

        public void Browse(string url)
        {
            Console.WriteLine(!ValidUrlAddress(url)
                ? "Invalid URL!"
                : $"Browsing: {url}!");
        }

        private static bool ValidCallNumber(string callNumber)
        {
            return Regex.IsMatch(callNumber, "^\\d+$");
        }

        private static bool ValidUrlAddress(string urlAddress)
        {
            bool containsDigit = Regex.IsMatch(urlAddress, "\\d");
            return !containsDigit;
        }
    }
}
