namespace UniversityApplicationPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sample : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentFormViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MobileNumber = c.String(),
                        Department = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentFormViewModels");
        }
    }
}
