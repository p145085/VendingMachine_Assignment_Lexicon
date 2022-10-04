using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_Assignment_Lexicon
{
    internal class CocaCola : Product
    {
        protected string description = "It appears to be an aluminum can of some sort of carbonated beverage.";
        protected int price = 10;

        public override void Examine()
        {
            Console.WriteLine(description);
            Console.WriteLine("Its price is " + price);
        }
        public override void Use()
        {
            Console.WriteLine("You shake it, throw it and shout \"Fire in the hole!\".");
        }
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                this.price = value;
            }
        }

    }
}
