using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Application.Services.Interface
{
    public interface ITokenService
    {
        string GenerateAccessToken();
    }
}
