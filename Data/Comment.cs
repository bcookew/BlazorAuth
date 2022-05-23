using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorAuth.Areas.Identity.Data;

namespace BlazorAuth.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Text { get; set; }
        
        [ForeignKey("Author")]
        public string UserId { get; set; }
        
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        // ====================== Nav Props
        public User Author { get; set; }
        public PostMesssage Post { get; set; }
    }
}