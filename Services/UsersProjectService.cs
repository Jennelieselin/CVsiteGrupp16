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
    public class UsersProjectService
    {
        private readonly HttpContext _httpcontext;
        private ApplicationDbContext db = new ApplicationDbContext();

        public UsersProjectService(HttpContext httpcontext)
        {
            _httpcontext = httpcontext;
        }

        public DeleteUserInProjectView GetDeleteUsersInProjectsView(int id)
        {
            ApplicationDbContext projectDbContext = new ApplicationDbContext();
            var project = projectDbContext.projects.Find(id);
            var newView = new DeleteUserInProjectView
            {
                Id = project.Id,
                Namn = project.Namn,
                Beskrivning = project.Beskrivning,
                Datum = project.Datum
            };
            return newView;
        }
        //raderar vid specifikt userid
        public void DeleteUserInProject(string userId)
        {
            var UserInProjects = db.Users.Where(row => row.Id.Equals(userId));
            foreach (var row in UserInProjects)
            {
                db.Users.Remove(row);
            }
            db.SaveChanges();
        }

        // Raderar de rader i tabellen "UsersInProjects" som har ett specifikt projektId
        public void DeleteUserInProject(int projectId)
        {
            var UserInProjects = db.Users.Where(row => row.Id == projectId);
            foreach (var row in UserInProjects)
            {
                db.Users.Remove(row);
            }
            db.SaveChanges();
        }

        public void CreateUserInProject(int newProjectId, string newName, string newBeskrivning, string newUserName, DateTime newDatum)
        {
            var newUserInProject = new Project()
            {
                Id = newProjectId,
                Namn = newName,
                Beskrivning = newBeskrivning,
                Username = newUserName,
                Datum = newDatum
            };
            db.projects.Add(newUserInProject);
            db.SaveChanges();
        }

        public IQueryable<string> GetUsernameInProject(int projectId)
        {
            var usernameInProject = from u in db.projects where u.Id == projectId select u.Username;
            return usernameInProject;
        }
    }
}
