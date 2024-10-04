namespace PresProductCategory.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        //public List<Category> Categories { get; set; } = []; // ManyToMany Sans propriété dans la table intermédiaire
        public List<ProductCategory> ProductsCategories { get; set; } // ManyToMany Avec propriété dans la table intermédiaire
    }
}
