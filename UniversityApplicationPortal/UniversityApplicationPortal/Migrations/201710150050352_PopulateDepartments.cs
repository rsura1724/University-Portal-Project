namespace UniversityApplicationPortal.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateDepartments : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Departments (DepartmentName) Values ('CSE')");
            Sql("INSERT INTO Departments (DepartmentName) Values ('ECE')");
            Sql("INSERT INTO Departments (DepartmentName) Values ('IT')");
            Sql("INSERT INTO Departments (DepartmentName) Values ('Mechanical')");
            Sql("INSERT INTO Departments (DepartmentName) Values ('CE')");
        }
        
        public override void Down()
        {
            Sql("Delete from Departments where Id IN(1,2,3,4,5)");
        }
    }
}
