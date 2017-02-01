using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Lib.Models;

namespace VendingMachine.Lib.Extensions
{
    public static class ConvertExtension
    {
        /// <summary>
        /// validate money
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool ValidateMoney(this Money d)
        {
            return MachineSettings.Coin.Coins.Any(a => a == d);
        }

        /// <summary>
        /// TO money
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Money ToMoney(this decimal d)
        {
            //check to zero
            if (d == Decimal.Zero)
                return Money.Zero;

            //covert to strinmg with point
            var s = d.ToString("#.##");

            //split to ints
            var arr = s.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);

            //check two args
            if (arr.Length == 2)
            {
                var euro = Convert.ToInt32(arr[0]);
                var cent = Convert.ToInt32(arr[1]);

                return new Money(euro, cent);
            }

            return Money.Zero;
        }

    }
}
