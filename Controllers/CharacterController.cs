using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using pidol.Services.CharacterService;
using pidol.Dtos.Character;

namespace pidol.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CharacterController: ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id) {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterDto baru) {
            return Ok(await _characterService.AddCharacter(baru));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto baru)
        {
            var character = await _characterService.UpdateCharacter(baru);

            if (character.Success)
            {
                return Ok(character);
            }

            return NotFound(character);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var status = await _characterService.DeleteCharacter(id);

            if (status.Success)
            {
                return Ok(status);
            }

            return NotFound(status);
        }
    }
}