﻿using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Shared.Models
{
    public class CvEditImg
    {
        public int Id { get; set; }
        public string CurrentPath { get; set; }
        public HttpPostedFileBase Image { get; set; }
    }

    public class CvIndex
    {
        public int Id { get; set; }
        public string Namn  { get; set; }
        public string Adress { get; set; }
        [Required]
        public bool Privat { get; set; }
        public string ImagePath { get; set; }
        public string Username { get; set; }
        public List<Erfarenhet> ListOfErfarenhet { get; set; }
        public List<Kompetens> ListOfKompetens { get; set; }
        public List<Project> ListOfProjects { get; set; }
        public List<Utbildning> ListOfUtbildning { get; set; }
      
    }

    public class CvEditInfo
    {
        public int Id { get; set; }
        public string Namn  { get; set; }
        public string Adress { get; set; }
        [Required]
        public bool Privat { get; set; }    

    }

    
}
