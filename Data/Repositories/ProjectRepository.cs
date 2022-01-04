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
            Project senasteProjekt = db.projects.OrderByDescending(row => row.Datum).FirstOrDefault();
            return senasteProjekt;
        }


        public List<Project> GetListOfProjects(string username)
        {
            ApplicationDbContext usersInProjectsDbContext = new ApplicationDbContext();
            var userInvolvedInProjects = usersInProjectsDbContext.usersInProjects.Where(m => m.UserName.Equals(username)).ToList();

            List<Project> listOfProjects = new List<Project>();
            foreach (var element in userInvolvedInProjects)
            {
                var project = db.projects.Where(m => m.Id == element.Id).FirstOrDefault();
                listOfProjects.Add(project);
            }
            return listOfProjects;
        }
    }
}
