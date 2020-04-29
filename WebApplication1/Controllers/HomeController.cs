using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        List<Topic> lstTp = LstTopic.Lst.GetListTopics();
        List<BaiViet> lstHotNew = LstBaiViet.Lst.GetHotNews();
        public ActionResult Index()
        {
            List<BaiViet> lstNews = LstBaiViet.Lst.GetAllBaiViet();
            foreach (var item in lstNews)
            {
                foreach (var topic in lstTp)
                {
                    if (topic.PK_iMaTL == item.Matl && topic.lstNews.Count < 3)
                    {
                        topic.lstNews.Add(item);
                    }
                }
            }
            SetViewBag("home");
            return View();
        }
        
        public ActionResult LoaiTin()
        {
            List<BaiViet> lstNewsInTopic = LstBaiViet.Lst.GetNewsInTopic(Int32.Parse(Request["maloaitin"]));
            SetViewBag(Request["maloaitin"], "",lstNewsInTopic);
            return View();
        }

        public ActionResult Search()
        {
            string keyword = Request["keyword"];
            List<BaiViet> lstRes = LstBaiViet.Lst.SearchResultBaiViet(keyword);
            SetViewBag("search", keyword, lstRes);
            return View();
        }

        public ActionResult News()
        {
            string mabv = Request["bai-viet"];
            BaiViet theNew = LstBaiViet.Lst.GetNew(mabv);
            ViewBag.theNew = theNew;
            SetViewBag("new");
            //Response.Cookies["current_read_name"].Value = theNew.Tenbv;
            //Response.Cookies["current_read_id"].Value = theNew.Mabv.ToString();
            //Response.Cookies["current_read_name"].Expires = DateTime.Now.AddDays(1);
            //Response.Cookies["current_read_id"].Expires = DateTime.Now.AddDays(1);
            return View();
        }

        public void SetViewBag(string currentP, string searchKeyword = "", List<BaiViet> lstBaiViet = null)
        {
            HttpContext.Application["soluottruycap"] = (int)HttpContext.Application["soluottruycap"] + 1;
            ViewBag.loaitin = lstTp;
            ViewBag.hotnews = lstHotNew;
            ViewBag.keyword = searchKeyword;
            ViewBag.currentP = currentP;
            ViewBag.lstBaiViet = lstBaiViet;

        }
    }
}