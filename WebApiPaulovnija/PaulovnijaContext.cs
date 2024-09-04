using Microsoft.EntityFrameworkCore;
using WebApiPaulovnija.Controllers.Models;


namespace WebApiPaulovnija.Data
{
    public class Paulovnijacontext : DbContext
    {

        public Paulovnijacontext(DbContextOptions<Paulovnijacontext> opcije) : base(opcije) { }

        public DbSet<Radnik> Radnici {  get; set; } 
    }
}
