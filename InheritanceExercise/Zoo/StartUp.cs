using System;

namespace Zoo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var mecho = new Bear("Puh");
            Console.WriteLine(mecho.Name);
        }
    }
}
