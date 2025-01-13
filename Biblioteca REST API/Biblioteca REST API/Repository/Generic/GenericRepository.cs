using Biblioteca_REST_API.Models.Base;
using Biblioteca_REST_API.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_REST_API.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;
        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return item;
        }

        public T Update(T item)
        {
            if (!Exists(item.Id)) return null;
            var result = dataset.SingleOrDefault(i => i.Id.Equals(item.Id));
            if (result is not null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                return null;
            }
            return result;
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(i => i.Id.Equals(id));
            if (result is not null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(i => i.Id.Equals(id));
        }

        public bool Exists(long id)
        {
            return dataset.Any(i => i.Id.Equals(id));
        }
    }
}
