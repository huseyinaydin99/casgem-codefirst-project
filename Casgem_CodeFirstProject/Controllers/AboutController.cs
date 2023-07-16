using Casgem_CodeFirstProject.DAL.Context;
using Casgem_CodeFirstProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace Casgem_CodeFirstProject.Controllers
{
    public class AboutController : Controller
    {
        TravelContext travelContext = new TravelContext();
        [HttpGet]
        public ActionResult Index()
        {
            var values = travelContext.Abouts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = travelContext.Abouts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = travelContext.Abouts.Find(about.AboutID);
            value.AboutID = about.AboutID;
            value.Subject = about.Subject;
            value.Message = about.Message;
            value.MessageDate = about.MessageDate;
            value.NameSurname = about.NameSurname;
            value.Mail = about.Mail;
            travelContext.SaveChanges();
            return View(value);
        }

        [HttpGet]
        public ActionResult DeleteAbout(int id)
        {
            var value = travelContext.Abouts.Find(id);
            if(value != null)
            {
                travelContext.Abouts.Remove(value);
                travelContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}