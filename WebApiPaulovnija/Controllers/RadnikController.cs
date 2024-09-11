
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiPaulovnija.Controllers.Models;
using WebApiPaulovnija.Data;

namespace WebApiPaulovnija.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RadnikController : ControllerBase
    {
        private readonly Paulovnijacontext _context;
        public RadnikController(Paulovnijacontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Radnici);

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            var radnik = _context.Radnici.Find(id);
            if (radnik == null)
            {
                return NotFound();
            }
            return Ok(radnik);
        }

        [HttpPost]
        public IActionResult Post(Radnik radnik)
        {
            _context.Radnici.Add(radnik);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, radnik);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Put(int id, Radnik updatedRadnik)
        {
            var radnik = _context.Radnici.Find(id);
            if (radnik == null)
            {
                return NotFound();
            }

            
            radnik.Ime = updatedRadnik.Ime;
            radnik.Prezime = updatedRadnik.Prezime;
            radnik.Godine = updatedRadnik.Godine;
            radnik.Pozicija = updatedRadnik.Pozicija;
            radnik.Plata = updatedRadnik.Plata;
            

            _context.SaveChanges();
            return Ok(radnik);
        }

        [HttpDelete]
        [Route("{id:int}")]
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
