using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Presentation.Models;
using Presentation.Model;
using System.Data.Entity;
using System.Data;

namespace Presentation.DAL
{
    public class SlideRepository : ISlideRepository
    {

        private UserContext context;

        public SlideRepository()
        {
            this.context = new UserContext();
        }

        public IEnumerable<SlideModel> GetSlides(int presentationId)
        {
            var slides = context.Slides.Where(i => i.PresentationId == presentationId);
            return slides.ToList();
        }

        public SlideModel GetSlide(int presentationId, int number)
        {
            var slides = context.Slides.Where(i => (i.PresentationId == presentationId)&&
                (i.SlideNumber == number)).ToList();
            if (slides.Count > 0)
                return (slides[0]);
            else
                return null;
        }

        public void DeleteSlide(int presentationId, int number)
        {
            SlideModel slide = GetSlide(presentationId, number);
            if (slide != null)
                context.Slides.Remove(slide);
        }

        public void UpdateSlide(SlideModel slide)
        {
            context.Entry(slide).State = EntityState.Modified;
        }

        public void InsertSlide(SlideModel slide)
        {
            context.Slides.Add(slide);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}