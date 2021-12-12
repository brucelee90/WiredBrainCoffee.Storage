﻿using System;
using System.Collections.Generic;
using WiredBrainCoffee.Storage.Entities;

namespace WiredBrainCoffee.Storage.Repositories
{
    public class GenericRepository<T>
    {
        private readonly List<T> _items = new List<T>();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Save()
        {
            foreach (var employee in _items)
            {
                Console.WriteLine(employee);
            }
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }
    }

}
