using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PS.Application.Services.Interface;
using PS.Domain.Entities;
using System.Threading.Tasks;

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
        public async Task<AcctBalance> GetAcctBalance()
        {
            return  await _transaction.GetAcctBalance();
        }

        [HttpPost]
        public async Task<bool> Post()
        {
            return await _transaction.InsertInialData();
        }
    }
}
