using PS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Application.Services
{
    public interface ITransaction
    {
        AcctBalance GetAcctBalance();
    }
}
