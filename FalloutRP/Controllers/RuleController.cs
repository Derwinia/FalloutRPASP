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

        [HttpPost("Rule-Create")]
        public IActionResult RuleCreate([FromBody]RuleCreateDTO ruleCreateDTO)
        {
            try
            {
                _ruleService.RuleCreate(ruleCreateDTO);
                return NoContent();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Rule-List")]
        public IActionResult RuleList()
        {
            return Ok(_ruleService.RuleList());
        }

        [HttpGet("Rule-From-Path/{path}")]
        public IActionResult RuleFromPath([FromRoute] string path)
        {
            return Ok(_ruleService.RuleFromPath(path));
        }
        

        [HttpPatch("Rule-Update")]
        public IActionResult RuleUpdate([FromBody] RuleModifyDTO ruleModifyDTO)
        {
            try
            {
                _ruleService.RuleUpdate(ruleModifyDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("Rule-Order-Update")]
        public IActionResult RuleOrderUpdate([FromBody] RuleOrderDTO ruleOrderDTO)
        {
            try
            {
                _ruleService.RuleOrderUpdate(ruleOrderDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Rule-Delete/{id}")]
        public IActionResult RuleDelete([FromRoute] string id)
        {
            try
            {
                _ruleService.RuleDelete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
