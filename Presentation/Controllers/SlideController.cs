﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Presentation.DAL;
using Presentation.Models;
using System.Collections;

namespace Presentation.Controllers
{
    public class SlideController : Controller
    {

        private ISlideRepository slideRepository;
        private int presentationId { get; set; }
        public SlideController()
        {
            slideRepository = new SlideRepository();
            presentationId = 1;
        }

        //
        // GET: /Slide/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Temp(int? id)
        {
            if (id.HasValue)
                presentationId = id.Value;
            else
                presentationId = 1;
            return View();
        }




        public ActionResult SlideShow()
        {
            return View();
        }



        public ActionResult GetSlides(int? id)
        {
            if (!id.HasValue)
            {
                id = 1;
            }
            presentationId = id.Value;
            var slides = slideRepository.GetSlides(id.Value);
            string[] images = new string[slides.Count()];
            int i = 0;
            foreach (var slide in slides)
            {
                images[i] = slide.Data;
                ++i;
            }
            return Json(images, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Image()
        {
            return View();
        }

        



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Save(string[] images)
        {
            //return View();
            for (int i = 1; i < images.Length; ++i)
            {
                var slide = slideRepository.GetSlide(presentationId, i);
                if (slide == null)
                {
                    SlideModel newSlide = new SlideModel();
                    newSlide.Data = images[i];
                    newSlide.PresentationId = presentationId;
                    newSlide.SlideNumber = i;
                    slideRepository.InsertSlide(newSlide);
                    slideRepository.Save();
                }
                else
                {
                    slide.Data = images[i];
                    slideRepository.UpdateSlide(slide);
                    slideRepository.Save();
                }
            }
            return null;
        }

    }
}
