using WiredBrainCoffee.Storage.Entities;

namespace WiredBrainCoffee.Storage.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        void Add(T item);
        T GetById(int id);
        void Remove(T item);
        void Save();
    }
}