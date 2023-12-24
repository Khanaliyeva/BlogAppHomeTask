using BlogApp.Core.Entities.Common;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repository.Implimentations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();


        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>?
            expression = null,
            Expression<Func<TEntity, object>>? OrderByExpression = null,
            bool IsDescending = false,
            params string[] includes)

        {
            IQueryable<TEntity> query = Table.Where(e=>!e.IsDeleted);
            if (expression != null)
            { 
                query = query.Where(expression);
            }
            if(OrderByExpression != null)
            {
                query = IsDescending ? query.OrderBy(OrderByExpression) :
                    query.OrderBy(OrderByExpression);
            }
            if(includes  != null)
            {
                for(int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            return query;
        }
        public async Task CreateAsync(TEntity entity)
        {
            Table.AddAsync(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
