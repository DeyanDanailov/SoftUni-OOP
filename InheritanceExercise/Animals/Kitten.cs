﻿

namespace Animals
{
    public class Kitten : Cat
    {
        private const string gender = "Female";
        public Kitten(string name, int age) : base(name, age, gender)
        {
        }
        
        public override string Gender { get => gender; }
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
