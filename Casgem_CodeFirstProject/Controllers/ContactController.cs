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
    public class ContactController : Controller
    {
        TravelContext travelContext = new TravelContext();
        [HttpGet]
        public ActionResult Index()
        {
            var values = travelContext.Contacts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = travelContext.Contacts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateContact(About about)
        {
            var value = travelContext.Contacts.Find(about.AboutID);
            value.ContactID = about.AboutID;
            value.Subject = about.Subject;
            value.Message = about.Message;
            value.MessageDate = about.MessageDate;
            value.NameSurname = about.NameSurname;
            value.Mail = about.Mail;
            travelContext.SaveChanges();
            return View(value);
        }

        [HttpGet]
        public ActionResult DeleteContact(int id)
        {
            var value = travelContext.Contacts.Find(id);
            if(value != null)
            {
                travelContext.Contacts.Remove(value);
                travelContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}