using Microsoft.EntityFrameworkCore;
using Snowboard_MTB_WEB4.Data;
using Snowboard_MTB_WEB4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.Data.Repositories
{
    public class EvenementRepository : IEvenementRepository
    {
        private DbSet<Evenement> _evenementen;
        private SnowbreakDbContext _context;

        public EvenementRepository(SnowbreakDbContext context)
        {
            _context = context;
            _evenementen = context.Evenements;
        }
        public void Add(Evenement evenement)
        {
            _evenementen.Add(evenement);
        }

        public void Delete(Evenement evenement)
        {
            _evenementen.Remove(evenement);
        }

        public IEnumerable<Evenement> GetAll()
        {
            return _evenementen
                .Include(e => e.Gebied)
                .ThenInclude(g => g.Rankings)
                .ToList();
        }

        public Evenement GetById(int id)
        {
            return _evenementen
                .Include(e => e.Gebied)
                .ThenInclude(g => g.Rankings)
                .SingleOrDefault(e => e.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Evenement evenement)
        {
            _evenementen.Update(evenement);
        }
    }
}
