using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PS.Application.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Token : ControllerBase
    {
        ITokenService _tokenService;

        public Token(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> GetAuth()
        {
            var tokenString =_tokenService.GenerateAccessToken();

            return Ok(new { accessToken = tokenString });
        }
    }
}
