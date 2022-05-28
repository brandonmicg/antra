using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class GenericRepository<T> : IRepository<T> where T : Entity
    {
        private List<T>? repository;

        public GenericRepository()
        {
            repository = new List<T>();
        }

        public void Add(T item)
        {
            repository.Add(item);
        }

        public IEnumerable<T> GetAll() => repository.AsEnumerable();

        public T GetById(int id) => repository.Find(x => x.Id == id);

        public void Remove(T item)
        {
            _ = repository.Remove(item);
        }

        public void Save()
        {
            Console.WriteLine("Data has been saved");
        }
    }
}
