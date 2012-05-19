using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    [Table("aspnet_Tags")]
    public class Tag
    {
        [Key]
        [Column("TagId")]
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
