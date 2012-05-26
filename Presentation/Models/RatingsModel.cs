using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    [Table("aspnet_Ratings")]
    public class RatingsModel
    {
        [Key]
        public int PresentationId { get; set; }
        public Guid UserId { get; set; }
        public float RatingValue { get; set; }        
    }
}