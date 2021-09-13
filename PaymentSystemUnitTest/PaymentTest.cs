using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using PS.Application.Services;
using PS.Domain.Entities;
using PS.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PaymentSystemUnitTest
{

    public class PaymentTest
    {
        private Mock<ILogger> ILoggerMock = new Mock<ILogger>();

        public PaymentTest()
        {
            InitContext();
        }

        private AcctDbContext _acctDbContext;

        [Fact]
        public void InitContext()
        {
            var builder = new DbContextOptionsBuilder<AcctDbContext>()
                .UseInMemoryDatabase("Test");
            var id = Guid.NewGuid().ToString();
            Random rand = new Random();
            var context = new AcctDbContext(builder.Options);

            var acctTrans = Enumerable.Range(1, 5)
                .Select(i => new AcctTransaction { Id = Guid.NewGuid().ToString(), AccountId = id, Amount = rand.Next(10000, 400000), Date = DateTime.UtcNow }
                            );
            var acctBalances = Enumerable.Range(1, 5)
                .Select(i => new AcctBalance { Id = Guid.NewGuid().ToString(), AcctTransactions = acctTrans.ToList(), Balance="500,000.00" });
            context.Accounts.AddRange(acctBalances);
            int changed = context.SaveChanges();
            _acctDbContext = context;
        }

        #region Positive
        [Fact]
        public async Task BalanceNotNullAsync()
        {

            //Arr
            TransactionService transactionService = new TransactionService(_acctDbContext, ILoggerMock.Object);

            //Act
            var result = await transactionService.GetAcctBalance();

            //Assert
            Assert.True(result != null, "Result should not be null");
        }

        [Fact]
        public async Task TransactionCountAsync()
        {
            //Arr
            int expected = 5;
            TransactionService transactionService = new TransactionService(_acctDbContext, ILoggerMock.Object);
            
            //Act
            var result = await transactionService.GetAcctBalance();

            //Assert
            Assert.Equal(result.AcctTransactions.Count , expected);
        }

        [Fact]
        public async Task TransactionAmountAsync()
        {
            //Arr
            int expected = 10000;
            TransactionService transactionService = new TransactionService(_acctDbContext, ILoggerMock.Object);

            //Act
            var result = await transactionService.GetAcctBalance();

            //Assert
            Assert.True(result.AcctTransactions.Select(i => i.Amount).FirstOrDefault() >= expected);
        }

        [Fact]
        public async Task TransactionDateAsync()
        {
            //Arr
            int expected = DateTime.UtcNow.Year;
            TransactionService transactionService = new TransactionService(_acctDbContext, ILoggerMock.Object);

            //Act
            var result = await transactionService.GetAcctBalance();

            //Assert
            Assert.True(result.AcctTransactions.Select(i => i.Date.Year).FirstOrDefault() >= expected);
        }
        #endregion

        #region Negative
        [Fact]
        public async Task BalanceNullAsync()
        {
            //Arr
            TransactionService transactionService = new TransactionService(_acctDbContext, ILoggerMock.Object);

            //Act
            var result = await transactionService.GetAcctBalance();

            //Assert
            Assert.False(result == null, "Result should not be equal to  null");
        }

        [Fact]
        public async Task AcctTransactionCountAsync()
        {
            //Arr
            int expected = 3;
            TransactionService transactionService = new TransactionService(_acctDbContext, ILoggerMock.Object);

            //Act
            var result = await transactionService.GetAcctBalance();

            //Assert
            Assert.False(result.AcctTransactions.Count == expected);
        }

        [Fact]
        public async Task TransactionAmountNegativeAsync()
        {
            //Arr
            int expected = 90000;
            TransactionService transactionService = new TransactionService(_acctDbContext, ILoggerMock.Object);

            //Act
            var result = await transactionService.GetAcctBalance();

            //Assert
            Assert.False(result.AcctTransactions.Select(i => i.Amount).FirstOrDefault() <= expected);
        }

        [Fact]
        public async Task TransactionDateNegativeAsync()
        {
            //Arr
            int expected = DateTime.UtcNow.AddYears(-2).Year;
            TransactionService transactionService = new TransactionService(_acctDbContext, ILoggerMock.Object);

            //Act
            var result = await transactionService.GetAcctBalance();

            //Assert
            Assert.True(result.AcctTransactions.Select(i => i.Date.Year).FirstOrDefault() >= expected);
        }
        #endregion
    }
}
