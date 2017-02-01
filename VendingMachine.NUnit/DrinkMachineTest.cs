using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using VendingMachine.Lib; 
using VendingMachine.Lib.Exceptions;

namespace VendingMachine.NUnit
{

    public class DrinkMachineTest : BaseTest
    {
        public DrinkMachineTest() : this("Drink")
        {
        }

        private DrinkMachineTest(string manifacturer) : base(manifacturer)
        {
            Log("Choosed '{0}' manifacturer", manifacturer);
        }

        [Test]
        [Description("Select product")]
        [Order(1)]
        public void SelectProduct()
        {
            var productNumber = 1;

            Try(() =>
            {
                var product = MachineLogic.Buy(productNumber);

                Log("Selected product:{0}", product);
            });

        }

        [Test]
        [Description("Insert coin")]
        [Order(2)]
        public void InsertCoin()
        {
            var amount05 = MachineSettings.Coin.Coint5Cent;
            var amount10 = MachineSettings.Coin.Coint10Cent;
            var amount20 = MachineSettings.Coin.Coint20Cent;
            var amount50 = MachineSettings.Coin.Coint50Cent;
            var amount1 = MachineSettings.Coin.Coint1Euro;

            Try(() =>
            {
                var coin = MachineLogic.InsertCoin(amount05);
                var coin10 = MachineLogic.InsertCoin(amount10);
                var coin20 = MachineLogic.InsertCoin(amount20);
                var coin50 = MachineLogic.InsertCoin(amount50);
                var coin1 = MachineLogic.InsertCoin(amount1);

                Log("New coin:{0:C}", coin1);
            });
        }

        [Test]
        [Description("Return money")]
        [Order(3)]
        public void ReturnCoin()
        {
            Try(() =>
            {
                var amount = MachineLogic.ReturnMoney();

                Log("Return money:{0:C}", amount);
            });
        }

        [Test]
        [Description("Product list")]
        [Order(4)]
        public void ProductList()
        {
            foreach (var product in Products)
            {
                Log("Product:{0}", product);
            }
        }

    }
}
