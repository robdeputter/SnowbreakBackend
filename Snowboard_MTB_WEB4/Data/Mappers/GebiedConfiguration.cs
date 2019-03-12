using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Snowboard_MTB_WEB4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.Data.Mappers
{
    public class GebiedConfiguration : IEntityTypeConfiguration<Gebied>
    {
        public void Configure(EntityTypeBuilder<Gebied> builder)
        {
            builder.ToTable("Gebied");
            builder.HasKey(g => g.Id);

            //props
            builder.Property(g => g.Naam)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(g => g.Land)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(g => g.HoogteGebied)
                .IsRequired(true);

            builder.Property(g => g.LengteGraad)
                .IsRequired(true);

            builder.Property(g => g.Breedtegraad)
                .IsRequired(true);

            builder.Property(g => g.AantalKmPiste)
                .IsRequired(true);



    }
    }
}
