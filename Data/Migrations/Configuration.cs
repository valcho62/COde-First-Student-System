using System.Collections.Generic;
using Models.Models;

namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemContex>

    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;

        }
        StudentSystemContex contex = new StudentSystemContex();
        protected  override void Seed(StudentSystemContex contex)
        {
           
            Random rnd = new Random();
            
            FillCourcesTable(contex,  rnd);
            FillResourcesTable(contex, rnd);
            FillStudentsTable(contex, rnd);
            FillHomeWorksTable(contex, rnd);

            FillCourcesWithStudents(contex, rnd);
            FillCourcesWithResources(contex, rnd);
        }

        public void FillCourcesWithResources(StudentSystemContex contex, Random rnd)
        {
            foreach (var item in this.contex.Cources)
            {
                var numberOfResources = rnd.Next(1, 20);
                for (int i = 0; i < numberOfResources; i++)
                {
                    var resIndex = rnd.Next(1, 10);

                    var temp = this.contex.Resources.Where(x => x.Id == resIndex).First();
                    var temp1 =new Resources();
                    temp1 = temp;
                    item.Resources.Add(temp1);
                    
                }
                
            }
            this.contex.SaveChanges();
        }

        public void FillCourcesWithStudents(StudentSystemContex contex, Random rnd)
        {
           

            foreach (var item in this.contex.Cources)
            {
                var numberOfStudents = rnd.Next(1, 20);
                for (int i = 0; i < numberOfStudents; i++)
                {
                    var studentIndex = rnd.Next(1, 10);

                    var temp = this.contex.Students.Where(x => x.Id == studentIndex).First();
                    item.Students.Add(temp);
                } 
            }
            this.contex.SaveChanges();
        }

        public void FillStudentsTable(StudentSystemContex contex, Random rnd)
        {
            var names = new List<string>() {"Val", "Valcho", "Valenti", "Val4o"};
            var phones = new List<string>() {"123-4332", "123-4332-342", "123-4", "1113-4332"};
            var students = new List<Students>();
            for (int i = 0; i < 10; i++)
            {
                var courseId = rnd.Next(1, 10);
                var course = this.contex.Cources.Where(x => x.Id == courseId).First();
                var temp = new Students()
                {
                    Name = names[rnd.Next(0,3)],
                    PhoneNumber = phones[rnd.Next(0,3)],
                    RegistrationDate = DateTime.Now,
                    
                };
                temp.Cources.Add(course);
                students.Add(temp);
            }
           
            foreach (var stud in students)
            {
                contex.Students.AddOrUpdate(p => p.Name, stud);
            }
            contex.SaveChanges();
        }

        public void FillHomeWorksTable(StudentSystemContex contex, Random rnd)
        {
            var homeNames = new List<string>() { "DObre be", "Imalo li", "Imashe", "May pak da" };
            var home = new List<HomeWork>();
            for (int i = 0; i < 10; i++)
            {
                var tempId = rnd.Next(1, 4);
                var temp = new HomeWork()
                {
                    
                    Content = homeNames[rnd.Next(0, 3)],
                    ContentType = (ContentType)rnd.Next(0, 2),
                    Student = this.contex.Students.Where(x => x.Id == tempId).First(),
                    SubmisionDate = DateTime.Now
                };
                home.Add(temp);
            }
            home.ForEach(res => contex.HomeWorks.AddOrUpdate(x => x.Content, res));
            contex.SaveChanges();
        }

        public void FillResourcesTable(StudentSystemContex contex, Random rnd)
        {
           var resNames = new List<string>() {"Uchebnik","Film","I kakvo","Mozhe bi da"};
            var resss = new List<Resources>();
            for (int i = 0; i < 10; i++)
            {
                var temp = new Resources()
                {
                    Name = resNames[rnd.Next(0,3)],
                    TypeResource = (TypeResource)rnd.Next(0,3),
                    URL = resNames[rnd.Next(0,3)].Substring(0,3)
                };
                resss.Add(temp);
            }
            resss.ForEach(res => contex.Resources.AddOrUpdate(x => x.Id,res));
            contex.SaveChanges();
        }

        public void FillCourcesTable(StudentSystemContex contex,Random rnd)
        {
            var courseName = new List<string>() {"Math","Filosofy","BEL","Phisic"};
            DateTime start = new DateTime(2000,1,1);
            var cources = new List<Courses>();
            for (int i = 0; i < 10; i++)
            {
                
                var temp = new Courses()
                {
                    Name = courseName[rnd.Next(0,3)],
                    Price = 1.0M * rnd.Next(1,200),
                    StartDate = start.AddDays(rnd.Next(1,365)),
                    EndDate = start.AddDays(rnd.Next(365,700))
                };
               
                cources.Add(temp);
            }
            cources.ForEach(course => contex.Cources.AddOrUpdate(x => x.Name,course));
            contex.SaveChanges();
        }
    }
}
