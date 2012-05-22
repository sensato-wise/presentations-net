using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    [Table("aspnet_Slide")]
    public class SlideModel
    {
        [Key]
        public int PresentationId { get; set; }
        public int Index { get; set; }
        public byte[] Data { get; set; }
    }
}