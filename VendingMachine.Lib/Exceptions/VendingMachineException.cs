using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Lib.Exceptions
{
    public class VendingMachineException : Exception
    {
        /// <summary>
        /// init base for empty throwing 
        /// </summary>
        public VendingMachineException() : base()
        {

        }

        /// <summary>
        /// send message to base ctor
        /// </summary>
        /// <param name="message">Exp message</param>
        public VendingMachineException(string message) : base(message)
        {

        }

        /// <summary>
        /// Send message include with inner excetion
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public VendingMachineException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
