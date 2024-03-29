using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Posts
    {
        [Key]
        public Guid PostId { get; set; }
        public string? PostName { get; set; }
        public string? PostDescription { get; set; }
        public DateTime? PostDate { get; set; }
        public bool? PostIsActive { get; set; }
        public Guid?  userId { get; set; }
        
        public Guid? categoryId { get; set; }
        
        public virtual Users? Users { get; set; }

        public virtual Categories? Categories { get; set; }
        public virtual IEnumerable<Comments>? Comments { get; set; }



    }
}
