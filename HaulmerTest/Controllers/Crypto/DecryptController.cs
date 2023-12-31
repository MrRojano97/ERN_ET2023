using Microsoft.AspNetCore.Mvc;
using HaulmerTest.Utilities;

namespace HaulmerTest.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class DecryptController : ControllerBase {
        public class DecryptRequest {
            public required string Encrypted { get; set; }
        }

        [HttpPost]
        public IActionResult Post([FromBody] DecryptRequest request) {
            // En caso de no recibir el campo encrypted en el POST
            if (request == null || string.IsNullOrWhiteSpace(request.Encrypted)) {
                return BadRequest("Se requiere el campo encrypted en el POST");
            }

            try {
                var decryptedText = CryptoHelper.DecryptString(request.Encrypted);
                return Ok(new { Decrypted = decryptedText });
            }
            catch {
                // En caso de ocurrir algún error al desencriptar
                return BadRequest("Error desconocido: No se ha podido desencriptar el texto ingresado");
            }
        }
    }
}
