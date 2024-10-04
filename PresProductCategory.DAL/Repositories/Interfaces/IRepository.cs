namespace PresProductCategory.DAL.Repositories.Interfaces
{
    // Tout mes repositories vont devoir implémenter au moins ces 5 méthodes
    public interface IRepository<T, Key> 
    {
        public List<T> GetAll();
        public T? GetById(Key id);
        public T Create(T newEntity);
        public T Update(T updatedEntity);
        public bool Delete(T entity);
    }
}
