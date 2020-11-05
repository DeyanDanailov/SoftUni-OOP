using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').ToList();
            var websites = Console.ReadLine().Split(' ').ToList();
            var smartPhone = new Smartphone();
            var stationaryPhone = new StationaryPhone();
            foreach (var number in numbers)
            {
                if (number.Length == 10)
                {
                    Console.WriteLine(smartPhone.Call(number));
                }
                else if(number.Length == 7)
                {
                    Console.WriteLine(stationaryPhone.Call(number)); 
                }
            }
            foreach (var site in websites)
            {
                Console.WriteLine(smartPhone.Browse(site) ); 
            }
        }
    }
}
