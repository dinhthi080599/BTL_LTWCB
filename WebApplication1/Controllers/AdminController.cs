using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (!Check_Session())
            {
                Response.Redirect("~/login");
            }
            ViewBag.quyen = AccSession.FK_iMaQuyen;
            ViewBag.unknowThing = AccSession.SPassword;
            return View();
        }
        public bool Check_Session()
        {
            return AccSession.FK_iMaQuyen > 0;
        }
    }
}