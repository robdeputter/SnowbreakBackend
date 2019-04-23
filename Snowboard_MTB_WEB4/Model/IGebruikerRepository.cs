using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.Model
{
    public interface IGebruikerRepository
    {
        IEnumerable<Gebruiker> GetAll();
        Gebruiker GetByEmail(string email);
        void Add(Gebruiker gebruiker);
        void Delete(Gebruiker gebruiker);
        void SaveChanges();
    }
}
