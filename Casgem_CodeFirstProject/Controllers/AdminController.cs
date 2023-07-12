using Casgem_CodeFirstProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_CodeFirstProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        TravelContext travelContext = new TravelContext();
        public ActionResult Index()
        {
            /*var values = travelContext.Admins.ToList();
            return View(values);*/
            var values = travelContext.Guides.ToString();
            return View(values);
        }


    }
}