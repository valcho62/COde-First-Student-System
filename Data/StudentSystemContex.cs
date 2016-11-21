using Data.Migrations;
using Models.Models;

namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentSystemContex : DbContext
    {
        
        public StudentSystemContex()
            : base("name=StudentSystemContex")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContex,Configuration>());
        }

       public virtual IDbSet<Courses> Cources { get; set; }
        public virtual IDbSet<HomeWork> HomeWorks { get; set; }
        public virtual IDbSet<Resources> Resources { get; set; }
        public virtual  IDbSet<Students> Students { get; set; }
        public virtual IDbSet<License> Licenses { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    
}