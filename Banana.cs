using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_Assignment_Lexicon
{
    public class Banana : Product
    {
        protected string description = "It appears to be a yellow-coloured pistol.";
        protected int price = 2;
        public override void Examine()
        {
            Console.WriteLine(description);
            Console.WriteLine("Its price is " + price);
        }
        public override void Use()
        {
            Console.WriteLine("You grab hold of the banana, point it forward and say \"Pew pew\".");
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
