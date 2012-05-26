using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace Presentation.Models
{
    [Table("aspnet_Users")]
    public class UserModel
    {
        [Key]
        [Column("UserId")]
        public Guid UserId { get; set; }      

        [Column("UserName")]
        public string Name { get; set; }

      //  [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
       // [Column("UserIntId")]
       // public int UserIntId { get; set; }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("ThemeId")]
        public int ThemeId { get; set; }

        public virtual ICollection<RatingsModel> Ratings { get; set; }

        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        //[Column("UserIntId")]
        //public int UserIntId { get; set; }
        //[ForeignKey("UserId")]
        //public virtual UserDetails UserDetails { get; set; }
        //public virtual ICollection<aspnet_Membership> UserDetails { get; set; }
    }
    
    [DisplayColumn("UserId")]    
    [Table("aspnet_Membership")]
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
                      
        [NotMapped]
        public string UserRole { get { return Roles.GetRolesForUser(Membership.GetUser((object)UserId).UserName).First(); } }
    }

     public class UserEditModel
     {
         public string ViewType { get; set; }
         public string UserName { get; set; }
         public UserDetailsModel UserDetails { get; set; }
     }
    
}