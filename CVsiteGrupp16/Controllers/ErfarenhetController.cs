using Data;
using Data.Models;
using Services;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVsiteGrupp16.Controllers
{
    public class ErfarenhetController : Controller
    {
        private CvDbContext db = new CvDbContext();

        private ErfarenhetService erfarenhetService = new ErfarenhetService();

        // GET: Erfarenhet
        public ActionResult Index()
        {
            return View();
        }

        // GET: Erfarenhet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Erfarenhet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Erfarenhet/Create
        [HttpPost]
        public ActionResult Create(ErfarenhetModel model)
        {
            try
            {
                var cv = db.cvs.Where(row => row.Username == User.Identity.Name).FirstOrDefault();
                erfarenhetService.CreateErfarenhet(model, cv.Id);

                return RedirectToAction("Index", "CV");
            }
            catch
            {
                return View();
            }
        }

        // GET: Erfarenhet/Edit/5
        public ActionResult Edit(int id)
        {
            Erfarenhet inlagdErfarenhet = db.Erfarenhet.Find(id);
            return View(inlagdErfarenhet);
        }

        // POST: Erfarenhet/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Erfarenhet model)
        {
            try
            {
                erfarenhetService.UpdateErfarenhet(model);

                return RedirectToAction("Index", "CV");
            }
            catch
            {
                return View();
            }
        }

        // GET: Erfarenhet/Delete/5
        public ActionResult Delete(int id)
        {
            Erfarenhet inlagdErfarenhet = db.Erfarenhet.Find(id);
            return View(inlagdErfarenhet);
        }

        // POST: Erfarenhet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Erfarenhet model)
        {
            try
            {
                Erfarenhet erfarenhet = db.Erfarenhet.Find(id);
                db.Erfarenhet.Remove(erfarenhet);
                db.SaveChanges();

                return RedirectToAction("Index", "CV");
            }
            catch
            {
                return View();
            }
        }
    }
}
