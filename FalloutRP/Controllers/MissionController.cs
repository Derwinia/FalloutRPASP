using FalloutRP.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("Mission-List-All")]
        public IActionResult MissionListAll()
        {
            return Ok(_missionService.MissionListAll());
        }
    }
}
