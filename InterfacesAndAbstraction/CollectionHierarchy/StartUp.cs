using System;
using System.Collections.Generic;
using System.Linq;
using CollectionHierarchy.Models;

namespace CollectionHierarchy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var removeIterations = int.Parse(Console.ReadLine());
            var addCollection = new AddCollection();
            var result = new List<int>();
            foreach (var item in cmdArgs)
            {
                result.Add( addCollection.Add(item));               
            }
            Console.WriteLine(String.Join(" ", result));

            var addRemoveCollection = new AddRemoveCollection();
            result.Clear();
            foreach (var item in cmdArgs)
            {
                result.Add(addRemoveCollection.Add(item));
            }
            Console.WriteLine(String.Join(" ", result));

            var myList = new MyList();
            result.Clear();
            foreach (var item in cmdArgs)
            {
                result.Add(myList.Add(item));
            }
            Console.WriteLine(String.Join(" ", result));

            var removeResult = new List<string>();
            for (int i = 0; i < removeIterations; i++)
            {
                removeResult.Add(addRemoveCollection.Remove());
            }
            Console.WriteLine(String.Join(" ", removeResult));

            removeResult.Clear();
            for (int i = 0; i < removeIterations; i++)
            {
                removeResult.Add(myList.Remove());
            }
            Console.WriteLine(String.Join(" ", removeResult));
        }
    }
}
