using VendingMachine_Assignment_Lexicon;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void AssertPrices()
        {
            Banana banana = new Banana();
            CocaCola cocacola = new CocaCola();
            FrozenPanPizza fpp = new FrozenPanPizza();

            Assert.Equal(2, banana.Price);
            Assert.Equal(10, cocacola.Price);
            Assert.Equal(15, fpp.Price);
        }

        [Fact]
        public void AssertEndTransactionSetsMoneyPoolToZero()
        {
            VendingMachineService vending = new VendingMachineService();
            vending.EndTransaction();
            Assert.Equal(0, vending.moneyPool);
        }
    }
}