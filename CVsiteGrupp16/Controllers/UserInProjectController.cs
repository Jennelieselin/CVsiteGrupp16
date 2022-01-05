﻿using Data.Contexts;
using Data.Models;
using Microsoft.AspNet.Identity;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVsiteGrupp16.Controllers
{
    public class UserInProjectController : Controller
    {

        private CvProfilService cvProfilService = new CvProfilService(System.Web.HttpContext.Current);
        private UsersProjectService userProjectService = new UsersProjectService(System.Web.HttpContext.Current);
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: UserInProject
        public ActionResult Index(int projectId)
        {
            bool inloggad = false;
            if(User.Identity.IsAuthenticated)
            {
                inloggad = true;
            }
            var allUsersInProject = userProjectService.GetUsernameInProject(projectId);
            var allCvsInProject = cvProfilService.GetCvWithUserName(allUsersInProject, inloggad);
            return View(allCvsInProject);
        }

        // GET: UserInProject/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserInProject/Create
        public ActionResult Create()
        {
            ApplicationDbContext projectDb = new ApplicationDbContext();

            var allProjects = projectDb.projects.ToList();
            var allInvolvedProjects = db.usersInProjects.Where(m => m.Username.Equals(User.Identity.Name)).ToList();

            var allProjectsID = allProjects.Select(m => m.Id).ToList();
            var allInvolvedProjectsID = allInvolvedProjects.Select(m => m.ProjectId).ToList();

            var allExcepts = allProjectsID.Except(allInvolvedProjectsID).ToList();

            List<Project> listOfNotInvolvedProjects = new List<Project>();

               foreach (var id in allExcepts)
               {
                var project = allProjects.Where(m => m.Id == id).FirstOrDefault();
            listOfNotInvolvedProjects.Add(project);
            }

            ViewBag.Projects = new SelectList(listOfNotInvolvedProjects, "Id", "Name");

                  return View();
        }



// POST: UserInProject/Create
[HttpPost]
        public ActionResult Create(int SelectedProjectId)
        {
            try
            {
                userProjectService.CreateUserInProject(SelectedProjectId, User.Identity.GetUserId(), User.Identity.Name);

                return RedirectToAction("Index", "CV");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserInProject/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserInProject/Edit/5
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

        // GET: UserInProject/Delete/5
        public ActionResult Delete(int id)
        {
            var newView = userProjectService.GetDeleteUsersInProjectsView(id);
            return View(newView);
        }

        // POST: UserInProject/Delete/5
        [HttpPost]
        public ActionResult Delete(Project model)
        {
            try
            {
                userProjectService.DeleteUserInProject(model.Id);

                return RedirectToAction("Index", "Cv");
            }
            catch
            {
                return View();
            }
        }
    }
}
