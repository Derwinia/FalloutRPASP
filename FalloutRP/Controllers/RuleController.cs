using FalloutRP.Services;
using Microsoft.AspNetCore.Mvc;

namespace FalloutRP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuleController : Controller
    {
        private readonly RuleService _ruleService;

        public RuleController(RuleService ruleService)
        {
            _ruleService = ruleService;
        }

        //Return a simple list of all rules 
        [HttpGet("List")]
        public IActionResult GetAllRules()
        {
            return Ok(_ruleService.GetAllRules());
        }
    }
}
