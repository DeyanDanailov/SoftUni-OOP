using System;
using System.Collections.Generic;
using System.Linq;


namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var people = ReadPeopleAndAddToList();
            var products = ReadProductsAndAddToList();
            var input = Console.ReadLine();
            while (input != "END")
            {
                var purchaseInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var personName = purchaseInfo[0];
                var productName = purchaseInfo[1];
                var currentPerson = people.Find(p => p.Name == personName);
                var currentProduct = products.Find(p => p.Name == productName);

                Console.WriteLine( currentPerson.Buy(currentProduct)); 

                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(Environment.NewLine, people));
        }

        private static List<Product> ReadProductsAndAddToList()
        {
            var productsInfo = Console.ReadLine()
                           .Split(";", StringSplitOptions.RemoveEmptyEntries)
                           .ToArray();
            var products = new List<Product>();
            foreach (var productInfo in productsInfo)
            {
                var info = productInfo
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                try
                {
                    var name = info[0];
                    var cost = decimal.Parse(info[1]);
                    var newProduct = new Product(name, cost);
                    products.Add(newProduct);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                   Environment.Exit(0);
                }             
            }
            return products;
        }

        private static List<Person> ReadPeopleAndAddToList()
        {
            var peopleInfo = Console.ReadLine()
                            .Split(";", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
            var people = new List<Person>();
            foreach (var personInfo in peopleInfo)
            {
                var info = personInfo
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                try
                {
                    var name = info[0];
                    var money = decimal.Parse(info[1]);
                    var newPerson = new Person(name, money);
                    people.Add(newPerson);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }               
            }
            return people;
        }
    }
}
