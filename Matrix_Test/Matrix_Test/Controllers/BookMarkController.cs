using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Matrix_Test.Controllers
{
    public class BookMarkController : Controller
    {
        // GET: BookMark
        public ActionResult Index()
        {
            if (Session["bookMarkList"] != null)
            {
                return View(Session["bookMarkList"]);
            }
            return View();
        }
    }
}