using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ").ToArray();
            var websites = Console.ReadLine().Split(" ").ToArray();
            var smartPhone = new Smartphone();
            var stationaryPhone = new StationaryPhone();
            foreach (var number in numbers)
            {
                if (number.Length == 10)
                {
                    Console.WriteLine(smartPhone.Call(number));
                }
                else if (number.Length == 7)
                {
                    Console.WriteLine(stationaryPhone.Call(number));
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
            foreach (var site in websites)
            {
                Console.WriteLine(smartPhone.Browse(site));
            }
        }
    }
}

