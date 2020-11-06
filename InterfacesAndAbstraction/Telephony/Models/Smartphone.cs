

using System;

using System.Linq;


namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {

        public string Call(string number)
        {
            return !ValidCallNumber(number)
                ? "Invalid number!"
                : $"Calling... {number}";
        }

        public string Browse(string url)
        {
            return !ValidUrlAddress(url)
                ? "Invalid URL!"
                : $"Browsing: {url}!";
        }

        private static bool ValidCallNumber(string callNumber)
        {
            if (callNumber.All(ch=> Char.IsDigit(ch)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool ValidUrlAddress(string urlAddress)
        {
            if (urlAddress.Any(ch => Char.IsDigit(ch)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
