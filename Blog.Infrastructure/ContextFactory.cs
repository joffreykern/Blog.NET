using Blog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure
{
    public class ContextFactory : Blog.Infrastructure.IContextFactory
    {
        private EntitiesModel _context;
        public EntitiesModel Get()
        {
            if (_context == null)
            {
                _context = new EntitiesModel();
            }

            return _context;
        }
    }
}
