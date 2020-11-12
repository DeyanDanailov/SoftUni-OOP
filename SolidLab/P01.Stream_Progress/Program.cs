using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            IStreamable myFile = new Music("Dido", "Dido e pich", 4, 1);
            StreamProgressInfo myStream = new StreamProgressInfo(myFile);
            var percent = myStream.CalculateCurrentPercent();
            Console.WriteLine(percent);
        }
    }
}
