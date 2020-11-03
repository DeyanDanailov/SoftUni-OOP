using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var ferari = new SportCar(400, 200);
            ferari.Drive(100);
            Console.WriteLine(ferari.Fuel);
        }
    }
}
