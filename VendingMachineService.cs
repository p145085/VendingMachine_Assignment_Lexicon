using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace VendingMachine_Assignment_Lexicon
{
    public class VendingMachineService : IVending
    {
        private static List<Banana> BananasInSelection = new List<Banana>();
        private List<CocaCola> CocaColasInSelection = new List<CocaCola>();
        private List<FrozenPanPizza> FrozenPanPizzasInSelection = new List<FrozenPanPizza>();
        public int moneyPool;

        public void Purchase() {
            bool End = false;
            while (End == false)
            {
                try
                {
                    PrintPurchaseMenu();
                    string? input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            Console.Clear();
                            BananasInSelection.Add(new Banana());
                            break;
                        case "2":
                            Console.Clear();
                            CocaColasInSelection.Add(new CocaCola());
                            break;
                        case "3":
                            Console.Clear();
                            FrozenPanPizzasInSelection.Add(new FrozenPanPizza());
                            break;
                        case "f":
                            Console.Clear();
                            End = true;
                            break;
                        case "0":
                            Console.Clear();
                            End = true;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void PrintPurchaseMenu()
        {
            Console.WriteLine("Enter your selection: ");
            Console.WriteLine("1 - Add a 'Banana' to your selection.");
            Console.WriteLine("2 - Add a 'Coca-Cola' to your selection.");
            Console.WriteLine("3 - Add a 'Frozen Pan Pizza' to your selection.");
            Console.WriteLine("0 - I changed my mind, I don't want to add anything.");
            Console.WriteLine("f - I am finished adding products.");
        }
        public void ShowAll() {
            Console.WriteLine("Amount of 'Bananas': " + BananasInSelection.Count());
            Console.WriteLine("Amount of 'Coca-Colas': " + CocaColasInSelection.Count());
            Console.WriteLine("Amount of 'Frozen Pan Pizzas': " + FrozenPanPizzasInSelection.Count());
        }
        public void Details() {
            ShowAll();
            Console.WriteLine("Your total is: " + CalcTotal());
        }
        public void InsertMoney() {
            Console.WriteLine("Enter amount provided: ");
            int input = Convert.ToInt32(Console.ReadLine());
            moneyPool += input;
        }
        public void EndTransaction() {
            int price = CalcTotal();

            int input = moneyPool;

            int retur = input - price; // Remainder. (Negative if insufficient).
            Console.WriteLine("Amount back: " + retur); // Print how much is owed.

            var change = AsChange(retur); // Thanks to "Pobiega" from the C# Discord.
            foreach (var i in change)
            {
                Console.WriteLine($"Amount: {i.Value} Denomination: {i.Key}");

            }
            moneyPool = 0;
        }
        public int CalcTotal()
        {
            int total = 0;
            foreach (Banana banana in BananasInSelection)
            {
                total += banana.Price;
            }
            foreach (CocaCola cocacola in CocaColasInSelection)
            {
                total += cocacola.Price;
            }
            foreach (FrozenPanPizza frozenpanpizza in FrozenPanPizzasInSelection)
            {
                total += frozenpanpizza.Price;
            }
            Console.WriteLine("So far it will cost you: " + total);
            return total;
        }
        public void Inventory()
        {
            bool End = false;
            while (End == false)
            {
                try
                {
                    ShowAll();
                    Console.WriteLine("Use: ");
                    if (BananasInSelection.Count > 0)
                    {
                        Console.WriteLine("1 - Banana.");
                    }
                    if (CocaColasInSelection.Count > 0)
                    {
                        Console.WriteLine("2 - Coca-Cola.");
                    }
                    if (FrozenPanPizzasInSelection.Count > 0)
                    {
                        Console.WriteLine("3 - Frozen Pan Pizza.");
                    }
                    Console.WriteLine("q - Quit.");
                    string? input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            BananasInSelection[0].Examine();
                            BananasInSelection[0].Use();
                            BananasInSelection.Remove(BananasInSelection[0]);
                            break;
                        case "2":
                            CocaColasInSelection[0].Examine();
                            CocaColasInSelection[0].Use();
                            CocaColasInSelection.Remove(CocaColasInSelection[0]);
                            break;
                        case "3":
                            FrozenPanPizzasInSelection[0].Examine();
                            FrozenPanPizzasInSelection[0].Use();
                            FrozenPanPizzasInSelection.Remove(FrozenPanPizzasInSelection[0]);
                            break;
                        case "q":
                            End = true;
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static Dictionary<int, int> AsChange(int amount)
        { // Thanks to "Pobiega" from the C# Discord.
            int[] _denominations = new int[] { 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1 };

            if (amount < 0)
                throw new ArgumentException("Can't calculate negative change.", nameof(amount));

            var dict = new Dictionary<int, int>();

            foreach (var denomination in _denominations)
            {
                if (amount < denomination)
                    continue;

                var count = amount / denomination;
                dict.Add(denomination, count);
                amount -= count * denomination;
            }

            return dict;
        }
    }
}
