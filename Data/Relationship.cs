using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorAuth.Areas.Identity.Data;

namespace BlazorAuth.Data
{
    public class Relationship
    {
        [Key]
        public int RelationshipId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Friend")]
        public string FriendId { get; set; }
        public bool Confirmed { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // ====================== Nav Props
        public User User { get; set; }
        public User Friend { get; set; }
    }
}