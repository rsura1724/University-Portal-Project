namespace UniversityApplicationPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsDeletedFieldDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "IsDeleted", c => c.Boolean(nullable: false));
        }
    }
}
