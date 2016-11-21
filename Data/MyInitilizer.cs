using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Data.Migrations;
using Models.Models;

namespace Data
{
    public class MyInitilizer :DropCreateDatabaseAlways<StudentSystemContex>
    {
        protected override void Seed(StudentSystemContex context)
        {
            StudentSystemContex contex = new StudentSystemContex();
            Random rnd = new Random();
            

            Configuration fill = new Configuration();
            fill.FillResourcesTable(contex, rnd);
            fill.FillCourcesTable(contex, rnd);
            
            fill.FillStudentsTable(contex, rnd);
            fill.FillHomeWorksTable(contex, rnd);

            fill.FillCourcesWithStudents(contex,rnd);
            fill.FillCourcesWithResources(contex,rnd);
            
            // base.Seed(context);
        }

       
    }
}