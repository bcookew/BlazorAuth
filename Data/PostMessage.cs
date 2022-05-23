using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorAuth.Areas.Identity.Data;

namespace BlazorAuth.Data
{
    public class PostMesssage
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        [MinLength(5, ErrorMessage ="5 Character Minimum")]
        public string Text { get; set; }
        [ForeignKey("Author")]
        public string UserId { get; set; }
        public bool FriendsOnly { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        // ====================== Nav Props
        public User Author { get; set; }
        public List<Comment> Comments { get; set; }
    }
}