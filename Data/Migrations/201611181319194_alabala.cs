namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alabala : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 1000),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HomeWork",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 100),
                        ContentType = c.Int(nullable: false),
                        SubmisionDate = c.DateTime(nullable: false),
                        Student_Id = c.Int(nullable: false),
                        Courses_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Courses_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Courses_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        BirthDay = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TypeResource = c.Int(nullable: false),
                        URL = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentsCourses",
                c => new
                    {
                        Students_Id = c.Int(nullable: false),
                        Courses_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Students_Id, t.Courses_Id })
                .ForeignKey("dbo.Students", t => t.Students_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Courses_Id, cascadeDelete: true)
                .Index(t => t.Students_Id)
                .Index(t => t.Courses_Id);
            
            CreateTable(
                "dbo.ResourcesCourses",
                c => new
                    {
                        Resources_Id = c.Int(nullable: false),
                        Courses_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Resources_Id, t.Courses_Id })
                .ForeignKey("dbo.Resources", t => t.Resources_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Courses_Id, cascadeDelete: true)
                .Index(t => t.Resources_Id)
                .Index(t => t.Courses_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResourcesCourses", "Courses_Id", "dbo.Courses");
            DropForeignKey("dbo.ResourcesCourses", "Resources_Id", "dbo.Resources");
            DropForeignKey("dbo.HomeWork", "Courses_Id", "dbo.Courses");
            DropForeignKey("dbo.HomeWork", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.StudentsCourses", "Courses_Id", "dbo.Courses");
            DropForeignKey("dbo.StudentsCourses", "Students_Id", "dbo.Students");
            DropIndex("dbo.ResourcesCourses", new[] { "Courses_Id" });
            DropIndex("dbo.ResourcesCourses", new[] { "Resources_Id" });
            DropIndex("dbo.StudentsCourses", new[] { "Courses_Id" });
            DropIndex("dbo.StudentsCourses", new[] { "Students_Id" });
            DropIndex("dbo.HomeWork", new[] { "Courses_Id" });
            DropIndex("dbo.HomeWork", new[] { "Student_Id" });
            DropTable("dbo.ResourcesCourses");
            DropTable("dbo.StudentsCourses");
            DropTable("dbo.Licenses");
            DropTable("dbo.Resources");
            DropTable("dbo.Students");
            DropTable("dbo.HomeWork");
            DropTable("dbo.Courses");
        }
    }
}
