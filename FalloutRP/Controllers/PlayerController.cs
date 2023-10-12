using FalloutRP.DTO;
using FalloutRP.Services;
using FalloutRPDAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FalloutRP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService _playerService;
        private readonly TokenService _tokenService;

        public PlayerController(PlayerService playerService, TokenService tokenService)
        {
            _playerService = playerService;
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] PlayerLoginDTO cmd)
        {
            Player? player = _playerService.GetByUsername(cmd.Pseudo);

            if (player is null || !_playerService.VerifyPasswordHash(cmd.Password, player.PasswordHash, player.PasswordSalt))
            {
                return BadRequest("Pseudo ou mot de passe incorrect");
            }

            return Ok(new { token = _tokenService.CreateToken(player), id = player.Id, username = player.Pseudo, role = player.Team.Name });
        }

        //Return a list of all Players
        [HttpGet("List")]
        public IActionResult GetAllPlayer()
        {
            return Ok(_playerService.GetAllPlayer());
        }

        //Create a Player
        [HttpPost("Create")]
        public IActionResult Add([FromBody] PlayerCreateDTO playerCreateDTO)
        {
            try
            {
                _playerService.Add(playerCreateDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Change a Player's password
        [HttpPatch("Change-Password")]
        public IActionResult ChangePassword([FromBody] PlayerChangePasswordDTO playerChangePasswordDTO)
        {
            try
            {
                _playerService.ChangePassword(playerChangePasswordDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Delete a Player
        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] int id)
        {
            try
            {
                _playerService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Create a Team
        [HttpPost("Create-Team")]
        public IActionResult AddTeam([FromBody] TeamDTO teamDTO)
        {
            try
            {
                _playerService.AddTeam(teamDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("List-Team")]
        public IActionResult GetAllTeam()
        {
            return Ok(_playerService.GetAllTeam());
        }

        //Delete a Team
        [HttpDelete("Delete-Team/{team}")]
        public IActionResult DeleteTeam([FromRoute] string team)
        {
            try
            {
                _playerService.DeleteTeam(team);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
