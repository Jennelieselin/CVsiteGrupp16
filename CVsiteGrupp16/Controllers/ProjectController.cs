using Data.Contexts;
using Data.Models;
using Shared.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using Services;
using Microsoft.AspNet.Identity;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace CvSiteGrupp16.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();
        private ProjectService ProjectService = new ProjectService(System.Web.HttpContext.Current);
        private UsersProjectService UsersInProjectsService = new UsersProjectService(System.Web.HttpContext.Current);

        // GET: Project
        public ActionResult UserIndex()
        {
            var projects = db.projects.Where(row => row.UserName == User.Identity.Name);
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


        public ActionResult Join(int projectId)
        {
            try
            {
                var ctx = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                string user = User.Identity.GetUserId();

                var projektDeltagare = new ApplicationUserProject()
                {

                    ProjectId = projectId,
                    UserId = user,
                    UserName = User.Identity.Name
                };
                ctx.usersInProjects.Add(projektDeltagare);
                ctx.SaveChanges();
                //ViewBag.Message = "Du har nu gått med i projektet!";
                return RedirectToAction("MainIndex");
            }
            catch
            {
                return View();
            }

        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(ProjectModel model)
        {
            try
            {

                if (ProjectService.ProjectNameExists(model) == false)
                {

                    Project newProject = ProjectService.CreateProject(model, User.Identity.Name);
                    UsersInProjectsService.CreateUserInProject(newProject.Id, User.Identity.GetUserId(), User.Identity.Name);
                    return RedirectToAction("UserIndex");
                }
                else
                {
                    ViewBag.Error = "Finns redan projekt med detta namn. Prova med annat namn.";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {

            Project existingProject = db.projects.Find(id);

            return View(existingProject);
        }

        // POST: Project/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project project)
        {
            try
            {
                if (ProjectService.ProjectNameExistsDifferentId(project) == false)
                {
                    ProjectService.EditProject(project);
                    return RedirectToAction("UserIndex");
                }
                else
                {
                    ViewBag.Error = "Projekt med detta namn finns redan.";
                        return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Delete/5
        [Authorize]
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
