using FalloutRP.Services;
using Microsoft.AspNetCore.Mvc;

namespace FalloutRP.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
    public class CharacterController : Controller
        {
            private readonly CharacterService _characterService;

            public CharacterController(CharacterService characterService)
            {
                _characterService = characterService;
            }

        [HttpGet("Character")]
        public IActionResult CharacterGetById(int id)
        {
            return Ok(_characterService.CharacterGetById(id));
        }
    }
}
