using System;
using System.Collections.Generic;
using System.Data;
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
        TaiKhoan userM = new TaiKhoan();
        #endregion
        public ActionResult Index()
        {
            ClearSession();
            return View();
        }

        [HttpPost]
        #region Methods
        public void Check_Login()
        {
            string sUsername = Request["Username"];
            string sPassword = Request["Password"];
            sPassword = MD5.Encrypt(sPassword);
            DataRow dtr = userM.Get_Account(sUsername, sPassword);
            if (dtr != null)
            {
                SetSession(dtr);
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

            if (userM.Update_Password(newPass, Session["sUsername"].ToString()))
            {
                TempData["message"] = "Đổi mật khẩu thành công";
                return RedirectToAction("Index", new { change = true });
            }
            return RedirectToAction("Index", new { change = false });
        }
        public void ClearSession()
        {
            Session["PK_iMaTK"] = "";
            Session["sUsername"] = "";
            Session["sPassword"] = "";
            Session["FK_iMaQuyen"] = "";
            Session["sTenQuyen"] = "";
        }
        private void SetSession(DataRow dtr)
        {
            Session["PK_iMaTK"] = dtr["PK_iMaTK"];
            Session["sUsername"] = dtr["sUsername"];
            Session["sPassword"] = dtr["sPassword"];
            Session["FK_iMaQuyen"] = dtr["FK_iMaQuyen"];
            Session["sTenQuyen"] = dtr["sTenQuyen"];
        }
        #endregion
    }
}