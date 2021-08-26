using PS.Application.Services;
using System;
using System.Linq;
using Xunit;

namespace PaymentSystemUnitTest
{
    public class PaymentTest
    {
        #region Positive
        [Fact]
        public void BalanceNotNull()
        {
            //Arr
            TransactionService transactionService = new TransactionService();

            //Act
            var result = transactionService.GetAcctBalance();

            //Assert
            Assert.True(result != null, "Result should not be null");
        }

        [Fact]
        public void TransactionCount()
        {
            //Arr
            int expected = 5;
            TransactionService transactionService = new TransactionService();

            //Act
            var result = transactionService.GetAcctBalance();

            //Assert
            Assert.Equal(result.AcctTransactions.Count , expected);
        }

        [Fact]
        public void TransactionAmount()
        {
            //Arr
            int expected = 10000;
            TransactionService transactionService = new TransactionService();

            //Act
            var result = transactionService.GetAcctBalance();

            //Assert
            Assert.True(result.AcctTransactions.Select(i => i.Amount).FirstOrDefault() >= expected);
        }

        [Fact]
        public void TransactionDate()
        {
            //Arr
            int expected = DateTime.UtcNow.Year;
            TransactionService transactionService = new TransactionService();

            //Act
            var result = transactionService.GetAcctBalance();

            //Assert
            Assert.True(result.AcctTransactions.Select(i => i.Date.Year).FirstOrDefault() >= expected);
        }
        #endregion

        #region Negative
        [Fact]
        public void BalanceNull()
        {
            //Arr
            TransactionService transactionService = new TransactionService();

            //Act
            var result = transactionService.GetAcctBalance();

            //Assert
            Assert.False(result == null, "Result should not be equal to  null");
        }

        [Fact]
        public void AcctTransactionCount()
        {
            //Arr
            int expected = 3;
            TransactionService transactionService = new TransactionService();

            //Act
            var result = transactionService.GetAcctBalance();

            //Assert
            Assert.False(result.AcctTransactions.Count == expected);
        }

        [Fact]
        public void TransactionAmountNegative()
        {
            //Arr
            int expected = 90000;
            TransactionService transactionService = new TransactionService();

            //Act
            var result = transactionService.GetAcctBalance();

            //Assert
            Assert.False(result.AcctTransactions.Select(i => i.Amount).FirstOrDefault() <= expected);
        }

        [Fact]
        public void TransactionDateNegative()
        {
            //Arr
            int expected = DateTime.UtcNow.AddYears(-2).Year;
            TransactionService transactionService = new TransactionService();

            //Act
            var result = transactionService.GetAcctBalance();

            //Assert
            Assert.True(result.AcctTransactions.Select(i => i.Date.Year).FirstOrDefault() >= expected);
        }
        #endregion
    }
}
