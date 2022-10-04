namespace VendingMachine_Assignment_Lexicon
{
    internal class Program
    {
        protected static void PrintMenu()
        {
            Console.WriteLine("Enter your selection: ");
            Console.WriteLine("1 - Add a product to your selection.");
            Console.WriteLine("2 - Show products in your selection.");
            Console.WriteLine("3 - Calculate value of your selection.");
            Console.WriteLine("4 - Insert money into the machine.");
            Console.WriteLine("5 - Finalize.");
            Console.WriteLine("6 - Show inventory.");
            Console.WriteLine("q - Quit.");
        }
        protected static void Run()
        {
            VendingMachineService service = new VendingMachineService();
            bool End = false;
            while (End == false)
            {
                try
                {
                    PrintMenu();
                    string? input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            Console.Clear();
                            service.Purchase();
                            break;
                        case "2":
                            Console.Clear();
                            service.ShowAll();
                            break;
                        case "3":
                            Console.Clear();
                            service.CalcTotal();
                            break;
                        case "4":
                            Console.Clear();
                            service.InsertMoney();
                            break;
                        case "5":
                            Console.Clear();
                            service.EndTransaction();
                            break;
                        case "6":
                            Console.Clear();
                            service.Inventory();
                            break;
                        case "q":
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
        static void Main(string[] args)
        {
            Run();
        }
    }
}