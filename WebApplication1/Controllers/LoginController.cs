using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        #region Parameters
        AccSession session = new AccSession();
        #endregion
        public ActionResult Index()
        {
            session.Clear();
            return View();
        }

        [HttpPost]
        #region Methods
        public void Check_Login()
        {
            string sUsername = Request["Username"];
            string sPassword = Request["Password"];
            if(session.Check_Account(sUsername, sPassword))
            {
                Response.Redirect("~/admin");
            }
            else
            {
                Response.Redirect("~/login");
            }
        }

        public ActionResult ChangePassword()
        {
            string oldPass = Request["oldPass"];
            string newPass = Request["newPass"];
            if (session.Update_Password(newPass))
            {
                TempData["message"] = "Đổi mật khẩu thành công";
                return RedirectToAction("Index", new { change = true });
            }
            return RedirectToAction("Index", new { change = false });
        }

        public void Logout()
        {
            Response.Redirect("~/login");
        }
        #endregion
    }
}