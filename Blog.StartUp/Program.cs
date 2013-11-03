using Blog.Core;
using Blog.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EntitiesModel context = new EntitiesModel())
            {
                // Supprime la BDD si elle existe
                context.Database.Delete();

                RoleDTO role = new RoleDTO() { Name = "Administrator" };
                context.Roles.Add(role);
                context.SaveChanges();

                UserDTO user = new UserDTO() { Username = "admin", Password = UserDTO.HashPassword("admin") };
                role.Users.Add(user);

                context.Users.Add(user);
                context.SaveChanges();

                CategoryDTO category = new CategoryDTO() { Name = "Blog.NET" };
                context.Categories.Add(category);
                context.SaveChanges();

                PostDTO post = new PostDTO() { Title = "First post", Url = "first-post", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus vel bibendum ante, et iaculis urna. Phasellus eleifend ligula turpis, non vulputate est sodales ac. Nullam urna eros, congue venenatis quam id, placerat fringilla sapien. Integer auctor, massa et vulputate iaculis, dolor libero malesuada purus, et varius est urna quis est. Proin congue lorem ac pretium condimentum. Etiam arcu enim, rutrum eget scelerisque ac, fermentum sollicitudin purus. Donec faucibus sem dui, vitae convallis leo imperdiet in. Ut tincidunt imperdiet velit et vulputate. Donec lorem erat, congue in augue eget, aliquet elementum libero. Ut non euismod dui. Maecenas cursus justo id mi vulputate, at mollis est dignissim. Fusce sodales, ligula in vestibulum hendrerit, ante ante adipiscing sapien, at venenatis tortor turpis mattis ante. Integer sed malesuada orci. " };
                post.User = user;
                post.Category = category;

                context.Posts.Add(post);
                context.SaveChanges();
            }
        }
    }
}
