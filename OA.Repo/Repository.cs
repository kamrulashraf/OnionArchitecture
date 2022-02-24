using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OA.Data;

namespace OA.Repo
{
    public class Repository<T> : IRepository<T> where T : BaseClass
    {
        private readonly DataBaseContext _context;
        private DbSet<T> entities;

        public Repository(DataBaseContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public T get(int? id)
        {
          return entities.Where(m => m.Id == id).FirstOrDefault();
         
        }

        public IEnumerable<T> GetAll()
        {
            return entities.Select(m=>m).AsEnumerable();
        }

        public void Insert(T entity)
        {
            entities.Add(entity);
            _context.SaveChanges();
        }
    }
}
