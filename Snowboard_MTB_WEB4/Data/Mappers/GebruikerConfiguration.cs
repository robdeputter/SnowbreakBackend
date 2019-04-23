using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Snowboard_WEB4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.Data.Mappers
{
    public class GebruikerConfiguration : IEntityTypeConfiguration<Gebruiker>
    {
        public void Configure(EntityTypeBuilder<Gebruiker> builder)
        {
            builder.ToTable("Gebruiker");
            builder.HasKey(g => g.GebruikerId);
            builder.Property(g => g.Voornaam).IsRequired(true).HasMaxLength(50);
            builder.Property(g => g.Familienaam).IsRequired(true).HasMaxLength(50);
            builder.Property(g => g.Email).IsRequired(true).HasMaxLength(50);
        }
    }
}
