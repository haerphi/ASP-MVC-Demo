using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PresProductCategory.DAL.Entities;

namespace PresProductCategory.DAL.Database.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product"); // On force le nom de la table à Product

            // COLUMNS
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd(); // le ID est généré et incrémenté automatiquement
            
            builder.Property(p => p.Name)
                .HasMaxLength(50) // maximum 50 characters dans le nom
                .IsRequired(); // le nom est obligatoire

            // CONSTRAINS
            // PK
            builder.HasKey(p => p.Id)
                .HasName("PK_Product");

            #region Many to Many - Sans propriété dans la table intermédiaire
            /* ManyToMany Sans propriété dans la table intermédiaire
             * Grâce à cette technique, on peut ajouter des produits à des catégories et des catégories à des produits
             * sans devoir créer la table intermédiaire en C#.
             * 
             * ATTENTION: dans cette exemple, l'ordre de la déclaration des relations est important.
             * Nous nous trouvons dans la configuration de la table Product, donc:
             *  - on commence par déclarer la relation en commençant par Product : .HasMany(p => p.Categories)
             *  - on déclare ensuite la relation vers Category : .WithMany(c => c.Products)
             *  - on termine par la déclaration de la table intermédiaire : .UsingEntity(...)
             *  
             *  Dans le UsingEntity, 
             *  - En premier lieu, on déclare le nom de la table intermédiaire
             *  - il faut faire attention à l'ordre des déclarations: elle doit être dans l'ordre inverse des déclarations précédentes:
             *      - on a commencé avec Product (builder.HasMany(p => p.Categories)), donc on commence le UsingEntity par Category : left.HasOne(typeof(Category))...
             *      - on a terminé avec Category (.WithMany(c => c.Products)), donc on termine le UsingEntity par Product : right.HasOne(typeof(Product))...
             *  - Pour finir , on déclare la clé primaire de la table intermédiaire (avec les mêmes noms déclarés précédement): j.HasKey("CategoryId", "ProductId")
            */

            /*
            builder.HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .UsingEntity("MM_Product_Category", // nom de la table intermédiaire
                    left => left.HasOne(typeof(Category)).WithMany().HasForeignKey("CategoryId").HasPrincipalKey(nameof(Category.Id)), // déclaration de la relation vers Category
                    right => right.HasOne(typeof(Product)).WithMany().HasForeignKey("ProductId").HasPrincipalKey(nameof(Product.Id)), // déclaration de la relation vers Product
                    join => join.HasKey("CategoryId", "ProductId") // déclaration de la clé primaire de la table intermédiaire (qui est une clé primaire composite)
                );
            */
            #endregion
        }
    }
}
