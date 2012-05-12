using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    [Table("aspnet_Users")]
    
    public class User
    {

        [Key]
        [Column("UserId")]
        
        public Guid UserId { get; set; }

        [Column("UserName")]
        public string Name { get; set; }

        //[ForeignKey("UserId")]
        //public virtual UserDetails UserDetails { get; set; }

        //public virtual ICollection<aspnet_Membership> UserDetails { get; set; }

    }
}