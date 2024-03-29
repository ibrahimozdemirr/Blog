using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Users
    {
        [Key]
        public Guid UserId { get; set; }
        public string? UserFullName { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword { get; set; } 
        public string? UserEmail { get; set; }
        public string? UserAbout { get; set; } 
        public string? UserPicture { get; set; }

        public bool? UserIsActive { get; set; }
        
        public virtual IEnumerable<Posts>? Posts { get; set; }

        public virtual IEnumerable<Comments>? Comments { get; set; }
    }
}
