namespace PresProductCategory.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        //public List<Product> Products { get; set; } = []; // ManyToMany Sans propriété dans la table intermédiaire
        public List<ProductCategory> ProductsCategories { get; set; } // ManyToMany Avec propriété dans la table intermédiaire
    }
}
