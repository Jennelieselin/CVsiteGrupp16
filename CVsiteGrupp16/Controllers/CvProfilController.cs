using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVsiteGrupp16.Controllers
{
    public class CvProfilController : Controller
    {

        private CvDbContext db = new CvDbContext();
        // GET: CvProfil
        public ActionResult Index()
        {
            return View();
        }

        // GET: CvProfil/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CvProfil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CvProfil/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CvProfil/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CvProfil/Edit/5
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

        // GET: CvProfil/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CvProfil/Delete/5
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
