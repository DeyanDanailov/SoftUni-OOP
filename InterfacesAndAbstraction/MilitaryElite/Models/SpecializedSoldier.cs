using MilitaryElite.Interfaces;
using System;
namespace MilitaryElite.Models
{
    public abstract class SpecializedSoldier : Soldier, ISalary
    {
        public SpecializedSoldier()
        {

        }
        private string corps;
        protected SpecializedSoldier(string id, string firstname, string lastname, decimal salary, string corps)
            :base (id, firstname, lastname)
        {
            this.Salary = salary;
            this.Corps = corps;
        }
        public decimal Salary { get; private set; }
        public string Corps 
        { 
            get
            {
                return this.corps;
            }
            set
            {
                if (value != "Marines" && value != "Airforces")
                {
                    throw new ArgumentException();
                }
                this.corps = value;
            }
        }
    }
}
