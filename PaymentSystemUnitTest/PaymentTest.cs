using PS.Application.Services;
using System;
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
        #endregion
    }
}
