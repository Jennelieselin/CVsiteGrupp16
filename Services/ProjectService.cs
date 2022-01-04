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
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly HttpContext _httpcontext;

        public ProjectService(HttpContext httpcontext)
        {
            _httpcontext = httpcontext;
        }

        public Project CreateProject(ProjectModel projectModel, string username)
        {
            var nyttProjekt = new Project()
            {
                Namn = projectModel.Namn,
                Beskrivning = projectModel.Beskrivning,
                Datum = projectModel.Datum,
                Username = username
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
    }
}
