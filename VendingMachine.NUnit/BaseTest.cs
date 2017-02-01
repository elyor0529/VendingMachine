using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using NUnit.Framework;
using VendingMachine.Lib;
using VendingMachine.Lib.Exceptions;
using VendingMachine.Lib.Infrastructures;
using VendingMachine.Lib.Models;

namespace VendingMachine.NUnit
{
    [TestFixture]
    public abstract class BaseTest
    {
        static BaseTest()
        {
            //set up UK time zone
            var culture = new CultureInfo("en-GB");
            Thread.CurrentThread.CurrentCulture = culture;
        }

        /// <summary>
        ///     Cached product items
        /// </summary>
        protected static readonly Product[] Products =
        {
            new Product
            {
                Avaliable = 3,
                Name = "Cola",
                Price = 2.1m
            },
            new Product
            {
                Avaliable = 2,
                Name = "Pepsi",
                Price = 1.8m
            }
        };

        /// <summary>
        ///     choosed Machine manificturer
        /// </summary>
        protected BaseTest(string manifacturer)
        {
            MachineLogic = new VendingMachineLogic(manifacturer)
            {
                Products = Products
            };
        }

        /// <summary>
        /// generic logic
        /// </summary>
        protected static IVendingMachine MachineLogic;

        /// <summary>
        /// logs
        /// </summary>
        /// <param name="s"></param>
        /// <param name="objects"></param>
        protected static void Log(string s, params object[] objects)
        {
            Console.WriteLine(s, objects);
        }
         
        /// <summary>
        /// try  logic
        /// </summary>
        /// <param name="action"></param>
        protected static void Try(Action action)
        {
            try
            {  
                action(); 
            }
            catch (VendingMachineException machineException)
            {
                Log(machineException.Message);
            }
            catch (Exception otherException)
            {
                Log(otherException.Message);
            }
        }
    }
}