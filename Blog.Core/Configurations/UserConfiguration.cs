using Blog.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Configurations
{
    class UserConfiguration : EntityTypeConfiguration<UserDTO>
    {
        public UserConfiguration()
        {
            this.ToTable("User");
            this.Property(x => x.Username).IsRequired();

            this.HasRequired(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId)
                .WillCascadeOnDelete(false);

        }
    }
}
