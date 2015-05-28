using BloopMvc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace BloopMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var files = BloopFileFinder.FindFiles(Server.MapPath("~/App_Data/"));
            return View(files);
        }

        public ActionResult Content(int Id)
        {
            var bFile = BloopFileFinder.FindFiles(Server.MapPath("~/App_Data/"))
                .SingleOrDefault(file => file.Id == Id);

            if (bFile != null)
                return View(bFile);
            else
                return RedirectToAction("Index");
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }
    }
}