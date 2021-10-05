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

                return Ok(result);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return BadRequest(ex.Message);
            }
        }


        [HttpPost, Route("KeyVaultDecryptionTest")]
        public async Task<IActionResult> KeyVaultDecryptionTest()
        {
            try
            {
                var result = await _keyVaultTestService.DecryptAsync();

                //if (!result) return BadRequest();

                return Ok(result.Item1 + " ====> " + result.Item2);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
