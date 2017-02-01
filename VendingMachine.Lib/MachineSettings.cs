using VendingMachine.Lib.Models;

namespace VendingMachine.Lib
{
    public static class MachineSettings
    {
        public struct Coin
        {
            public static readonly Money Coint5Cent = new Money(0, 5);
            public static readonly Money Coint10Cent = new Money(0, 10);
            public static readonly Money Coint20Cent = new Money(0, 20);
            public static readonly Money Coint50Cent = new Money(0, 50);
            public static readonly Money Coint1Euro = new Money(1, 0);
            public static readonly Money Coint2Euro = new Money(2, 0);

            //Requirement cents
            public static readonly Money[] Coins =
            {
               Coint5Cent,
               Coint10Cent,
               Coint20Cent,
               Coint50Cent,
               Coint1Euro,
               Coint2Euro
            };
        }
    }
}