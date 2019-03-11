using Microsoft.EntityFrameworkCore;
using Snowboard_MTB_WEB4.Model;
using Snowboard_WEB4.Data.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_MTB_WEB4.Data
{
    public class SnowbreakDbContext : DbContext
    {
        public SnowbreakDbContext(DbContextOptions<SnowbreakDbContext> options) :base(options)
        {
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
