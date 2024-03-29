using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Categories
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }

        
        public virtual IEnumerable<Posts>? Posts { get; set; }
    }
}
