

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Data;
using Data.Migrations;
using Models.Models;

namespace Console_App
{
    class Program
    {
        static void Main()
        {
           //Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContex,Configuration>());
            //Database.SetInitializer(new MyInitilizer());
            StudentSystemContex contex = new StudentSystemContex();

            //contex.Database.Initialize(false);

            Console.WriteLine(contex.Students.Count());
            //Console.WriteLine(contex.Resources.Count());
            //Console.WriteLine(contex.Cources.Count());
            //Console.WriteLine(contex.HomeWorks.Count());
            
        }

    }
}
