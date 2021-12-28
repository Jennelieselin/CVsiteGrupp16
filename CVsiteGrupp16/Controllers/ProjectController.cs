using Data;
using Data.Contexts;
using Data.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CVsiteGrupp16.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        public ActionResult UserIndex()
        {
            //var projects = context.projects.Where(row => row.UserName == User.Identity.Name);
            var projects = db.projects.ToList();
            return View(projects);
        }

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

                return RedirectToAction("UserView");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project projektEdit = db.projects.Find(id);
            if (projektEdit == null)
            {
                return HttpNotFound();
            }
            return View(projektEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project project)
        {
            try
            {
                var currentProject = db.projects.FirstOrDefault(x => x.Id == project.Id);
                if (currentProject == null)
                {
                    return HttpNotFound();
                }

                currentProject.Namn = project.Namn;
                currentProject.Beskrivning = project.Beskrivning;
                db.SaveChanges();
                return RedirectToAction("UserView");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return View(context.Projekt.Where(x => x.Id == id).FirstOrDefault());
            }

            
            
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
        
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Project projekt = context.Projekt.Where(x => x.Id == id).FirstOrDefault();
                    context.Projekt.Remove(projekt);
                    context.SaveChanges();

                }
                return RedirectToAction("UserView");
            }
            catch
            {
               
                return View();
            }
        }
    }
}
