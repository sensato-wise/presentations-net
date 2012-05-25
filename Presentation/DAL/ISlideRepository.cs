using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Presentation.Models;

namespace Presentation.DAL
{
    public interface ISlideRepository
    {
        IEnumerable<SlideModel> GetSlides(int presentationId);
        SlideModel GetSlide(int presentationId, int number);
        void DeleteSlide(int presentationId, int number);
        void UpdateSlide(SlideModel slide);
        void InsertSlide(SlideModel slide);
        void Save();
    }
}