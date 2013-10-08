using Blog.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Configurations
{
    class PostConfiguration : EntityTypeConfiguration<PostDTO>
    {
        public PostConfiguration()
        {
            // Set Table name
            this.ToTable("Post");

            // Configure properties 
            this.Property(x => x.Title).IsRequired().HasMaxLength(255);
            this.Property(x => x.Url).IsRequired().HasMaxLength(255);
            this.Property(x => x.IsPublish).IsRequired();

            // Set Many-to-Many with Tags
            this.HasMany(x => x.Tags)
                .WithMany(x => x.Posts)
                .Map(m =>
                {
                    m.ToTable("PostsTags");
                    m.MapLeftKey("PostId");
                    m.MapRightKey("TagId");
                });

            // Set Many-To-One with Category
            this.HasRequired(x => x.Category)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.CategoryId)
                .WillCascadeOnDelete(false);

            // Set Many-to-One with User
            this.HasRequired(x => x.User)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
