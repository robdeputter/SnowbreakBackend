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
    public class SnowbreakDbContext : DbContext

    {

        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Ranking> Rankings { get; set; }
        public DbSet<Gebied> Gebieden { get; set; }
        public DbSet<GebiedRanking> GebiedRankings { get; set; }

        public SnowbreakDbContext(DbContextOptions<SnowbreakDbContext> options) :base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionstring =
        @"Server=.\SQLEXPRESS;Database=Snowbreak;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionstring);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EvenementConfiguration());
            modelBuilder.ApplyConfiguration(new RankingConfiguration());
            modelBuilder.ApplyConfiguration(new GebiedRankingConfiguration());
            modelBuilder.ApplyConfiguration(new GebiedConfiguration());
                

           
            

        }
    }
}
