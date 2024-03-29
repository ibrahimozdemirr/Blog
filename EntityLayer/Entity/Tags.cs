using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Tags
    {
        [Key]
        public Guid TagId { get; set; }
        public string? TagName { get; set; }
    }
}
