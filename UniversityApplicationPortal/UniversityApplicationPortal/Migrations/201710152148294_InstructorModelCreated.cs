namespace UniversityApplicationPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstructorModelCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InstructorName = c.String(nullable: false, maxLength: 255),
                        Designation = c.String(nullable: false, maxLength: 255),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instructors", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Instructors", new[] { "DepartmentId" });
            DropTable("dbo.Instructors");
        }
    }
}
