namespace UniversityApplicationPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentAndCourseMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentUserId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        MobileNumber = c.String(),
                        CourseId = c.Int(nullable: false),
                        StudentUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.StudentUser_Id)
                .Index(t => t.CourseId)
                .Index(t => t.StudentUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StudentUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Students", "CourseId", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "StudentUser_Id" });
            DropIndex("dbo.Students", new[] { "CourseId" });
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}
