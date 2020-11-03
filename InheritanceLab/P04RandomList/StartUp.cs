using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var myList = new RandomList();
            myList.Add("Pesho");
            myList.Add("Gosho");
            myList.Add("Dimitrichko");
            Console.WriteLine(myList.RandomString());
        }
    }
}
