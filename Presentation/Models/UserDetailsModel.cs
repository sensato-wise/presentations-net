using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    [Table("aspnet_Membership")]
    [DisplayColumn("UserId")]
    
    public class UserDetailsModel
    {
        [Key]
        [Column("UserId")]  
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordQuestion { get; set; }
        public string PasswordAnswer { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}