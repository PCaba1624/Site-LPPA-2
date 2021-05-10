using Business;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            var biz = new CategoryBiz();
            var model = biz.Listar();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                var biz = new CategoryBiz();
                biz.Agregar(model);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                /// Que pasa con el error -> Bitacoras
                Console.WriteLine(e);
                return View(model);
            }
        }

       
        
        public ActionResult Delete(Category model)
        {
      
            try
            {
                var biz = new CategoryBiz();
                biz.Delete(model);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                /// Que pasa con el error -> Bitacoras
                Console.WriteLine(e);
                return View(model);
            }
        }
    }
}