using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_Assignment_Lexicon
{
    public class FrozenPanPizza : Product
    {
        protected string description = "You examine the packaging and it appears to be cheese on top of bread.";
        protected int price = 15;

        public override void Examine()
        {
            Console.WriteLine(description);
            Console.WriteLine("Its price is " + price);
        }
        public override void Use()
        {
            Console.WriteLine("Since there is no microwave you eat it frozen.");
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
