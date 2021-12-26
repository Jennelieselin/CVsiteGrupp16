using Data;
using Data.Contexts;
using Data.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVsiteGrupp16.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: Project
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var projekt = context.Projekt.ToList();
                return View(projekt);
            }
           
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(Project projekt)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var newProject = new Project()
                    {
                        Namn = projekt.Namn,
                        Beskrivning = projekt.Beskrivning,
                    };
                    context.Projekt.Add(newProject);
                    context.SaveChanges();
                    var UserProjekt = new ApplicationUserProject()
                    {
                        ApplicationUserId = User.Identity.GetUserId(),
                    ProjectId = newProject.Id,
                    };
                context.applicationUserProjects.Add(UserProjekt);
                context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Project/Edit/5
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

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
      
            return View();
            
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
             

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
