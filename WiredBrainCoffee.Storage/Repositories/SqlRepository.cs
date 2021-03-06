using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.Storage.Entities;

namespace WiredBrainCoffee.Storage.Repositories
{

    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly List<T> _items = new List<T>();
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        

        public SqlRepository(DbContext dbContext)
        {
            this._dbContext = dbContext;
            
            this._dbSet = this._dbContext.Set<T>();
        }

        public event EventHandler<T>? ItemAdded;

        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item => item.Id).ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
            ItemAdded?.Invoke(this, item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }
    }

}
