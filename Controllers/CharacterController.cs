using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using pidol.Models;
using pidol.Services.CharacterServices;

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
        public IActionResult Get() {
            return Ok(_characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id) {
            return Ok(_characterService.GetCharacterById(id));
        }

        [HttpPost]
        public IActionResult AddCharacter(Character baru) {
            return Ok(_characterService.AddCharacter(baru));
        }
    }
}