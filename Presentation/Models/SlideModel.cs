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
        public int Id { get; set; }
        public int PresentationId { get; set; }
        public int SlideNumber { get; set; }
        public string Data { get; set; }


        public SlideModel()
        {
        }

        public SlideModel(int presentationId, int slideNumber)
        {
            PresentationId = presentationId;
            SlideNumber = slideNumber;
        }
        
    }
}