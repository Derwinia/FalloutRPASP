using FalloutRP.DTO;
using FalloutRP.Services;
using FalloutRPDAL.Entities.CharacterClasses;
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

        [HttpPost("Character-Ammo-Create/{concernedInventory}")]
        public IActionResult CharacterAmmoCreate([FromRoute] int concernedInventory)
        {
            try
            {
                int newAmmoId = _characterService.CharacterAmmoCreate(concernedInventory);
                return Ok(new { AmmoId = newAmmoId, Message = "Ammo créée avec succès." });
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Character-Ammo-Delete/{ammoId}")]
        public IActionResult CharacterAmmoDelete([FromRoute] int ammoId)
        {
            try
            {
                _characterService.CharacterAmmoDelete(ammoId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Character-Chem-Create/{concernedInventory}")]
        public IActionResult CharacterChemCreate([FromRoute] int concernedInventory)
        {
            try
            {
                int newChemId = _characterService.CharacterChemCreate(concernedInventory);
                return Ok(new { ChemId = newChemId, Message = "Chem créée avec succès." });
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Character-Chem-Delete/{chemId}")]
        public IActionResult CharacterChemDelete([FromRoute] int chemId)
        {
            try
            {
                _characterService.CharacterChemDelete(chemId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Character-Drink-Create/{concernedInventory}")]
        public IActionResult CharacterDrinkCreate([FromRoute] int concernedInventory)
        {
            try
            {
                int newDrinkId = _characterService.CharacterDrinkCreate(concernedInventory);
                return Ok(new { DrinkId = newDrinkId, Message = "Drink créée avec succès." });
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Character-Drink-Delete/{drinkId}")]
        public IActionResult CharacterDrinkDelete([FromRoute] int drinkId)
        {
            try
            {
                _characterService.CharacterDrinkDelete(drinkId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Character-Equip-Create/{concernedInventory}")]
        public IActionResult CharacterEquipCreate([FromRoute] int concernedInventory)
        {
            try
            {
                int newEquipId = _characterService.CharacterEquipCreate(concernedInventory);
                return Ok(new { EquipId = newEquipId, Message = "Equip créée avec succès." });
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Character-Equip-Delete/{equipId}")]
        public IActionResult CharacterEquipDelete([FromRoute] int equipId)
        {
            try
            {
                _characterService.CharacterEquipDelete(equipId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Character-Food-Create/{concernedInventory}")]
        public IActionResult CharacterFoodCreate([FromRoute] int concernedInventory)
        {
            try
            {
                int newFoodId = _characterService.CharacterFoodCreate(concernedInventory);
                return Ok(new { FoodId = newFoodId, Message = "Food créée avec succès." });
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Character-Food-Delete/{foodId}")]
        public IActionResult CharacterFoodDelete([FromRoute] int foodId)
        {
            try
            {
                _characterService.CharacterFoodDelete(foodId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Character-Mat-Create/{concernedInventory}")]
        public IActionResult CharacterMatCreate([FromRoute] int concernedInventory)
        {
            try
            {
                int newMatId = _characterService.CharacterMatCreate(concernedInventory);
                return Ok(new { MatId = newMatId, Message = "Mat créée avec succès." });
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Character-Mat-Delete/{matId}")]
        public IActionResult CharacterMatDelete([FromRoute] int matId)
        {
            try
            {
                _characterService.CharacterMatDelete(matId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Character-Reputation-Create/{concernedCharacter}")]
        public IActionResult CharacterReputationCreate([FromRoute] int concernedCharacter)
        {
            try
            {
                int newRepId = _characterService.CharacterReputationCreate(concernedCharacter);
                return Ok(new { RepId = newRepId, Message = "Reputation créée avec succès." });
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Character-Reputation-Delete/{repId}")]
        public IActionResult CharacterRepDelete([FromRoute] int repId)
        {
            try
            {
                _characterService.CharacterReputationDelete(repId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
