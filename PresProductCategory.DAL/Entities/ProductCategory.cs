namespace PresProductCategory.DAL.Entities
{
    /*
     * C'est class est utilisé pour la table intermédiaire de la ManyToMany AVEC une propriété dans la table intermédiaire
     */
    public class ProductCategory
    {
        public Category Category { get; set; }
        public Product Product { get; set; }
        public bool IsPrincipal { get; set; }
    }
}
