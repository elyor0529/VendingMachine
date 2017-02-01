using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Lib.Extensions;

namespace VendingMachine.Lib.Models
{
    public struct Money
    {

        #region field & props

        /// <summary>
        /// euros
        /// </summary>
        public int Euros { get; set; }

        /// <summary>
        /// dents
        /// </summary>
        public int Cents { get; set; }

        public static Money Zero
        {
            get
            {
                return new Money(0, 0);
            }
        }

        #endregion

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="euros"></param>
        /// <param name="cents"></param>
        public Money(int euros, int cents)
        {
            Euros = euros;
            Cents = cents;
        }

        #region operators

        public static bool operator <(Money m1, Money m2)
        {
            return m1.Euros < m2.Euros && m1.Cents < m2.Cents;
        }

        public static bool operator >(Money m1, Money m2)
        {
            return m1.Euros > m2.Euros && m1.Cents > m2.Cents;
        }

        public static bool operator <=(Money m1, Money m2)
        {
            return m1.Euros <= m2.Euros && m1.Cents <= m2.Cents;
        }

        public static bool operator >=(Money m1, Money m2)
        {
            return m1.Euros >= m2.Euros && m1.Cents >= m2.Cents;
        }

        public static Money operator +(Money m1, Money m2)
        {
            return new Money(m1.Euros + m2.Euros, m1.Cents + m2.Cents);
        }

        public static Money operator -(Money m1, Money m2)
        {
            return new Money(m1.Euros - m2.Euros, m1.Cents - m2.Cents);
        }

        public static implicit operator Money(decimal d)
        {
            return d.ToMoney();
        }

        public static bool operator ==(Money m1, Money m2)
        {
            return m1.Equals(m2);
        }

        public static bool operator !=(Money m1, Money m2)
        {
            return !m1.Equals(m2);
        }

        #endregion

        #region overrides

        public bool Equals(Money m)
        {
            return Equals(m, this);
        }

        public override bool Equals(object o)
        {
            if (o is Money)
            {
                var m = (Money)o;

                return Euros == m.Euros && Cents == m.Cents;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Euros.GetHashCode() ^ Cents.GetHashCode();
        }


        public override string ToString()
        {
            var s = String.Format("{0}.{1}", Euros, Cents);
            decimal d;

            decimal.TryParse(s, NumberStyles.AllowDecimalPoint, null, out d);

            return String.Format("{0:C}", d);
        }

        #endregion

    }
}
