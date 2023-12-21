using FalloutRP.DTO;
using FalloutRP.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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

        [HttpPatch("Character-Update")]
        public IActionResult CharacterUpdate([FromBody] CharacterDTO characterModifyDTO)
        {
            try
            {
                _characterService.CharacterUpdate(characterModifyDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Character-Perk-Create/{concernedCharacter}")]
        public IActionResult CharacterPerkCreate([FromRoute]  int concernedCharacter)
        {
            try
            {
                int newPerkId = _characterService.CharacterPerkCreate(concernedCharacter);
                return Ok(new { PerkId = newPerkId, Message = "Perk créée avec succès." });
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Character-Perk-Delete/{perkId}")]
        public IActionResult CharacterPerkDelete([FromRoute] int perkId)
        {
            try
            {
                _characterService.CharacterPerkDelete(perkId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
