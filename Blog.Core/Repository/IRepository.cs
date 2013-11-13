using Blog.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        void Add(TEntity instance);

        void Delete(int id);
        void Delete(TEntity instance);

        void Update(TEntity instance);

        TEntity First(int id);

        TEntity FindOne(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);

        int Count();

        int Count(Expression<Func<TEntity, bool>> predicate);

        bool Exists(Expression<Func<TEntity, bool>> predicate);

    }
}
