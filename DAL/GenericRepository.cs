using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class GenericRepository<T>:IGenericRepository<T> where T : class
    {
        private BookContext BookContext;
        public GenericRepository(BookContext bookContext)
        {
            BookContext = bookContext;
        }

        public void Create(T entity)
        {
            BookContext.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            T entity = BookContext.Set<T>().Find(id);
            if (entity != null)
            {
                this.BookContext.Set<T>().Remove(entity);
            }
        }

        public IEnumerable<T> ReadAll(params string[] includes)
        {
            IQueryable<T> List = BookContext.Set<T>();
            if (includes.Length != 0)
            {
                foreach (var item in includes)
                {
                    List = List.Include(item);
                }
            }
            return List;
        }

        public IEnumerable<T> ReadAllBy(Func<T, bool> condition, params string[] includes)
        {
            return ReadAll(includes).Where(condition);
        }

        public T ReadBy(Func<T, bool> condition, params string[] includes)
        {
            return ReadAll(includes).FirstOrDefault(condition);
        }

        public void Update(T entity)
        {
            BookContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
