using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
    public class Comments
    {
        [Key]
        public Guid CommentId { get; set; }

        public string? CommentWritername { get; set; }

        public string? CommentDescription { get; set; }

        public string? CommentPhoto { get; set; }

        public DateTime? CommentDate { get; set; }

        public bool? CommentIsActive { get; set; }

        public Guid? userId { get; set; }

        public Guid? postId { get; set; }
        public virtual Users? Users { get; set; }

        public virtual Posts? Posts { get; set; }

    }
}
