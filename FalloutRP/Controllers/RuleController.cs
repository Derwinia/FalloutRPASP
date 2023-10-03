using FalloutRP.DTO;
using FalloutRP.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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

        //Create a rule 
        [HttpPost("Create-Rule")]
        public IActionResult CreateRules([FromBody]RuleCreateDTO ruleCreateDTO)
        {
            try
            {
                _ruleService.CreateRules(ruleCreateDTO);
                return NoContent();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Return a simple list of all rules 
        [HttpGet("List-Rule")]
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

        //Update the rules order
        [HttpPatch("Update-Rule-Order")]
        public IActionResult UpdateRuleOrder([FromBody] RuleOrderDTO ruleOrderDTO)
        {
            try
            {
                _ruleService.UpdateRuleOrder(ruleOrderDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Delete a rule
        [HttpDelete("Delete-Rule/{id}")]
        public IActionResult DeleteRule([FromRoute] string id)
        {
            try
            {
                _ruleService.DeleteRule(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
