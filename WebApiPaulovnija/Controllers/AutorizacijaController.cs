using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPaulovnija.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    
    public class AutorizacijaController : ControllerBase
    {
        /// <summary>
        /// Generates a JWT token based on user credentials.
        /// </summary>
        /// <param name="loginDto">Login credentials.</param>
        /// <returns>JWT token if credentials are valid.</returns>
        [HttpPost("token")]
        public IActionResult GenerirajToken([FromBody] LoginDTO loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            const string fixKorisnickoIme = "Leon";
            const string fixLozinka = "1234";

            if (loginDto.KorisnickoIme != fixKorisnickoIme || loginDto.Lozinka != fixLozinka)
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Niste autorizirani, korisničko ime ili lozinka su netočni.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("MojKljucKojijeJakoTajan i dovoljno dugačak da se može koristiti");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, loginDto.KorisnickoIme) }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return Ok(new { Token = jwt });
        }

        /// <summary>
        /// Gets protected data for authorized users.
        /// </summary>
        /// <returns>Protected data.</returns>
        [Authorize]
        [HttpGet("protected-data")]
        public IActionResult GetProtectedData()
        {
            return Ok(new { Message = "Ovo je zaštićena informacija!" });
        }
    }
}
