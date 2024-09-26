using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPaulovnija.Controllers.Models;
using WebApiPaulovnija.Data;
using WebApiPaulovnija.DTO;
using AutoMapper;

namespace WebApiPaulovnija.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RadnikController : ControllerBase
    {
        private readonly Paulovnijacontext _context;
        private readonly IMapper _mapper;

        public RadnikController(Paulovnijacontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var radnici = _context.Radnici.ToList();
                var radniciDto = _mapper.Map<List<RadnikDto>>(radnici);
                return Ok(radniciDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var radnik = _context.Radnici.Find(id);
            if (radnik == null)
            {
                return NotFound();
            }
            var radnikDto = _mapper.Map<RadnikDto>(radnik);
            return Ok(radnikDto);
        }

        [HttpPost]
        public IActionResult Create(KreirajRadnikaDTO createRadnikDto)
        {
            var radnik = _mapper.Map<Radnik>(createRadnikDto);
            _context.Radnici.Add(radnik);
            _context.SaveChanges();
            var radnikDto = _mapper.Map<RadnikDto>(radnik);
            return StatusCode(StatusCodes.Status201Created, radnikDto);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, AzurirajRadnikaDTO updatedRadnikDto)
        {
            var radnik = _context.Radnici.Find(id);
            if (radnik == null)
            {
                return NotFound();
            }

            _mapper.Map(updatedRadnikDto, radnik);
            _context.SaveChanges();
            var radnikDto = _mapper.Map<RadnikDto>(radnik);
            return Ok(radnikDto);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var radnik = _context.Radnici.Find(id);
            if (radnik == null)
            {
                return NotFound();
            }

            _context.Radnici.Remove(radnik);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
