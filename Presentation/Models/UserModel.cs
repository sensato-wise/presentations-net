using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

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

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("UserIntId")]
        public int UserIntId { get; set; }

        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        //[Column("UserIntId")]
        //public int UserIntId { get; set; }

        //[ForeignKey("UserId")]
        //public virtual UserDetails UserDetails { get; set; }

        //public virtual ICollection<aspnet_Membership> UserDetails { get; set; }

    }
    public class UserNameModel
    {
        public string UserName { get; set; }

    }
}