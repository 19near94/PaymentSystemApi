using PS.Application.Services;
using System;
using Xunit;

namespace PaymentSystemUnitTest
{
    public class TokenTest
    {
        [Fact]
        public void TokenNotNull()
        {
            //Arr
            TokenService transactionService = new TokenService();

            //Act
            var result = transactionService.GenerateAccessToken();

            //Assert
            Assert.True(result != null, "Result should not be null");
        }

        [Fact]
        public void TokeNegative()
        {
            //Arr
            string expected = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2Mjk5ODI1OTksImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NDQzNjciLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQ0MzY3In0.7nf--ks6C6KagOMhtpFgMkqBOfHeHNhFJyB87LLgIXY";
            TokenService transactionService = new TokenService();

            //Act
            var result = transactionService.GenerateAccessToken();

            //Assert
            Assert.True(result != expected, "Result should not be equal to expected");
        }
    }
}
