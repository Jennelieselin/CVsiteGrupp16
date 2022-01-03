﻿using Data.Contexts;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CvDbContext : ApplicationDbContext
    {
        public CvDbContext() : base() { }
        public DbSet<CvProfil> cvs { get; set; }
        public DbSet<Utbildning> utbildningar { get; set; }
        public DbSet<Erfarenhet> erfarenheter { get; set; }
        public DbSet<Kompetens> kompetens { get; set; }
    }


}
