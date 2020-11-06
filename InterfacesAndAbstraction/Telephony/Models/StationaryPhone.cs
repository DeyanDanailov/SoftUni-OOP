
using System;
using System.Linq;


namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            return !ValidCallNumber(number)
                ? "Invalid number!"
                : $"Dialing... {number}";
        }
        private static bool ValidCallNumber(string callNumber)
        {
            if (callNumber.All(ch => Char.IsDigit(ch)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
