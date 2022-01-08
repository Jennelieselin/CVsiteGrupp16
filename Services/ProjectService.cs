using Data.Contexts;
using Data.Models;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services
{
    public class ProjectService
    {
        private ProjectDbContext db = new ProjectDbContext();
        private readonly HttpContext _httpcontext;

        public ProjectService(HttpContext httpcontext)
        {
            _httpcontext = httpcontext;
        }

        public Project CreateProject(ProjectModel projectModel, string userName)
        {
            var nyttProjekt = new Project()
            {
                Namn = projectModel.Namn,
                Beskrivning = projectModel.Beskrivning,
                Datum = projectModel.Datum,
                UserName = userName
            };
            db.projects.Add(nyttProjekt);
            db.SaveChanges();
            return nyttProjekt;
        }

        public void DeleteProject(int id)
        {
            Project project = db.projects.Find(id);
            db.projects.Remove(project);
            db.SaveChanges();
        }

        public void EditProject(Project projectModel)
        {
            var dbProject = db.projects.FirstOrDefault(x => x .Id == projectModel.Id);
            dbProject.Namn = projectModel.Namn;
            dbProject.Beskrivning=projectModel.Beskrivning;
            dbProject.Datum = projectModel.Datum;
            db.SaveChanges();
        }

        public bool ProjectNameExists(ProjectModel projectModel)
        {
            var allProjectNames = db.projects.Select(row => row.Namn).ToList();
            bool doesNameExists = false;
            foreach (var name in allProjectNames)
            {
                if (projectModel.Namn.Equals(name))
                {
                    doesNameExists = true;
                }
            }
            return doesNameExists;
        }

        public bool ProjectNameExistsDifferentId(Project project)
        {
            var allProjectsWithDifferentId = db.projects.Where(row => row.Id != project.Id).ToList();
            var allProjectNames = allProjectsWithDifferentId.Select(row => row.Namn).ToList();
            bool doesNameExists = false;
            foreach (var name in allProjectNames)
            {
                if (project.Namn.Equals(name))
                {
                    doesNameExists = true;
                }
            }
            return doesNameExists;
        }
    }
}
