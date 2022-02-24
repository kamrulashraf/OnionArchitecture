using OA.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo
{
    public interface IRepository <T>
    {
        IEnumerable<T> GetAll();
        T get(int? id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
