using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Snowboard_MTB_WEB4.Model;
using Snowboard_WEB4.Data.Mappers;
using Snowboard_WEB4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_MTB_WEB4.Data
{
    public class SnowbreakDbContext : IdentityDbContext

    {

        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Ranking> Rankings { get; set; }
        public DbSet<Gebied> Gebieden { get; set; }
        public DbSet<GebiedRanking> GebiedRankings { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }

        public SnowbreakDbContext(DbContextOptions<SnowbreakDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new EvenementConfiguration());
            builder.ApplyConfiguration(new RankingConfiguration());
            builder.ApplyConfiguration(new GebiedRankingConfiguration());
            builder.ApplyConfiguration(new GebiedConfiguration());
            builder.ApplyConfiguration(new GebruikerConfiguration());
            
        }
    }
}
