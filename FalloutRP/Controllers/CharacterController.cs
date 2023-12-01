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

        //[HttpGet("Character/{characterId}")]
        //public IActionResult CharacterGetById([FromRoute]int characterId)
        //{
        //    return Ok(_characterService.CharacterGetById(characterId));
        //}

        [HttpGet("Character-Get-By-Pseudo/{pseudo}")]
        public IActionResult CharacterGetBypseudo([FromRoute] string pseudo)
        {
            return Ok(_characterService.CharacterGetByPseudo(pseudo));
        }

        [HttpGet("Character-Name-List-For-A-Team/{teamName}")]
        public IActionResult CharacterNameListForATeam([FromRoute]string teamName)
        {
            return Ok(_characterService.CharacterNameListForATeam(teamName));
        }
    }
}
