using Microsoft.AspNetCore.Identity;
using Snowboard_MTB_WEB4.Data;
using Snowboard_MTB_WEB4.Model;
using Snowboard_WEB4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.Data
{
    public class SnowbreakDataInitializer
    {
        private SnowbreakDbContext _context;
        private UserManager<IdentityUser> _userManager;

        public SnowbreakDataInitializer(SnowbreakDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                //gebruikers
                Gebruiker gebruiker = new Gebruiker("Rob", "De Putter", "robdeputter@hotmail.com");
                gebruiker.IsAdmin = true;

                //gebieden voor evenementen
                Gebied sölden = new Gebied("Sölden", "Oostenrijk", Continent.EUROPA, "11.0076232", "46.9654937", 144, 3244);
                Gebied whistler = new Gebied("Whistler", "Canada", Continent.NOORD_AMERIKA, "-122.957359", "50.116322", 200, 670);
                Gebied haugastøl = new Gebied("Haugastøl", "Noorwegen", Continent.EUROPA, "7.867799", "60.511639", 50, 592);
                Gebied beijing = new Gebied("Beijing", "China", Continent.AZIË, "116.363625", "39.913818", 50, 820);

                //top 10 europa
                Gebied brixenTal = new Gebied("Brixental", "Oostenrijk", Continent.EUROPA, "12.190926", "47.503113", 284, 1860);
                Gebied valDisère = new Gebied("Val d'Isère", "Frankrijk", Continent.EUROPA, "6.979605", "45.446912", 300, 3456);
                Gebied laax = new Gebied("Laax", "Zwitserland", Continent.EUROPA, "9.265110", "46.823930", 188, 1016);
                Gebied lesTroisVallées = new Gebied("Les Trois Vallées", "Frankrijk", Continent.EUROPA, "6.525255", "45.484036", 600, 3230);
                Gebied silvrettArenaIschgl = new Gebied("Silvretta Arena Ischgl - Samnaun", "Oostenrijk", Continent.EUROPA, "10.288000", "47.010023", 239, 2872);
                Gebied serfausFissLadis = new Gebied("Serfaus - Fiss - Ladis", "Oostenrijk", Continent.EUROPA, "10.607579", "47.038905", 198, 2820);
                Gebied hochZillertalHochfügen = new Gebied("Hochzillertal - Hochfügen", "Oostenrijk", Continent.EUROPA, "11.873215", "47.289957", 85, 2378);
                Gebied breuilCervinia = new Gebied("Breuil-Cervinia", "Italië", Continent.EUROPA, "7.629142", "45.933559", 322, 3899);
                Gebied lesQuatreVallées = new Gebied("Les Quatre Vallées", "Frankrijk", Continent.EUROPA, "45.914507", "6.131787", 412, 3330);
                Gebied valGardena = new Gebied("Val Gardena", "Italië", Continent.EUROPA, "11.724774", "46.570590", 175, 2518);

                //ranking Europa
                Ranking rankingEuropa = new Ranking("Top 10 Europa", Continent.EUROPA);
                




                //evenementen
                Evenement ninesAudi = new Evenement("9nines AUDI", "Jaarlijks evenement voor snowboarders en skiërs",
                    new DateTime(2020, 04, 22), new DateTime(2020, 04, 27), sölden);

                Evenement theBrits2019 = new Evenement("The Brits 2019", "The BRITS – Muziek & Winter Sportfestival met de Britse Snowboard en Freeski Championships",
                    new DateTime(2020, 03, 31), new DateTime(2020, 04, 07), laax);

                Evenement worldSkiSnowboardFestival = new Evenement("World ski and snowboard festival 2019",
                    "Het grootste wintersport en muziekfestival van Noord-Amerika!", new DateTime(2020, 04, 10),
                    new DateTime(2020, 04, 14), whistler);

                Evenement redBullRagnarok = new Evenement("Red Bull Ragnarok", "The world’s biggest Snow-Kite Race"
                    , new DateTime(2020, 03, 04), new DateTime(2020, 04, 07), haugastøl);

                Evenement winterOlympics = new Evenement("2022 Winter Olympics", "The 2022 Winter Olympics, also known as XXIV Olympic Winter Games will be the 24th winter multi-sports event by IOC.",
                                                new DateTime(2022, 02, 04), new DateTime(2022, 02, 20), beijing);
                //rankings beste gebieden!

                //gebieden
                _context.Gebieden.Add(sölden);
                _context.Gebieden.Add(whistler);
                _context.Gebieden.Add(haugastøl);
                _context.Gebieden.Add(beijing);

                //top 10 europa
                _context.Gebieden.Add(brixenTal);
                _context.Gebieden.Add(valDisère);
                _context.Gebieden.Add(laax);
                _context.Gebieden.Add(lesTroisVallées);
                _context.Gebieden.Add(silvrettArenaIschgl);
                _context.Gebieden.Add(serfausFissLadis);
                _context.Gebieden.Add(hochZillertalHochfügen);
                _context.Gebieden.Add(breuilCervinia);
                _context.Gebieden.Add(lesQuatreVallées);
                _context.Gebieden.Add(valGardena);

                rankingEuropa.AddGebied(brixenTal, 1);
                rankingEuropa.AddGebied(valDisère, 2);
                rankingEuropa.AddGebied(laax, 3);
                rankingEuropa.AddGebied(lesTroisVallées, 4);
                rankingEuropa.AddGebied(silvrettArenaIschgl, 5);
                rankingEuropa.AddGebied(serfausFissLadis, 6);
                rankingEuropa.AddGebied(hochZillertalHochfügen, 7);
                rankingEuropa.AddGebied(breuilCervinia, 8);
                rankingEuropa.AddGebied(lesQuatreVallées, 9);
                rankingEuropa.AddGebied(valGardena, 10);

                //ranking europa
                _context.Rankings.Add(rankingEuropa);

                //evenementen
                _context.Evenements.Add(ninesAudi);
                _context.Evenements.Add(theBrits2019);
                _context.Evenements.Add(worldSkiSnowboardFestival);
                _context.Evenements.Add(redBullRagnarok);
                _context.Evenements.Add(winterOlympics);

                //USERS
                Gebruiker administrator = new Gebruiker("Rob", "De Putter", "robdeputter@hotmail.com");
                administrator.IsAdmin = true;
                _context.Gebruikers.Add(administrator);
                await CreateUser(administrator.Email, "P@ssword1111");

                Gebruiker tim = new Gebruiker("Tim", "Geldof", "timgeldof@hotmail.com");
                _context.Gebruikers.Add(tim);
                await CreateUser(administrator.Email,"P@ssword1111");
                
                _context.SaveChanges();
            }
        }
        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }

    }
}
