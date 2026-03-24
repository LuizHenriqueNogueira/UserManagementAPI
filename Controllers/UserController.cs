using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // Simulando um banco de dados na memória para o propósito do projeto
        private static readonly List<User> _users = new List<User>();
        private static int _nextId = 1;

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_users);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar a lista de usuários.", ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { Message = $"Usuário com ID {id} não encontrado." });
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Validação de entrada
            }

            try
            {
                newUser.Id = _nextId++;
                _users.Add(newUser);
                return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar um novo usuário.", ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound(new { Message = $"Usuário com ID {id} não encontrado para atualização." });
            }

            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { Message = $"Usuário com ID {id} não encontrado." });
            }

            _users.Remove(user);
            return NoContent();
        }
    }
}