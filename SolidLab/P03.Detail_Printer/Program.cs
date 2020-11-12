using System;
using System.Collections.Generic;
using P03.Detail_Printer;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<string> documents = new List<string>(){ "SoftUni MASTER", "SOLID is great", "Dido is a C# Monster" };
            IPrintable dido = new Manager("Dido", documents);
            IPrintable pesho = new Employee("Pesho");
            var employees = new List<IPrintable>();
            employees.Add(dido);
            employees.Add(pesho);
            var printer = new DetailsPrinter(employees);
            printer.PrintDetails();
        }
    }
}
