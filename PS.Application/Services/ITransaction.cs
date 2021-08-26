using PS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Application.Services
{
    public interface ITransaction
    {
        /// <summary>
        /// Get the transaction details
        /// </summary>
        /// <returns>The Account details and its value</returns>
        AcctBalance GetAcctBalance();
    }
}
