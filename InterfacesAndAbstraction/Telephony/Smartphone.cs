

using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {

        public string Call(string number)
        {

            if (number.Any(c => char.IsLetter(c)))
            {
                return "Invalid number!";
            }
            else
                return $"Calling... {number}";
        }
        public string Browse(string website)
        {
            
            if (website.Any(c => char.IsDigit(c)))
            {
                return "Invalid URL!";
            } else
            return $"Browsing: {website}!";
        }
    }
}
