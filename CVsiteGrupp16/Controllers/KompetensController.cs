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
    public class KompetensController : Controller
    {
        private CvDbContext db = new CvDbContext();

        private KompetensService kompetensService = new KompetensService();

        // GET: Kompetens
        public ActionResult Index()
        {
            return View();
        }

        // GET: Kompetens/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Kompetens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kompetens/Create
        [HttpPost]
        public ActionResult Create(KompetensModel model)
        {
            try
            {
                var cv = db.cvs.Where(row => row.Username == User.Identity.Name).FirstOrDefault();
                kompetensService.CreateKompetens(model, cv.Id);

                return RedirectToAction("Index", "Cv");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kompetens/Edit/5
        public ActionResult Edit(int id)
        {
            Kompetens inlagdKompetens = db.Kompetens.Find(id);
            return View(inlagdKompetens);
        }

        // POST: Kompetens/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kompetens model)
        {
            try
            {
                kompetensService.UpdateKompetens(model);

                return RedirectToAction("Index", "Cv");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kompetens/Delete/5
        public ActionResult Delete(int id)
        {
            Kompetens inlagdKompetens = db.Kompetens.Find(id);
            return View(inlagdKompetens);
        }

        // POST: Kompetens/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Kompetens model)
        {
            try
            {
                Kompetens kompetens = db.Kompetens.Find(id);
                db.Kompetens.Remove(kompetens);
                db.SaveChanges();

                return RedirectToAction("Index", "Cv");
            }
            catch
            {
                return View();
            }
        }
    }
}
