using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Snowboard_MTB_WEB4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.Data.Mappers
{
    public class RankingConfiguration : IEntityTypeConfiguration<Ranking>
    {
        public void Configure(EntityTypeBuilder<Ranking> builder)
        {
            builder.ToTable("Ranking");
            builder.HasKey(r => r.Id);

            //properties
            builder.Property(r => r.Naam)
                .IsRequired(true)
                .HasMaxLength(100);


            builder.Property(r => r.Continent)
                .IsRequired(true);
        }
    }
}
