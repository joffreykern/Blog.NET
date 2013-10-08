using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DomainObjects
{
    public class PostDTO : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ContentPreview { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual CategoryDTO Category { get; set; }
        public int CategoryId { get; set; }
        public bool IsPublish { get; set; }
        public virtual UserDTO User { get; set; }
        public int UserId { get; set; }
        public virtual ICollection<TagDTO> Tags { get; set; }

        public PostDTO()
        {
            this.IsPublish = false;
            this.Tags = new HashSet<TagDTO>();
            this.CreatedDate = DateTime.Now;
            this.PublishDate = DateTime.Now;
        }
    }
}
