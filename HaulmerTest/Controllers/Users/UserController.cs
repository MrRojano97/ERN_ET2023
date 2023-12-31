using Microsoft.AspNetCore.Mvc;
using HaulmerTest.Models;

namespace HaulmerTest.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase {

        private static List<User> users = new List<User>(); // Lista en memoria para almacenar los usuarios que se irán creando
        private static int nextId = 0; // Contador para asignar un ID a cada usuario

        [HttpPost]
        public IActionResult Post([FromBody] User newUser) {
            if (newUser == null) {
                return BadRequest("Es necesario incluir toda la información de un usuario para su creación");
            }

            // Establece el ID
            newUser.Id = nextId++;
            // Establecer fechas
            newUser.FechaCreacion = DateTime.UtcNow;
            newUser.FechaActualizacion = DateTime.UtcNow;

            // Agrega el nuevo usuario a la lista
            users.Add(newUser);

            return Ok("Se ha añadido un nuevo usuario de manera exitosa");
        }

        // Endpoint para obtener todos los usuarios
        [HttpGet]
        public IActionResult GetAllUsers() {
            return Ok(users);
        }

        // Endpoint para buscar un usuario por ID
        [HttpGet("id/{id}")]
        public IActionResult GetUserById(int id) {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null) {
                return NotFound("Usuario no encontrado");
            }
            return Ok(user);
        }
    }
}
