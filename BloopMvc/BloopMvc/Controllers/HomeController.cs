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
            List<BloopFile> models = new List<BloopFile>();
            string path = AppDomain.CurrentDomain.BaseDirectory + "App_Data";
            
            if (Directory.Exists(path))
            {
                String[] files = Directory.GetFiles(path);

                foreach (String file in files)
                {
                    if(file.EndsWith(".txt"))
                    {
                        var model = new BloopFile();

                        model.Name = file;
                        model.DateTime = System.IO.File.GetLastWriteTime(file);
                        model.Content = System.IO.File.ReadAllText(file);
                        models.Add(model);
                    }
                }                 
            }
            else
            {
                Console.WriteLine("{0} does not exist.", path);
            }  

            return View(models);
        }
    }
}