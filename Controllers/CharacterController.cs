using Microsoft.AspNetCore.Mvc;

using pidol.Models;

namespace pidol.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CharacterController: ControllerBase
    {
        private static Character knight = new Character();

        public IActionResult Get() {
            return Ok(knight);
        }
    }
}