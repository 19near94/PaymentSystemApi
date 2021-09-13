using PS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PS.Application.Services.Interface
{
    public interface ITransaction
    {
        /// <summary>
        /// Get the transaction details
        /// </summary>
        /// <returns>The Account details and its value</returns>
        Task<AcctBalance> GetAcctBalance();
        Task<bool> InsertInialData();
    }
}
