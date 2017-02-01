using System;

namespace VendingMachine.Lib.Models
{
    public struct Product
    {

        /// <summary>
        /// Gets or sets the avaliable amount of product.
        /// </summary>
        public int Avaliable { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        public Money Price { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string Name { get; set; }

        public override string ToString()
        {
            return String.Format("{0}-{1}({2} items)",Name,Price,Avaliable);
        }
    }
}
