using System;

namespace AuthorProblem
{
    [Author("Ventsi")]
    public class StartUp
    {
        [Author("Gosho")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
        [Author("Dido")]
        private static void Print()
        {
            Console.WriteLine("Dido e pich");
        }
    }
}
