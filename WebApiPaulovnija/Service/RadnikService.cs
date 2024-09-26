using System.Collections.Generic;
using System.Linq;
using WebApiPaulovnija.Controllers.Models;
using WebApiPaulovnija.Data;

namespace WebApiPaulovnija.Service
{
    public class RadnikService : IRadnikService
    {
        private readonly Paulovnijacontext _context;

        public RadnikService(Paulovnijacontext context)
        {
            _context = context;
        }

        public List<Radnik> GetAllRadnici()
        {
            return _context.Radnici.ToList();
        }

        public Radnik GetRadnikById(int id)
        {
            return _context.Radnici.Find(id);
        }

        public void CreateRadnik(Radnik radnik)
        {
            _context.Radnici.Add(radnik);
            _context.SaveChanges();
        }

        public void UpdateRadnik(Radnik radnik)
        {
            _context.Radnici.Update(radnik);
            _context.SaveChanges();
        }

        public void DeleteRadnik(Radnik radnik)
        {
            _context.Radnici.Remove(radnik);
            _context.SaveChanges();
        }
    }
}
