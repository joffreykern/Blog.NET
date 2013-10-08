using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DomainObjects
{
    public class CategoryDTO : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }      
        public virtual ICollection<PostDTO> Posts { get; set; }

        public CategoryDTO()
        {
            this.Posts = new HashSet<PostDTO>();
        }
    }
}
