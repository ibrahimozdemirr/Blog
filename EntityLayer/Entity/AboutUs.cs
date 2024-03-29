using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public  class AboutUs
    {
        [Key]
        public Guid AboutId { get; set; }
        public string? AboutContent { get; set; }
        public DateTime? AboutDate { get; set; }
    }
}
