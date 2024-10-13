using Microsoft.AspNetCore.Mvc;
using WebApiPaulovnija.DTO;
using WebApiPaulovnija.Services;
using System.Threading.Tasks;

namespace WebApiPaulovnija.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SadniceController : ControllerBase
    {
        private readonly ISadnicaService _sadnicaService;

        public SadniceController(ISadnicaService sadnicaService)
        {
            _sadnicaService = sadnicaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sadnice = await _sadnicaService.GetAllAsync();
            return Ok(sadnice);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sadnica = await _sadnicaService.GetByIdAsync(id);
            if (sadnica == null) return NotFound();
            return Ok(sadnica);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] KreirajSadnicuDTO sadnicaDTO)
        {
            var createdSadnica = await _sadnicaService.AddAsync(sadnicaDTO);
            return CreatedAtAction(nameof(GetById), new { id = createdSadnica.ID_Sadnice }, createdSadnica);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AzurirajSadnicuDTO sadnicaDTO)
        {
            if (id != sadnicaDTO.ID_Sadnice) return BadRequest();
            var updated = await _sadnicaService.UpdateAsync(sadnicaDTO);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _sadnicaService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
