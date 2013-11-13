using Blog.Core;
using Blog.Core.DomainObjects;
using Blog.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected EntitiesModel Context { get; private set; }

        protected Repository(EntitiesModel context)
        {
            Context = context;
        }

        public Repository(IContextFactory contextFactory)
            : this(contextFactory.Get())
        {
        }

        public void Add(TEntity instance)
        {
            this.Context.Entry<TEntity>(instance).State = System.Data.Entity.EntityState.Added;
        }

        public void Delete(int id)
        {
            this.Context.Entry<TEntity>(First(id)).State = System.Data.Entity.EntityState.Deleted;
        }
        public void Delete(TEntity instance)
        {
            this.Context.Entry<TEntity>(instance).State = System.Data.Entity.EntityState.Deleted;
        }

        public void Update(TEntity instance)
        {
            TEntity oldInstance = First(instance.Id);
            this.Context.Entry<TEntity>(oldInstance).CurrentValues.SetValues(instance);
        }

        public TEntity First(int id)
        {
            return this.Context.Set<TEntity>().SingleOrDefault(x => x.Id == id);
        }

        public TEntity FindOne(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.Context.Set<TEntity>().AsEnumerable();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().Where(predicate);
        }

        public int Count()
        {
            return this.Context.Set<TEntity>().Count();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().Count(predicate);
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().Any(predicate);
        }
    }
}
