using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlazorAuth.Data;
namespace BlazorAuth.Areas.Identity.Data
{
    public class User : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // ====================== Nav Props
        [InverseProperty("Sender")]
        public List<Message> MessagesSent { get; set; }
        
        [InverseProperty("Receiver")]
        public List<Message> MessagesReceived { get; set; }
        
        [InverseProperty("User")]
        public List<Relationship> Friends { get; set; }
        
        [InverseProperty("Friend")]
        public List<Relationship> FriendOf { get; set; }

        public List<PostMesssage> Posts { get; set; }
        public List<Comment> Comments { get; set; }
    }
}