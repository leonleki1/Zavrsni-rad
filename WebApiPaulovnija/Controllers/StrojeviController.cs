using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiPaulovnija.DTO;
using WebApiPaulovnija.Models;
using WebApiPaulovnija.Services;

namespace WebApiPaulovnija.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StrojeviController : ControllerBase
    {
        private readonly IStrojService _strojeviService;
        private readonly IMapper _mapper;

        public StrojeviController(IStrojService strojeviService, IMapper mapper)
        {
            _strojeviService = strojeviService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StrojDTO>>> GetAll()
        {
            try
            {
                var strojevi = await _strojeviService.GetAllAsync();
                return Ok(_mapper.Map<IEnumerable<StrojDTO>>(strojevi));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Greška prilikom dobivanja podataka: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StrojDTO>> GetById(int id)
        {
            try
            {
                var stroj = await _strojeviService.GetByIdAsync(id);
                if (stroj == null)
                    return NotFound();

                return Ok(_mapper.Map<StrojDTO>(stroj));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Greška prilikom dobivanja stroja s ID {id}: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<StrojDTO>> Create([FromBody] KreirajStrojDTO kreirajStrojDTO)
        {
            try
            {
                if (kreirajStrojDTO == null)
                    return BadRequest("Podaci za stroj su obavezni.");

                var stroj = _mapper.Map<Stroj>(kreirajStrojDTO);
                await _strojeviService.AddAsync(stroj);
                return CreatedAtAction(nameof(GetById), new { id = stroj.ID_Stroja }, _mapper.Map<StrojDTO>(stroj));
            }
            catch (DbUpdateException ex)
            {
                // Uključujemo unutarnju grešku u odgovor
                var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "Nema dodatnih informacija.";
                return StatusCode(500, $"Greška prilikom dodavanja stroja: {ex.Message}. Inner exception: {innerExceptionMessage}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Nepoznata greška prilikom dodavanja stroja: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AzurirajStrojDTO azurirajStrojDTO)
        {
            try
            {
                if (id != azurirajStrojDTO.ID_Stroja)
                    return BadRequest("ID stroja se ne podudara.");

                var existingStroj = await _strojeviService.GetByIdAsync(id);
                if (existingStroj == null)
                    return NotFound();

                _mapper.Map(azurirajStrojDTO, existingStroj);
                await _strojeviService.UpdateAsync(existingStroj);
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Greška prilikom ažuriranja stroja: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Nepoznata greška prilikom ažuriranja stroja: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var stroj = await _strojeviService.GetByIdAsync(id);
                if (stroj == null)
                    return NotFound();

                await _strojeviService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Greška prilikom brisanja stroja s ID {id}: {ex.Message}");
            }
        }
    }
}
