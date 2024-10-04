using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PresProductCategory.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresProductCategory.DAL.Database.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category"); // On force le nom de la table à Category

            // COLUMNS
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd(); // le ID est généré et incrémenté automatiquement

            builder.Property(c => c.Name)
                .HasMaxLength(50) // maximum 50 characters dans le nom
                .IsRequired(); // le nom est obligatoire

            // CONSTRAINS
            // PK
            builder.HasKey(c => c.Id)
                .HasName("PK_Category"); // On force le nom de la PK à PK_Category

            // INDEX
            builder.HasIndex(c => c.Name)
                .IsUnique(); // On force le nom de la catégorie à être unique
        }
    }
}
