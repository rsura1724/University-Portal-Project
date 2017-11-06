namespace UniversityApplicationPortal.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class DataAnnotaionInCourse : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CourseName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "CourseName", c => c.String());
        }
    }
}
