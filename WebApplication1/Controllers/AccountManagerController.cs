using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountManagerController : Controller
    {
        // GET: AccountManager
        public ActionResult Index()
        {
            ViewBag.quyen = AccSession.FK_iMaQuyen;
            ViewBag.unknowThing = AccSession.SPassword;
            ViewBag.accUsername = AccSession.SUsername;
            List<TaiKhoan> data = new List<TaiKhoan>();
            data = new ListAccount().GetListAccounts();
            return View(data);
        }
        [HttpPost]
        public ActionResult DeleteAccount()
        {
            string maTK = Request["PK_iMaTK"];
            bool res = new TaiKhoan().DelAcc(maTK);
            return RedirectToAction("");
        }
        public ActionResult InsertAccount()
        {
            string username = Request["sUsername"];
            string password = MD5.Encrypt(Request["sPassword"]);
            int quyen = Int32.Parse(Request["FK_iMaQuyen"]);
            bool res = new TaiKhoan().InsAcc(username, password, quyen);
            return RedirectToAction("");
        }
        public ActionResult UpdateAccount()
        {
            string matk = Request["id"];
            string password = Request["sPassword"];
            if (password != "")
            {
                password = MD5.Encrypt(password);
            }
            int quyen = Int32.Parse(Request["FK_iMaQuyen"]);
            bool res = new TaiKhoan().UpdAcc(matk, password, quyen);
            return RedirectToAction("");
        }
    }
}