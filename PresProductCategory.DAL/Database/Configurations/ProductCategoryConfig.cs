using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PresProductCategory.DAL.Entities;

namespace PresProductCategory.DAL.Database.Configurations
{
    // ManyToMany Avec propriété dans la table intermédiaire + Shadowing
    public class ProductCategoryConfig : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategory"); // On force le nom de la table à ProductCategory

            // COLUMNS
            builder.Property<int>("ProductId"); // On crée une colonne cachée pour la PK/FK
            builder.Property<int>("CategoryId"); // On crée une colonne cachée pour la PK/FK

            // CONSTRAINS
            builder.HasKey("ProductId", "CategoryId")
                .HasName("PK_ProductCategory"); // On force le nom de la PK à PK_ProductCategory

            // RELATIONS
            /* Étant donné que nous sommes dans la configuration de la table intermédiaire de notre ManyToMany,
             * nous devons faire les One To Many des deux côtés de la relation.
             */

            // Relation vers Product
            builder.HasOne(pc => pc.Product)
                .WithMany(p => p.ProductsCategories)
                .HasForeignKey("ProductId");

            // Relation vers Category
            builder.HasOne(pc => pc.Category)
                .WithMany(c => c.ProductsCategories)
                .HasForeignKey("CategoryId");
        }
    }
}
