using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPaulovnija.DTO;
using WebApiPaulovnija.Models;

namespace WebApiPaulovnija.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RadnikController : ControllerBase
    {
        private readonly PaulovnijaContext _context;
        private readonly IMapper _mapper;

        public RadnikController(PaulovnijaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET api/v1/radnik
        [HttpGet]
        public async Task<ActionResult<List<RadnikDTO>>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }

            try
            {
                var radnici = await _context.Radnici.ToListAsync();
                return Ok(_mapper.Map<List<RadnikDTO>>(radnici));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        // GET api/v1/radnik/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RadnikDTO>> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }

            try
            {
                var radnik = await _context.Radnici.FindAsync(id);
                if (radnik == null)
                {
                    return NotFound(new { poruka = "Radnik ne postoji u bazi" });
                }
                return Ok(_mapper.Map<RadnikDTO>(radnik));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        // POST api/v1/radnik
        [HttpPost]
        public async Task<IActionResult> Post(KreirajRadnikaDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }

            try
            {
                var radnik = _mapper.Map<Radnik>(dto);
                await _context.Radnici.AddAsync(radnik);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<RadnikDTO>(radnik));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        // PUT api/v1/radnik/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, AzurirajRadnikaDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }

            try
            {
                var radnik = await _context.Radnici.FindAsync(id);
                if (radnik == null)
                {
                    return NotFound(new { poruka = "Radnik ne postoji u bazi" });
                }

                _mapper.Map(dto, radnik);
                _context.Radnici.Update(radnik);
                await _context.SaveChangesAsync();
                return Ok(new { poruka = "Uspješno promijenjeno" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        // DELETE api/v1/radnik/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }

            try
            {
                var radnik = await _context.Radnici.FindAsync(id);
                if (radnik == null)
                {
                    return NotFound(new { poruka = "Radnik ne postoji u bazi" });
                }

                _context.Radnici.Remove(radnik);
                await _context.SaveChangesAsync();
                return Ok(new { poruka = "Uspješno obrisano" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }
    }
}
