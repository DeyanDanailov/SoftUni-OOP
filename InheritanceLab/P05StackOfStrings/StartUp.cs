using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new StackOfStrings();
            var stackToAdd = new Stack<string>();
            stackToAdd.Push("Pesho");
            stackToAdd.Push("Gosho");
            stackToAdd.Push("Simitrichko");
            stack.AddRange(stackToAdd);
        }
    }
}
