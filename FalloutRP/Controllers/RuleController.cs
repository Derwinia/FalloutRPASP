using FalloutRP.DTO;
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

        //Update a rule
        [HttpPatch("Update-Rule")]
        public IActionResult UpdateRule([FromBody] RuleModifyDTO ruleModifyDTO)
        {
            try
            {
                _ruleService.UpdateRule(ruleModifyDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
