using Data;
using Data.Contexts;
using Data.Models;
using Microsoft.AspNet.Identity;
using Services;
using Shared.Models;
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
        private ProjectService ProjectService = new ProjectService(System.Web.HttpContext.Current);

        public ActionResult UserView()
        {
            // var projects = context.projects.Where(row => row.UserName == User.Identity.Name);
            var projects = db.projects.Where(row => row.Användarnamn == User.Identity.Name);
            return View(projects);
        }

        //public ActionResult Index()
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        var projekt = context.Projekt.ToList();
        //        return View(projekt);
        //    }

        //}

        //// GET: Project
        public ActionResult Index(string searchString)
        {
            var projekt = from p in db.projects select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                projekt = projekt.Where(row => row.Namn.Contains(searchString));
            }
            return View(projekt);
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
        //[HttpPost]
        //public ActionResult Create(ProjectModel projektModel)
        //{
        //    try
        //    {
        //        Project nyttProjekt = ProjectSerive.CreateProject(ProjectModel, User.Identity.Name);
        //        UsersInProjectsService.CreateUserInProject(newProject.ID, User.Identity.GetUserId(), User.Identity.Name);
        //        return RedirectToAction("UserView");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
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
                ProjectService.EditProjekt(project);
                return RedirectToAction("UserView");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Project existerandeProjekt = db.projects.Find(id);
            if (existerandeProjekt == null)
            {
                return HttpNotFound();
            }
            return View(existerandeProjekt);


        }

        // POST: Project/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Delete(int id, FormCollection collection)
        //    {

        //        try
        //        {
        //            ProjectService.DeleteProject(id);
        //            UsersInProjectService.DeleteUsersInProjects(id);

        //            return RedirectToAction("UserView");
        //        }
        //        catch
        //        {

        //            return View();
        //        }
        //    }
        //}
    }
}
