using Microsoft.AspNetCore.Mvc;
using WebApiPaulovnija.Data;

namespace WebApiPaulovnija.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class RadnikController : ControllerBase
    {
        private readonly Paulovnijacontext _context;

        public RadnikController(Paulovnijacontext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult get()
        {
            return Ok(_context.Radnici);
        }
        [HttpGet]
        [Route("{Radnici:int}")]
        public IActionResult Get(int Radnik)
        {
            var Radnici = _context.Radnici.Find(Radnik);
            if (Radnik == null)
            {
                return NotFound();

            }
            return Ok (Radnici);
        }
    }
}
