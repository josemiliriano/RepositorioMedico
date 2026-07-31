using Application.Users;
using Application.Users.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMedicoPaciente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _services;
        public UserController(IUserAppService services)
        {
            _services = services;
        }
        [HttpPost]
        [Route("api/[controller]/CreateUser")]
        public async Task<ActionResult> CreateUser(UserDto dto)
        {
            var NewUser = await _services.AddUser(dto);
            return Ok(NewUser);
        }
        [HttpGet]
        [Route("api/[controller]/ListUsers")]
        public async Task<ActionResult> ListUsers()
        {
            var ListUser = await _services.GetAllUser();
            return Ok(ListUser);
        }
        [HttpGet]
        [Route("api/[controller]/UserById/{id}")]
        public async Task<ActionResult> UserById(int id)
        {
            var user = await _services.GetUserById(id);
            if (user == null)
            {
                return NotFound($"El usuario con el Id {id} no existe en la base de datos");
            }
            return Ok(user);
        }
        [HttpGet]
        [Route("api/[controller]/UserNoDelete")]
        public async Task<ActionResult> UserNoDelete()
        {
            var userNoDelete = await _services.GetUserNoDelete();
            return Ok(userNoDelete);            
        }
        [HttpDelete]
        [Route("api/[controller]/SoftDelete")]
        public async Task<ActionResult> SoftDelete(int id)
        {
            var user = await _services.SoftDelete(id);
            if (user == null)
            {
                return NotFound($"El usuario con el Id {id} no existe en la base de datos");
            }            
            return Ok(user);
        }
        [HttpDelete]
        [Route("api/[controller]/DeleteUser")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _services.GetUserById(id);
            if (user == null)
            {
                return NotFound($"El usuario con el Id {id} no existe en la base de datos");
            }
            await _services.DeleteUserAsync(id);
            return Ok(user);
        }
        [HttpPut]
        [Route("api/[controller]/UpdateUser")]
        public async Task<ActionResult> UpdateUser(int id, UserOnlyDto dto)
        {
            var user = await _services.GetUserById(id);
            if (user == null)
            {
                return NotFound($"El usuario con el Id {id} no existe en la base de datos");
            }
            await _services.UpdateUser(id, dto);
            return Ok(user);
        }
        [HttpGet]
        [Route("api/[controller]/UserWithName")]
        public async Task<ActionResult> UserWithName()
        {
            var user = await _services.GetAllUserWhitName();
            return Ok(user);
        }        
    }
}
