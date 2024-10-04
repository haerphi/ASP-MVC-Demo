using PresProductCategory.DAL.Database;
using PresProductCategory.DAL.Entities;
using PresProductCategory.DAL.Repositories.Interfaces;

namespace PresProductCategory.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _ShopContext; // variable pour accès à la DB

        public ProductRepository(ShopContext context) // injection de dépendance via program.cs
        {
            _ShopContext = context;
        }

        public Product Create(Product newEntity)
        {
            Product createdProduct = _ShopContext.Products.Add(newEntity).Entity; // on ajout un produit dans le "dbcontext"
            _ShopContext.SaveChanges(); // on sauvegarde dans la DB
            return createdProduct;
        }

        public bool Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _ShopContext.Products.ToList();
        }

        public Product? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product updatedEntity)
        {
            throw new NotImplementedException();
        }
    }
}
