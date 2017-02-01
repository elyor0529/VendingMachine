using System.Collections;
using System.Collections.Generic;
using VendingMachine.Lib.Models;

namespace VendingMachine.Lib.Infrastructures
{
    public interface IVendingMachine
    {

        /// <summary>
        /// Vending machine manifacturer.
        /// </summary>
        string Manifacturer { get; }

        /// <summary>
        /// Amount of money inserted into vending machine.
        /// </summary>
        Money Amount { get; }

        /// <summary>
        /// Products that are sold.
        /// </summary>
        Product[] Products { get; set; }

        /// <summary>
        /// Inserts the coin into vending machine.
        /// </summary>
        /// <param name="coin">Coin amount.</param>
        /// <returns></returns>
        Money InsertCoin(Money coin); 

        /// <summary>
        /// Returns all inserted coins back to user.
        /// </summary>
        /// <returns></returns>
        Money ReturnMoney();

        /// <summary>
        /// Buys product from list of product.
        /// </summary>
        /// <param name="productNumber">Prodcut number is vending machine product list</param>
        /// <returns></returns>
        Product Buy(int productNumber);

    }
}
