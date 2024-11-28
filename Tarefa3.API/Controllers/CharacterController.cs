using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarefa3.Domain.Interfaces.Service;

namespace Tarefa3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly RickAndMortyService _rickAndMortyService;

        public CharacterController(RickAndMortyService rickAndMortyService)
        {
            _rickAndMortyService = rickAndMortyService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacter(int id)
        {
            try
            {
                var character = await _rickAndMortyService.GetCharacterByIdAsync(id);
                return Ok(character);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

}
