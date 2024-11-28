using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;
using Tarefa3.Domain.Interfaces.Service;
using Tarefa3.Application.Services;

namespace Tarefa3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService _personService;
        private readonly PersonAddressService _personAddressService;

        // Construtor para injeção de dependência
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        public PersonController(PersonAddressService personAddressService)
        {
            _personAddressService = personAddressService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var people = _personService.GetAll();
            return Ok(people);
        }

        [HttpGet("{id}/address")]
        public async Task<IActionResult> GetAddressByPersonId(int id)
        {
            try
            {
                var address = await _personAddressService.GetAddressByPersonIdAsync(id);
                return Ok(address);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
