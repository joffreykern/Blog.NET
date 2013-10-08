using Blog.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Configurations
{
    class TagConfiguration : EntityTypeConfiguration<TagDTO>
    {
        public TagConfiguration()
        {
            this.ToTable("Tag");
            this.Property(x => x.Name).IsRequired();
        }
    }
}
