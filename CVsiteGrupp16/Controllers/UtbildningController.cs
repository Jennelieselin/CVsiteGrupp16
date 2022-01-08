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
    public class UtbildningController : Controller
    {

        private CvDbContext db = new CvDbContext();

        private UtbildningService utbildningService = new UtbildningService();

        // GET: Utbildning
        public ActionResult Index()
        {
            return View();
        }

        // GET: Utbildning/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Utbildning/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utbildning/Create
        [HttpPost]
        public ActionResult Create(UtbildningModel model)
        {
            try
            {
                var cv = db.cvs.Where(row => row.Username == User.Identity.Name).FirstOrDefault();
                utbildningService.CreateUtbildning(model, cv.Id);

                return RedirectToAction("Index", "Cv");
            }
            catch
            {
                return View();
            }
        }

        // GET: Utbildning/Edit/5
        public ActionResult Edit(int id)
        {
            Utbildning inlagdUtbildning = db.Utbildning.Find(id);

            return View(inlagdUtbildning);
        }

        // POST: Utbildning/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Utbildning model)
        {
            try
            {
                utbildningService.UpdateUtbildning(model);


                return RedirectToAction("Index", "Cv");
            }
            catch
            {
                return View();
            }
        }

        // GET: Utbildning/Delete/5
        public ActionResult Delete(int id)
        {
            Utbildning inlagdUtbildning = db.Utbildning.Find(id);

            return View(inlagdUtbildning);
        }

        // POST: Utbildning/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Utbildning model)
        {
            try
            {
                Utbildning utbildning = db.Utbildning.Find(id);
                db.Utbildning.Remove(utbildning);
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
