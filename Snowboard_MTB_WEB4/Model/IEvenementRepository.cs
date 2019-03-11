using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_MTB_WEB4.Model
{
    public interface IEvenementRepository
    {
        IEnumerable<Evenement> GetAll();
        Evenement GetById(int id);
        void Add(Evenement evenement);
        void Delete(Evenement evenement);
        void Update(Evenement evenement);
        void SaveChanges();
    }
}
