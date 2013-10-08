using Blog.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Configurations
{
    class RoleConfiguration : EntityTypeConfiguration<RoleDTO>
    {
        public RoleConfiguration()
        {
            this.ToTable("Role");
            this.Property(x => x.Name).IsRequired();
        }
    }
}
