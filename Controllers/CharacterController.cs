using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using pidol.Models;
using pidol.Services.CharacterServices;
using System.Threading.Tasks;

namespace pidol.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CharacterController: ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;
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
        public async Task<IActionResult> AddCharacter(Character baru) {
            return Ok(await _characterService.AddCharacter(baru));
        }
    }
}