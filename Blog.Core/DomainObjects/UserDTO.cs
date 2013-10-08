using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DomainObjects
{
    public class UserDTO : IEntity
    {
        public UserDTO()
        {
            this.Posts = new HashSet<PostDTO>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public virtual RoleDTO Role { get; set; }

        
        
        public ICollection<PostDTO> Posts { get; set; }

        public static string HashPassword(string password)
        {
            SHA1 sha1 = SHA1.Create();
            byte[] b = sha1.ComputeHash(new UTF8Encoding().GetBytes(password));
            return BitConverter.ToString(b).Replace("-", "");
        }
    }
}
