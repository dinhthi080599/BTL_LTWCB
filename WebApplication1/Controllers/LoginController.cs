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
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void check_login()
        {
            string sUsername = Request["user_name"];
            string sPassword = Request["password"];
            TaiKhoan tk = new TaiKhoan();
            bool tt = tk.Get_TaiKhoan(sUsername, sPassword);
            if(tt)
            {
                Response.Redirect("~/admin");
            }
            else
            {
                Response.Redirect("~/Login");
            }
        }
    }
}