using System;
using System.Collections.Generic;
using System.Linq;
namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] items = [['item1','10'
            List<List<string>> items = new List<List<string>> () {
                new List<string>() { "item1", "10", "15" },
                new List<string>() { "item2", "3", "4" },
                new List<string>() { "item3", "17", "8" } };
            var sorted = items.OrderBy(s => int.Parse(s[1])).ToList();
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine("{0}, {1}, {2}", sorted[i][0], sorted[i][1], sorted[i][2]);
            }
        }
        public static List<string> fetchItemsToDisplay(List<List<string>> items, int sortParameter, int sortOrder, int itemsPerPage, int pageNumber)
        {
            var result = new List<string>();
            
            if (sortParameter>0)
            {
                if (sortOrder == 0)
                {
                    var sorted = items.OrderBy(s => int.Parse(s[sortParameter])).ToList();
                    foreach (var item in sorted.Skip((pageNumber-1)*itemsPerPage).Take(itemsPerPage))
                    {
                        result.Add(item[0]);
                    }
                }
                else
                {
                    var sorted = items.OrderByDescending(s => int.Parse(s[sortParameter])).ToList();
                }
            }
            else 
            {
                
                if (sortOrder == 0)
                {
                    var sorted = items.OrderBy(s => (s[sortParameter])).ToList();
                }
                else
                {
                    var sorted = items.OrderByDescending(s => (s[sortParameter])).ToList();
                }
            }


            return result;
        }
    }
}
