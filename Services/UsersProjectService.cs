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
        private UsersProjectDbContext db = new UsersProjectDbContext();

        public UsersProjectService(HttpContext httpcontext)
        {
            _httpcontext = httpcontext;
        }

        public DeleteUserInProjectView GetDelecteUsersInProjectsView(int id)
        {
            ProjectDbContext projectDbContext = new ProjectDbContext();
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

        public void DeleteUserInProject(string userId)
        {
            var UserInProjects = db.usersInProjects.Where(row => row.UserId.Equals(userId));
            foreach (var row in UserInProjects)
            {
                db.usersInProjects.Remove(row);
            }
            db.SaveChanges();
        }

        // Raderar de rader i tabellen "UsersInProjects" som har ett specifikt projektId
        public void DeleteUserInProject(int projectId)
        {
            var UserInProjects = db.usersInProjects.Where(row => row.ProjectId == projectId);
            foreach (var row in UserInProjects)
            {
                db.usersInProjects.Remove(row);
            }
            db.SaveChanges();
        }

        public void CreateUserInProject(int newProjectId, string newUserId, string newUserName)
        {
            var newUserInProject = new ApplicationUserProject()
            {
                ProjectId = newProjectId,
                UserId = newUserId,
                Username = newUserName
            };
            db.usersInProjects.Add(newUserInProject);
            db.SaveChanges();
        }

        public IQueryable<string> GetUsernameInProject(int projectId)
        {
            var usernameInProject = from u in db.usersInProjects where u.ProjectId == projectId select u.Username;
            return usernameInProject;
        }
    }
}
