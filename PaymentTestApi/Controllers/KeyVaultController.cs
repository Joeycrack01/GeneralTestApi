using MediSmartTestApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using PaymentTestApi.ApplicationService.KeyVaultTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace PaymentTestApi.Controllers
{
    [Route("api/[controller]")]
    public class KeyVaultController : BaseApiController
    {
        private readonly IKeyVaultTestService _keyVaultTestService;
        public KeyVaultController(IKeyVaultTestService keyVaultTestService)
        {
            _keyVaultTestService = keyVaultTestService;
        }

        [HttpPost, Route("KeyVaultTest")]
        public async Task<IActionResult> KeyVaultTest()
        {
            try
            {
                var result = await _keyVaultTestService.EncryptDecryptAsync();

                //if (!result) return BadRequest();

                return Ok();
            }
            catch (Exception ex)
            {
                LogError(ex);
                return StatusCode(500);
            }
        }
    }
}
