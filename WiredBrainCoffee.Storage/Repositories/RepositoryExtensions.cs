using System;
namespace WiredBrainCoffee.Storage.Repositories
{
    public static class RepositoryExtensions
    {
        public static void AddBatch<T>(this IWriteRepository<T> repository, T[] items)
        {
            foreach (var organization in items)
            {
                repository.Add(organization);
            }

            repository.Save();

        }
    }
}
