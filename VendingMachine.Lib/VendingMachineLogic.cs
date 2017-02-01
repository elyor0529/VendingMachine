using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Lib.Exceptions;
using VendingMachine.Lib.Extensions;
using VendingMachine.Lib.Infrastructures;
using VendingMachine.Lib.Models;

namespace VendingMachine.Lib
{
    public class VendingMachineLogic : IVendingMachine
    {
        #region props & fields

        private Product _product;
        private Money _amount;

        public string Manifacturer { get; }

        public Money Amount { get { return _amount; } }

        public Product[] Products { get; set; }

        #endregion

        #region ctors

        public VendingMachineLogic(string manifacturer)
        {
            Manifacturer = manifacturer;
        }

        #endregion

        #region members

        public Money InsertCoin(Money coin)
        {
            //validate coin
            if (!coin.ValidateMoney())
            {
                throw new VendingMachineException("Invalid coin", new ArgumentOutOfRangeException());
            }

            //if more than from product price  
            if (_amount >= _product.Price)
            {
                throw new VendingMachineException("Amount is already full", new OutOfMemoryException());
            }

            //insert coin
            _amount += coin;

            //get coins back
            return _amount;
        }

        public Money ReturnMoney()
        {
            var delta = _amount - _product.Price;

            if (delta < 0)
                throw new VendingMachineException("Amount will not be enough", new NotFiniteNumberException());

            return delta;
        }

        public Product Buy(int productNumber)
        {
            if (productNumber < 0 || Products.Length <= productNumber)
                throw new VendingMachineException("Product number wrong", new IndexOutOfRangeException());

            var product = Products[productNumber];

            if (product.Avaliable <= 0)
                throw new VendingMachineException("Product does not have", new NullReferenceException());

            //charge gor product size
            product.Avaliable--;

            _product = product;

            return _product;
        }

        #endregion

    }
}
