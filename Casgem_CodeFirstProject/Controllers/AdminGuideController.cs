using Casgem_CodeFirstProject.DAL.Context;
using Casgem_CodeFirstProject.DAL.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Casgem_CodeFirstProject.Controllers
{
    public class AdminGuideController : Controller
    {
        TravelContext travelContext = new TravelContext();
        public ActionResult Index()
        {
            var values = travelContext.Guides.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddGuide()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddGuide(Guide guide)
        {
            travelContext.Guides.Add(guide);
            travelContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteGuide(Guide guide)
        {
            var value = travelContext.Guides.Find(guide);
            travelContext.Guides.Remove(value);
            //travelContext.Guides.Add(guide);
            travelContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateGuide(int id)
        {
            var values = travelContext.Guides.Find(id);

            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateGuide(Guide p)
        {
            var values = travelContext.Guides.Find(p.GuideID);
            values.GuideName = p.GuideName;
            values.GuideTitle = p.GuideTitle;
            values.GuideImageUrl = p.GuideImageUrl;
            

            travelContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}