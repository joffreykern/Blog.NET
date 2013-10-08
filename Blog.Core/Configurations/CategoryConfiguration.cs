using Blog.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Configurations
{
    class CategoryConfiguration : EntityTypeConfiguration<CategoryDTO>
    {
        public CategoryConfiguration()
        {
            this.ToTable("Category");
            this.Property(x => x.Name).IsRequired();
        }
    }
}
