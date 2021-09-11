using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PS.Application.Services.Interface;
using System;
using System.Threading.Tasks;

namespace PaymentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Token : ControllerBase
    {
        ITokenService _tokenService;
        private readonly ILogger _logger;

        public Token(ITokenService tokenService, ILogger logger)
        {
            _tokenService = tokenService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> GetAuth(string username, string password)
        {
            try
            {

                if (username == "test123" && password == "test123")
                {
                    var tokenString = _tokenService.GenerateAccessToken();
                    return Ok(new { accessToken = tokenString });
                }
                else
                {
                    _logger.LogDebug("Invalid Authentication");
                    throw new Exception("Invalid Authentication");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
