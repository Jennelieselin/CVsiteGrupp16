using Data;
using Services;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Contexts;


namespace CVsiteGrupp16.Controllers
{
    public class CvProfilController : Controller
    {
        private CvProfilService cvProfilService = new CvProfilService(System.Web.HttpContext.Current);

        private CvDbContext db = new CvDbContext();



        [Authorize]
        public ActionResult Index()
        {
            var cvs = db.cvs.Where(row => row.UserName == User.Identity.Name).FirstOrDefault();
            var visaCv = cvProfilService.GetCvIndexView(cvs.Id);
            return View(visaCv);
        }



        public ActionResult ShowCvIndex(int id)
        {
            var cv = db.cvs.Find(id);
            var visaCv = cvProfilService.GetCvIndexView(cv.Id);
            return View(visaCv);
        }

        public ActionResult SearchIndex(string searchString)
        {
            var cv = from c in db.cvs select c;
            if (User.Identity.IsAuthenticated)
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    cv = cv.Where(row => row.Namn.Contains(searchString));
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    cv = cv.Where(row => row.Namn.Contains(searchString) && row.Privat == false);
                }
                else
                {
                    cv = cv.Where(row => row.Privat == false);
                }
            }
            return View(cv);
        }


        // GET: CvProfil/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CvProfil/Create
        public void Create(string userName)
        {
            var nyttCv = cvProfilService.CreateCv(userName);
            db.cvs.Add(nyttCv);
            db.SaveChanges();
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

        public ActionResult EditImg(int id)
        {
            var nyttCvView = cvProfilService.GetEditImgView(id);
            return View(nyttCvView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditImg(CvEditImg model)
        {
            try
            {
                cvProfilService.UpdateImg(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
     


        // GET: CvProfil/Edit/5
        public ActionResult EditInfo(int id)
        {
            var nyttCvView = cvProfilService.GetEditInfoView(id);
            return View(nyttCvView);
        }

        // POST: CvProfil/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInfo(CvEditInfo cv)
        {
            try
            {
                cvProfilService.UpdateInfo(cv);

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
