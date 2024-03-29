﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PS.Application.Services.Interface;
using PS.Application.Utils;
using PS.Domain.Entities;
using PS.Domain.Enums;
using PS.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Application.Services
{
    public class TransactionService : ITransaction
    {
        private readonly ILogger _logger;
        private readonly AcctDbContext _acctDbContext;

        public TransactionService(AcctDbContext acctDbContext, ILogger logger)
        {
            _acctDbContext = acctDbContext;
            _logger = logger;
        }


        public async Task<AcctBalance> GetAcctBalance()
        {
            AcctBalance acctBalance = new AcctBalance();
            try
            {
                var accountTransaction = await  _acctDbContext.AccountTransaction.AsNoTracking()
                    .OrderByDescending(i => i.Date)
                    .ToListAsync();

                acctBalance = await _acctDbContext.Accounts.AsNoTracking().FirstOrDefaultAsync();
                acctBalance.AcctTransactions = accountTransaction;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new InvalidAccountException("Error Getting balance");
            }
            return acctBalance;
        }


        public async Task<bool> InsertInialData()
        {
            Random rand = new Random();
            RandomDate randomDate = new RandomDate();
            AcctBalance acctBalance = new AcctBalance();
            acctBalance.Id = Guid.NewGuid().ToString();
            List<AcctTransaction> acctTransactions = new List<AcctTransaction>();
            RandomEnumValues randomEnumValues = new RandomEnumValues();

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    AcctTransaction acctTransaction = new AcctTransaction();
                    acctTransaction.Id = Guid.NewGuid().ToString();
                    acctTransaction.AccountId = acctBalance.Id;
                    acctTransaction.Amount = rand.Next(10000, 400000);// get random amount
                    acctTransaction.Date = randomDate.DateRandom(); // get random date
                    acctTransaction.Status = randomEnumValues.RandomEnumValue<StatusEnum>().DisplayName();// get random enum
                    acctTransactions.Add(acctTransaction);
                }
                acctBalance.AcctTransactions = acctTransactions.ToList();

                _acctDbContext.Accounts.Add(acctBalance);
                await _acctDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return true;
        }

    }
}
