using Microsoft.AspNetCore.Mvc;
using HaulmerTest.Utilities;

namespace HaulmerTest.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class EncryptController : ControllerBase {
        public class EncryptRequest {
            public required string Text { get; set; }
        }

        [HttpPost]
        public IActionResult Post([FromBody] EncryptRequest request) {
            // En caso de no recibir el campo text en el POST
            if (request == null || string.IsNullOrWhiteSpace(request.Text)) {
                return BadRequest("Se requiere el campo text en el POST");
            }

            var encryptedText = CryptoHelper.EncryptString(request.Text);
            return Ok(new { Encrypted = encryptedText });
        }
    }
}
