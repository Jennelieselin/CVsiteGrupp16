using Data.Contexts;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProjectRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public Project GetLatest()
        {
            Project latestProject = db.projects.OrderByDescending(row => row.Datum).FirstOrDefault();
            return latestProject;
        }


        public List<Project> GetListOfProjects(string username)
        {
            ApplicationDbContext usersProjectDbContext = new ApplicationDbContext();
            var userInProjects = usersProjectDbContext.usersInProjects.Where(m => m.Username.Equals(username)).ToList();

            List<Project> listOfProjects = new List<Project>();
            foreach (var element in userInProjects)
            {
                var project = db.projects.Where(m => m.Id == element.ProjectId).FirstOrDefault();
                listOfProjects.Add(project);
            }
            return listOfProjects;
        }
    }
}
