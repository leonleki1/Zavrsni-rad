using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiPaulovnija.DTO;
using WebApiPaulovnija.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiPaulovnija.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ZadatakController : ControllerBase
    {
        private readonly IZadatakService _zadatakService;
        private readonly IMapper _mapper;
        private readonly ILogger<ZadatakController> _logger;

        public ZadatakController(IZadatakService zadatakService, IMapper mapper, ILogger<ZadatakController> logger)
        {
            _zadatakService = zadatakService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<ZadatakDTO>>> Get()
        {
            try
            {
                var zadaci = await _zadatakService.GetAllZadaciAsync();
                return Ok(zadaci);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Greška prilikom dobavljanja svih zadataka.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { poruka = "Greška na serveru prilikom dobavljanja zadataka." });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ZadatakDTO>> GetById(int id)
        {
            try
            {
                var zadatak = await _zadatakService.GetZadatakByIdAsync(id);
                if (zadatak == null)
                {
                    return NotFound(new { poruka = "Zadatak sa datim ID-em nije pronađen." });
                }
                return Ok(zadatak);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Greška prilikom dobavljanja zadatka sa ID-jem {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { poruka = "Greška na serveru prilikom dobavljanja zadatka." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(KreirajZadatakDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(new { poruka = "Neispravan model.", detalji = ModelState });

            try
            {
                var zadatak = await _zadatakService.CreateZadatakAsync(dto);
                // Ispravka: Koristi ID_Zadatka umesto ID_Radnika
                return CreatedAtAction(nameof(GetById), new { id = zadatak.ID_Zadatka }, zadatak);
            }
            catch (DbUpdateException ex) // Specifično za greške u bazi
            {
                var innerException = ex.InnerException?.Message ?? ex.Message; // Uzimamo unutrašnju grešku, ako postoji
                _logger.LogError(ex, "Greška prilikom kreiranja zadatka.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { poruka = "Greška na serveru prilikom kreiranja zadatka.", detalji = innerException });
            }
            catch (Exception ex) // Ostale greške
            {
                _logger.LogError(ex, "Greška prilikom kreiranja zadatka.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { poruka = "Greška na serveru prilikom kreiranja zadatka.", detalji = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, AzurirajZadatakDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { poruka = "Neispravan model.", detalji = ModelState });

            try
            {
                // Proverite da li zadatak postoji pre ažuriranja
                var existingZadatak = await _zadatakService.GetZadatakByIdAsync(id);
                if (existingZadatak == null)
                {
                    return NotFound(new { poruka = "Zadatak sa datim ID-em nije pronađen." });
                }

                // Postavite ID zadatka u DTO
                dto.ID_Zadatka = id;

                // Ažurirajte zadatak
                var result = await _zadatakService.UpdateZadatakAsync(dto);
                if (!result)
                {
                    return NotFound(new { poruka = "Zadatak sa datim ID-em nije pronađen." });
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Greška prilikom ažuriranja zadatka sa ID-jem {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { poruka = "Greška na serveru prilikom ažuriranja zadatka.", detalji = ex.Message });
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _zadatakService.DeleteZadatakAsync(id);
                if (!result)
                {
                    return NotFound(new { poruka = "Zadatak sa datim ID-em nije pronađen." });
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Greška prilikom brisanja zadatka sa ID-jem {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { poruka = "Greška na serveru prilikom brisanja zadatka.", detalji = ex.Message });
            }
        }
    }
}
