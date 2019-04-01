using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Snowboard_WEB4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.Data.Mappers
{
    public class GebiedRankingConfiguration : IEntityTypeConfiguration<GebiedRanking>
    {
        public void Configure(EntityTypeBuilder<GebiedRanking> builder)
        {
            builder.ToTable("GebiedRanking");
            builder.HasKey(g => new { g.GebiedId, g.RankingId});

            //builder.HasOne(g => g.Ranking)
            //    .WithMany(r => r.Gebieden)
            //    .HasForeignKey(r => r.RankingId)
            //    .IsRequired(true)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.Gebied)
                .WithMany()
                .HasForeignKey(g => g.GebiedId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(g => g.Positie)
                .IsRequired(true);

            
        }
    }
}
