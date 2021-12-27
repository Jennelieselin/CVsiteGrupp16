using Data;
using Data.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVsiteGrupp16.Controllers
{
    public class CvController : Controller
    {
        private CvDbContext db = new CvDbContext();
        // GET: Cv
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var cvs = context.Cvs.ToList();
                return View(cvs);
            }
            
        }

        // GET: Cv/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cv/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cv/Create
        [HttpPost]
        public ActionResult Create(Cv model)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var currentUser = User.Identity.GetUserId();
                    var newCv = new Cv()
                    {
                        Kompetens = model.Kompetens,
                        Utbildning = model.Utbildning,
                        Erfarenhet = model.Erfarenhet,
                    };

                    context.Cvs.Add(newCv);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cv/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cv/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cv/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cv/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
