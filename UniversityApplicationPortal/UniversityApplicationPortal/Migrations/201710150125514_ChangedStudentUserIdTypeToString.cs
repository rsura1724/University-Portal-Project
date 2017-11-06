namespace UniversityApplicationPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedStudentUserIdTypeToString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "StudentUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Students", new[] { "StudentUser_Id" });
            DropColumn("dbo.Students", "StudentUserId");
            RenameColumn(table: "dbo.Students", name: "StudentUser_Id", newName: "StudentUserId");
            AlterColumn("dbo.Students", "StudentUserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Students", "StudentUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Students", "StudentUserId");
            AddForeignKey("dbo.Students", "StudentUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StudentUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Students", new[] { "StudentUserId" });
            AlterColumn("dbo.Students", "StudentUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Students", "StudentUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Students", name: "StudentUserId", newName: "StudentUser_Id");
            AddColumn("dbo.Students", "StudentUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "StudentUser_Id");
            AddForeignKey("dbo.Students", "StudentUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
