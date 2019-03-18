using Snowboard_MTB_WEB4.Data;
using Snowboard_MTB_WEB4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.Data
{
    public class SnowbreakDataInitializer
    {
        private SnowbreakDbContext _context;

        public SnowbreakDataInitializer(SnowbreakDbContext context)
        {
            _context = context;
        }

        public void InitializeData()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                //gebieden
                Gebied valthorens = new Gebied("Val Thorens", "Frankrijk",Continent.EUROPA, "45.292165498", "6.574664368", 86, 2300);
                Gebied sölden = new Gebied("Sölden", "Oostenrijk", Continent.EUROPA, "11.0076232", "46.9654937", 144, 3244);
                Gebied laax = new Gebied("Laax", "Zwitserland", Continent.EUROPA, "9.265110", "46.823930", 188, 1016);
                Gebied whistler = new Gebied("Whistler", "Canada", Continent.NOORD_AMERIKA, "-122.957359", "50.116322", 200, 670);

                //evenementen
                Evenement ninesAudi = new Evenement("9nines AUDI", "Jaarlijks evenement voor snowboarders en skiërs",
                    new DateTime(2019, 04, 22), new DateTime(2019, 04, 27), sölden);

                Evenement theBrits2019 = new Evenement("The Brits 2019", "The BRITS – Muziek & Winter Sportfestival met de Britse Snowboard en Freeski Championships",
                    new DateTime(2019, 03, 31), new DateTime(2019, 04, 07), laax);

                Evenement worldSkiSnowboardFestival = new Evenement("World ski and snowboard festival 2019",
                    "Het grootste wintersport en muziekfestival van Noord-Amerika!", new DateTime(2019, 04, 10),
                    new DateTime(2019, 04, 14), whistler);
                //rankings beste gebieden!

                //gebieden
                _context.Gebieden.Add(valthorens);
                _context.Gebieden.Add(sölden);
                _context.Gebieden.Add(laax);
                _context.Gebieden.Add(whistler);
                
                //evenementen
                _context.Evenements.Add(ninesAudi);
                _context.Evenements.Add(theBrits2019);
                _context.Evenements.Add(worldSkiSnowboardFestival);
                
                _context.SaveChanges();
            }
        }

    }
}
