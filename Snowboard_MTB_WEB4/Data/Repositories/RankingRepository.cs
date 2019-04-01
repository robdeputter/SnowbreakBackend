using Microsoft.EntityFrameworkCore;
using Snowboard_MTB_WEB4.Data;
using Snowboard_MTB_WEB4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.Data.Repositories
{
    public class RankingRepository : IRankingRepository
    {
        private DbSet<Ranking> _rankings;
        private SnowbreakDbContext _context;

        public RankingRepository(SnowbreakDbContext context)
        {
            _context = context;
            _rankings = context.Rankings;
        }

        public void Add(Ranking ranking)
        {
            _rankings.Add(ranking);
        }

        public void Delete(Ranking ranking)
        {
            _rankings.Remove(ranking);
        }

        public IEnumerable<Ranking> GetAll()
        {
            return _rankings
                .Include(r => r.Gebieden)
                .ThenInclude(ge => ge.Gebied)
                .ToList();
        }

        public Ranking GetById(int id)
        {
            return _rankings
                .Include(r => r.Gebieden).ThenInclude(ge => ge.Gebied)
                .SingleOrDefault(r => r.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Ranking ranking)
        {
            _rankings.Update(ranking);
        }
    }
}
