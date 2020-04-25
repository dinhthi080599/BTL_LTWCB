using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TopicManagerController : Controller
    {
        // GET: TopicManager
        public ActionResult Index()
        {
            if (Session["sUsername"].ToString() == "")
            {
                Response.Redirect("~/login");
            }
            List<Topic> data = LstTopic.Lst.GetListTopics();
            return View(data);
        }
        public ActionResult DeleteTopic()
        {
            string maTL = Request["PK_iMaTL"];
            bool res = new Topic().DelTopic(maTL);
            return RedirectToAction("");
        }
        public ActionResult AddTopic()
        {
            Topic tp = new Topic();
            tp.STenTheLoai = Request["sTenLoaiTin"];
            tp.IVitri = Int32.Parse(Request["iViTri"]);
            tp.ISTT = Int32.Parse(Request["iSTT"]);
            bool res = tp.AddTopic(tp);
            return RedirectToAction("");
        }
        public ActionResult UpdateTopic()
        {
            Topic tp = new Topic();
            tp.PK_iMaTL = Int32.Parse(Request["id"]);
            tp.STenTheLoai = Request["sTenLoaiTin"];
            tp.IVitri = Int32.Parse(Request["iViTri"]);
            tp.ISTT = Int32.Parse(Request["iSTT"]);
            string tentp = Request["sTenLoaiTin"];
            bool res = tp.UpdateTopic(tp);
            return RedirectToAction("");
        }
    }
}