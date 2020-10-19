using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using pidol.Models;

namespace pidol.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CharacterController: ControllerBase
    {
        private static List<Character> _characters = new List<Character> {
            new Character { Id = 1 },
            new Character { Id = 2, Name = "Sam" }
        };

        [HttpGet]
        public IActionResult Get() {
            return Ok(_characters);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id) {
            Character selected_character = _characters.FirstOrDefault(chr => chr.Id.Equals(id));

            return Ok(selected_character);
        }
    }
}