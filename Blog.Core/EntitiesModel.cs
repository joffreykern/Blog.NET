using Blog.Core.Configurations;
using Blog.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core
{
    public class EntitiesModel : DbContext
    {
        public DbSet<PostDTO> Posts { get; set; }
        public DbSet<CategoryDTO> Categories { get; set; }
        public DbSet<TagDTO> Tags { get; set; }
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<RoleDTO> Roles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<PostDTO>(new PostConfiguration());
            modelBuilder.Configurations.Add<CategoryDTO>(new CategoryConfiguration());
            modelBuilder.Configurations.Add<TagDTO>(new TagConfiguration());
            modelBuilder.Configurations.Add<UserDTO>(new UserConfiguration());
            modelBuilder.Configurations.Add<RoleDTO>(new RoleConfiguration());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
