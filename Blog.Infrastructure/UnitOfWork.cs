using Blog.Core;
using Blog.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntitiesModel _context;
        public EntitiesModel Context
        {
            get
            {
                return _context;
            }
        }

        protected UnitOfWork(EntitiesModel context)
        {
            this._context = context;
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
