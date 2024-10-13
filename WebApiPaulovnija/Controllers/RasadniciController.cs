using Microsoft.AspNetCore.Mvc;
using WebApiPaulovnija.Models;
using WebApiPaulovnija.Services;
using System.Threading.Tasks;
using WebApiPaulovnija.DTO;

namespace WebApiPaulovnija.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RasadniciController : ControllerBase
    {
        private readonly IRasadnikService _rasadnikService;

        public RasadniciController(IRasadnikService rasadnikService)
        {
            _rasadnikService = rasadnikService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRasadnici()
        {
            try
            {
                var rasadnici = await _rasadnikService.GetAllRasadniciAsync();
                return Ok(rasadnici);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRasadnik(int id)
        {
            var rasadnik = await _rasadnikService.GetRasadnikByIdAsync(id);
            if (rasadnik == null) return NotFound();
            return Ok(rasadnik);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRasadnik([FromBody] KreirajRasadnikDTO rasadnikDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var createdRasadnik = await _rasadnikService.CreateRasadnikAsync(rasadnikDTO);
            return CreatedAtAction(nameof(GetRasadnik), new { id = createdRasadnik.ID_Rasadnika }, createdRasadnik);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRasadnik(int id, [FromBody] AzurirajRasadnikDTO rasadnikDTO)
        {
            if (id != rasadnikDTO.ID_Rasadnika) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updated = await _rasadnikService.UpdateRasadnikAsync(rasadnikDTO);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRasadnik(int id)
        {
            var deleted = await _rasadnikService.DeleteRasadnikAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
