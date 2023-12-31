﻿using Casgem_CodeFirstProject.DAL.Context;
using Casgem_CodeFirstProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_CodeFirstProject.Controllers
{
    //[Authorize]
    public class AdminController : Controller
    {
        TravelContext travelContext = new TravelContext();
        public ActionResult Index()
        {
            /*var values = travelContext.Admins.ToList();
            return View(values);*/
            var values = travelContext.Admins.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View(); ;
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            travelContext.Admins.Add(admin);
            travelContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteAdmin(int id)
        {
            var value = travelContext.Admins.Find(id);
            travelContext.Admins.Remove(value);
            //travelContext.Guides.Add(guide);
            travelContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var values = travelContext.Admins.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin p)
        {
            var values = travelContext.Admins.Find(p.AdminID);
            values.UserName = p.UserName;
            values.Password = p.Password;
            travelContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}