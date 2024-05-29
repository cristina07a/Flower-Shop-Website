using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectPAW.Models
{
    public class UserInfo
    {
        [Key]
        public int UserInfoID { get; set; }
        public string? Username { get; set; }
        public string? ProfileImage { get; set; }
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }
    }
}
