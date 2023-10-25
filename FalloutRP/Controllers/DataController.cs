using FalloutRP.DTO;
using FalloutRP.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FalloutRP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : Controller
    {
        private readonly DataService _dataService;

        public DataController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost("Data-Create")]
        public IActionResult DataCreate([FromBody] DataCreateDTO dataCreateDTO)
        {
            try
            {
                _dataService.DataCreate(dataCreateDTO);
                return NoContent();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Data-List-Categorie/{id}")]
        public IActionResult DataListCategorie([FromRoute] int id)
        {
            return Ok(_dataService.DataListCategorie(id));
        }

        [HttpPatch("Data-Update")]
        public IActionResult DataUpdate([FromBody] DataUpdateDTO dataDTO)
        {
            try
            {
                _dataService.DataUpdate(dataDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("Data-Delete")]
        public IActionResult DataDelete([FromBody] int id)
        {
            try
            {
                _dataService.DataDelete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
