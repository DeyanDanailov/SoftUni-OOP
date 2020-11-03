using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age)
       : base(name, age)
        {
            this.Age = age;
        }

        public new int Age
        {
            get
            {
                return base.Age;
            }
            set
            {
                if (value < 16)
                {
                    this.Age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Child age cannot be more than 15!");
                }
            }
        }
    }
}
