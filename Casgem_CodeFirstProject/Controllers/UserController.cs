using Casgem_CodeFirstProject.DAL.Context;
using Casgem_CodeFirstProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_CodeFirstProject.Controllers
{
    public class UserController : Controller
    {
        TravelContext travelContext = new TravelContext();
        public ActionResult Index()
        {
            /*var values = travelContext.Admins.ToList();
            return View(values);*/
            var values = travelContext.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View(); ;
        }

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            travelContext.Users.Add(user);
            travelContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            var value = travelContext.Users.Find(id);
            travelContext.Users.Remove(value);
            //travelContext.Guides.Add(guide);
            travelContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            var values = travelContext.Users.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateUser(User p)
        {
            var values = travelContext.Users.Find(p.UserID);
            values.UserName = p.UserName;
            values.Password = p.Password;
            travelContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}