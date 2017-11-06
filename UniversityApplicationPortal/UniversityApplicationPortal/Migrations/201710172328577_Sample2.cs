namespace UniversityApplicationPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sample2 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.StudentFormViewModels");
        }
        
        public override void Down()
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
    }
}
