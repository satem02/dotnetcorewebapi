using System;
using System.Linq;
using System.Linq.Expressions;
using Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Business.Base
{
 public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext dbContext;
        public DbSet<T> Table { get; set; }
        
        public Repository(DataContext dbContext)
        {
            this.dbContext = dbContext;
            this.Table = dbContext.Set<T>();
        }

        public bool Add(T entity)
        {
            Table.Add(entity);
            return Save();
        }

        public bool Update(T entity)
        {
            Table.Update(entity);
            return Save();
        }

        public bool Delete(T entity)
        {
            Table.Remove(entity);
            return Save();
        }

        public IQueryable<T> All()
        {
            return Table;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> where)
        {
            return Table.Where(where);
        }

        public IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc)
        {
            if (isDesc)
                return Table.OrderByDescending(orderBy);
            return Table.OrderBy(orderBy);
        }


        private bool Save()
        {
            try
            {
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                // TODO: Log Exceptions
                return false;
            }
        }
    }
}