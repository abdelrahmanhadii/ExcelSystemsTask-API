using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IGenericRepository<T> where T : class
    {
        void Create(T entity);

        void Delete(int id);

        IEnumerable<T> ReadAll(params string[] includes);

        IEnumerable<T> ReadAllBy(Func<T, bool> condition, params string[] includes);

        T ReadBy(Func<T, bool> condition, params string[] includes);

        void Update(T entity);
    }
}
