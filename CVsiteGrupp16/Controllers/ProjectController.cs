using Data.Contexts;
using Data.Models;
using Shared.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using Services;
using Microsoft.AspNet.Identity;

namespace CvSiteGrupp16.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ProjectService ProjectService = new ProjectService(System.Web.HttpContext.Current);
        private UsersProjectService UsersInProjectsService = new UsersProjectService(System.Web.HttpContext.Current);

        // GET: Project
        public ActionResult UserIndex()
        {
            var projects = db.projects.Where(row => row.Username == User.Identity.Name);
            return View(projects);
        }

        // GET: Project
        public ActionResult MainIndex(string searchString)
        {
            var projects = from p in db.projects select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                projects = projects.Where(row => row.Namn.Contains(searchString));
            }
            return View(projects);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(ProjectModel projectModel)
        {
            try
            {
                Project newProject = ProjectService.CreateProject(projectModel, User.Identity.Name);
                UsersInProjectsService.CreateUserInProject(newProject.Id, User.Identity.GetUserId(), User.Identity.Name);
                return RedirectToAction("UserIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Project existingProject = db.projects.Find(id);
            if (existingProject == null)
            {
                return HttpNotFound();
            }
            return View(existingProject);
        }

        // POST: Project/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project project)
        {
            try
            {
                ProjectService.EditProject(project);
                return RedirectToAction("UserIndex");
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
            Project existingProject = db.projects.Find(id);
            if (existingProject == null)
            {
                return HttpNotFound();
            }
            return View(existingProject);
        }


        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                ProjectService.DeleteProject(id);
                UsersInProjectsService.DeleteUserInProject(id);
                return RedirectToAction("UserIndex");
            }
            catch
            {
                return View();
            }
        }
    }
}
