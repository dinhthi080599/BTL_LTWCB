using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CreateAcountController : Controller
    {
        // GET: CreateAcount
        // => http:localhost:xxxxx/CreateAccount
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public void CreateAccount()
        {
            // user_name tương ứng với name của ô intput
            string sTenTK = Request["user_name"]; // đây là cách để lấy dữ liệu khi client gửi resquest lên
            string sMatKhau = Request["password"];
            TaiKhoan tk = new TaiKhoan();
            if(tk.TaoTK(sTenTK, sMatKhau))
            {
                Response.Redirect("~/Login");
            }
            else
            {
                Response.Redirect("~/CreateAcount/Index");
            }
        }
    }
}