using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    [Table("aspnet_Presentations")]
    public class PresentationModel
    {
        [Key]
        public int PresentationId { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }
    }
}