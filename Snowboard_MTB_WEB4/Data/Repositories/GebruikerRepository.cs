using Microsoft.EntityFrameworkCore;
using Snowboard_MTB_WEB4.Data;
using Snowboard_WEB4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.Data.Repositories
{
    public class GebruikerRepository : IGebruikerRepository
    {
        private SnowbreakDbContext _context;
        private DbSet<Gebruiker> _gebruikers;

        public GebruikerRepository(SnowbreakDbContext context)
        {
            _context = context;
            _gebruikers = _context.Gebruikers;
        }

        public void Add(Gebruiker gebruiker)
        {
            _gebruikers.Add(gebruiker);
        }

        public void Delete(Gebruiker gebruiker)
        {
            _gebruikers.Remove(gebruiker);

        }

        public IEnumerable<Gebruiker> GetAll()
        {
            return _gebruikers.OrderBy(g => g.Familienaam).ToList();
        }

        public Gebruiker GetByEmail(string email)
        {
            return _gebruikers.FirstOrDefault(g => g.Email.Equals(email));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
