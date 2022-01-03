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
        private ProjectDbContext db = new ProjectDbContext();

        public Project GetLatest()
        {
            Project senasteProjekt = db.projects.OrderByDescending(row => row.Datum).FirstOrDefault();
            return senasteProjekt;
        }


        public List<Project> GetListOfProjects(string username)
        {
            UsersProjectDbContext usersInProjectsDbContext = new UsersProjectDbContext();
            var userInvolvedInProjects = usersInProjectsDbContext.usersInProjects.Where(m => m.Username.Equals(username)).ToList();

            List<Project> listOfProjects = new List<Project>();
            foreach (var element in userInvolvedInProjects)
            {
                var project = db.projects.Where(m => m.Id == element.ProjectId).FirstOrDefault();
                listOfProjects.Add(project);
            }
            return listOfProjects;
        }
    }
}
