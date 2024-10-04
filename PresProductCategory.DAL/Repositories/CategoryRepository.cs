using PresProductCategory.DAL.Database;
using PresProductCategory.DAL.Entities;
using PresProductCategory.DAL.Repositories.Interfaces;

namespace PresProductCategory.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopContext _shopContext; // variable pour accès à la DB
        public CategoryRepository(ShopContext shopContext) // injection de dépendance via program.cs
        {
            _shopContext = shopContext;
        }

        public Category Create(Category newEntity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category updatedEntity)
        {
            throw new NotImplementedException();
        }
    }
}
