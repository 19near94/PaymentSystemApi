using PS.Application.Utils;
using PS.Domain.Entities;
using PS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Application.Services
{
    public class TransactionService : ITransaction
    {
        public AcctBalance GetAcctBalance()
        {
            Random rand = new Random();
            RandomDate randomDate = new RandomDate();
            AcctBalance acctBalance = new AcctBalance();
            List<AcctTransaction> acctTransactions = new List<AcctTransaction>();
            RandomEnumValues randomEnumValues = new RandomEnumValues();
            for (int i = 0; i < 5; i++)
            {
                AcctTransaction acctTransaction = new AcctTransaction();
                acctTransaction.Amount = rand.Next(10000, 400000);// get random amount
                acctTransaction.Date = randomDate.DateRandom();
                acctTransaction.Status = randomEnumValues.RandomEnumValue<StatusEnum>().DisplayName();
                acctTransactions.Add(acctTransaction);
            }

            acctBalance.AcctTransactions = acctTransactions.OrderByDescending(i => i.Date).ToList();
            return acctBalance;
        }
    }
}
