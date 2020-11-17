using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 3, 4, 6, 6, 3 };
            var result = CalculateMoves(numbers);
            Console.WriteLine(result);
            
        }
        public static long CalculateMoves(List<int> numbers)
        {
            long counter = 0;
            while (true)
            {
                if (numbers.GroupBy(n => n).Count()==1)
                {                   
                    break;
                }

                //var maxIndex = !numbers
                //    .Any() ? -1 : numbers
                //    .Select((value, index) => new { Value = value, Index = index })
                //    .Aggregate((a, b) => (a.Value > b.Value) ? a : b).Index;

                var maxValue = numbers.Max();
                var maxIndex = numbers.LastIndexOf(maxValue);

                Console.WriteLine($"MaxIndex - {maxIndex}");
               
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (i == maxIndex)
                    {
                        continue;
                    }
                    numbers[i]++;
                }


                counter++;
            }
            
            
            return counter;
        }
    }
}
