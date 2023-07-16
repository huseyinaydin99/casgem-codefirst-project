using Casgem_CodeFirstProject.DAL.Context;
using Casgem_CodeFirstProject.DAL.Entities;
using Casgem_CodeFirstProject.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Casgem_CodeFirstProject.Controllers
{
    public class LoginController : Controller
    {
        TravelContext travelContext = new TravelContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View(new ErrorLoginMessage(null));
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            var values = travelContext.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);

            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, user.RememberMe);
                Session["userTravel"] = values.UserName;
                return RedirectToAction("Index", "AdminGuide");
            }
            else
            {
                return View(new ErrorLoginMessage("Kullanıcı adı veya şifre hatalı!"));
            }
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            travelContext.Users.Add(user);
            travelContext.SaveChanges();
            Session["userTravel"] = user.UserName;
            return RedirectToAction("Index", "AdminGuide");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new ErrorLoginMessage(null));
        }

        /*[HttpPost]
        public ActionResult Register(User user)
        {
            var values = travelContext.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);

            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, user.RememberMe);
                Session["userTravel"] = values.UserName;
                return RedirectToAction("Index", "AdminGuide");
            }
            else
            {
                return View(new ErrorLoginMessage("Kullanıcı adı veya şifre hatalı!"));
            }
            //return RedirectToAction("Index","AdminGuide");
        }*/

        [HttpPost]
        public ActionResult Exit()
        {
            Session["userTravel"] = null;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Exit2()
        {
            Session["userTravel"] = null;
            return RedirectToAction("Index");
        }
    }
}