using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PS.Application.Services;
using PS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Account : ControllerBase
    {
        ITransaction _transaction;
        public Account(ITransaction transaction)
        {
            _transaction = transaction;
        }
        public AcctBalance GetAcctBalance()
        {
            return _transaction.GetAcctBalance();
        }
    }
}
