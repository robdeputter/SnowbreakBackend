using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_MTB_WEB4.Model
{
    public interface IRankingRepository
    {
        IEnumerable<Ranking> GetAll();
        Ranking GetById(int id);
        void Add(Ranking ranking);
        void Delete(Ranking ranking);
        void Update(Ranking ranking);
        void SaveChanges();
    }
}
