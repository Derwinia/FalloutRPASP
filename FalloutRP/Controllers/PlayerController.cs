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

        [HttpPost("Player-Create")]
        public IActionResult playerCreate([FromBody] PlayerCreateDTO playerCreateDTO)
        {
            try
            {
                _playerService.PlayerCreate(playerCreateDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Player-List")]
        public IActionResult PlayerList()
        {
            return Ok(_playerService.PlayerList());
        }

        [HttpPatch("Password-Change")]
        public IActionResult PasswordChange([FromBody] PlayerChangePasswordDTO playerPasswordChangeDTO)
        {
            try
            {
                _playerService.PasswordChange(playerPasswordChangeDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Player-Delete")]
        public IActionResult PlayerDelete([FromBody] int id)
        {
            try
            {
                _playerService.PlayerDelete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] PlayerLoginDTO cmd)
        {
            Player? player = _playerService.GetByUsername(cmd.Pseudo);

            if (player is null || !_playerService.VerifyPasswordHash(cmd.Password, player.PasswordHash, player.PasswordSalt))
            {
                return BadRequest("Pseudo ou mot de passe incorrect");
            }

            return Ok(new { token = _tokenService.TokenCreate(player), id = player.Id, username = player.Pseudo, role = player.Team.Name });
        }

        [HttpPost("Team-Create")]
        public IActionResult TeamCreate([FromBody] TeamDTO teamDTO)
        {
            try
            {
                _playerService.TeamCreate(teamDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Team-List")]
        public IActionResult TeamList()
        {
            return Ok(_playerService.TeamList());
        }

        [HttpDelete("Team-Delete/{team}")]
        public IActionResult TeamDelete([FromRoute] string team)
        {
            try
            {
                _playerService.TeamDelete(team);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
