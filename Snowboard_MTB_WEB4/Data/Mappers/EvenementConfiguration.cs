using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Snowboard_MTB_WEB4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.Data.Mappers
{
    public class EvenementConfiguration : IEntityTypeConfiguration<Evenement>
    {
        public void Configure(EntityTypeBuilder<Evenement> builder)
        {
            //algemeen
            builder.ToTable("Evenement");
            builder.HasKey(e => e.Id);

            //properties
            builder.Property(e => e.Naam)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(e => e.Beschrijving)
                .IsRequired(true)
                .HasMaxLength(500);

            builder.Property(e => e.StartDatum)
                .IsRequired(true);

            builder.Property(e => e.EindDatum)
                .IsRequired(false);

            

            //relaties
            builder.HasOne(e => e.Gebied)
                    .WithMany()
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.Restrict);
                    
        }
    }
}
