using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DomainObjects
{
    public class RoleDTO : IEntity
    {
        public RoleDTO()
        {
            this.Users = new HashSet<UserDTO>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserDTO> Users { get; set; }

    }
}
