﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PS.Application.Services.Interface;
using PS.Domain.Entities;

namespace PaymentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class Account : ControllerBase
    {
        ITransaction _transaction;
        public Account(ITransaction transaction)
        {
            _transaction = transaction;
        }

        [HttpGet]
        public AcctBalance GetAcctBalance()
        {
            return _transaction.GetAcctBalance();
        }
    }
}
