using BlogApp.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>?
            expression = null,
            Expression<Func<TEntity, object>>? OrderByExpression = null,
            bool IsDescending = false,
            params string[] includes);
        DbSet<TEntity> Table { get; }

        Task CreateAsync(TEntity entity);
        Task<int> SaveChangesAsync();
    }
}
