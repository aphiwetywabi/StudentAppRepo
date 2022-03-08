namespace StudentsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CourseCode = c.String(),
                        CourseDescription = c.String(),
                        Grade = c.String(),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentNumber = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "StudentID", "dbo.Students");
            DropIndex("dbo.Courses", new[] { "StudentID" });
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}
