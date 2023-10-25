using FalloutRP.DTO;
using FalloutRP.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FalloutRP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : Controller
    {
        private readonly MissionService _missionService;

        public MissionController(MissionService missionService)
        {
            _missionService = missionService;
        }

        [HttpPost("Mission-Create")]
        public IActionResult MissionCreate([FromBody] MissionCreateDTO missionCreateDTO)
        {
            try
            {
                _missionService.MissionCreate(missionCreateDTO);
                return NoContent();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Mission-List-All")]
        public IActionResult MissionListAll()
        {
            return Ok(_missionService.MissionListAll());
        }

        [HttpGet("Mission-List-One-Player/{id}")]
        public IActionResult MissionListOnePlayer([FromRoute] int id)
        {
            return Ok(_missionService.MissionListOnePlayer(id));
        }

        [HttpPatch("Mission-Update")]
        public IActionResult MissionUpdate([FromBody] MissionDTO missionDTO)
        {
            try
            {
                _missionService.MissionUpdate(missionDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Mission-Delete")]
        public IActionResult MissionDelete([FromBody] int id)
        {
            try
            {
                _missionService.MissionDelete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
