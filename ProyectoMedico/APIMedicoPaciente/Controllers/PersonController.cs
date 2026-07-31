using Application.Person;
using Application.Person.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMedicoPaciente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonAppService _service;
        public PersonController(IPersonAppService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("api/[controller]/CreatePerson")]
        public async Task<ActionResult> CreatePerson(PersonDto dto)
        {
            var NewClient = await _service.AddPerson(dto);
            return Ok(NewClient);
        }
        [HttpGet]
        [Route("api/[controller]/GetAllPerson")]
        public async Task<ActionResult> GetAllPerson()
        {
            var PersonList = await _service.GetAllPerson();
            return Ok(PersonList);
        }
        [HttpGet]
        [Route("api/[controller]/GetPersonNoDelete")]
        public async Task<ActionResult> GetPersonNoDelete()
        {
            var PersonList = await _service.GetPersonNoDelete();
            return Ok(PersonList);
        }
        [HttpGet]
        [Route("api/[controller]/GetPersonById{id}")]
        public async Task<ActionResult> GetPersonById(int id)
        {
            var Person = await _service.GetPersonById(id);
            return Ok(Person);
        }
        [HttpPut]
        [Route("api/[controller]/UpdatePerson")]
        public async Task<ActionResult> UpdatePerson(int id, PersonDto dto)
        {
            var person = await _service.UpdatePerson(id, dto); ;
            if (person == null)
            {
                return NotFound($"La Persona con el Id {id} no existe en la base de datos");
            }            
            return Ok(person);
        }
        [HttpDelete]
        [Route("api/[controller]/SoftDelete")]
        public async Task<ActionResult> SoftDelete(int id)
        {
            var person = await _service.GetPersonById(id);
            if (person == null)
            {
                return NotFound($"La persona con el id {id} no existe en la base de datos");
            }
            await _service.SoftDelete(id);
            return Ok(person);
        }
        [HttpDelete]
        [Route("api/[controller]/DeletePerson")]
        public async Task<ActionResult> DeletePerson(int id)
        {
            var person = await _service.GetPersonById(id);
            if (person == null)
            {
                return NotFound($"La persona con el id {id} no existe en la base de datos");
            }
            await _service.DeletePersonAsync(id);
            return Ok(person);
        }      

    }

}
