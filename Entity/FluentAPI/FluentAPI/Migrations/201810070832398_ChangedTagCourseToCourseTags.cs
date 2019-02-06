namespace FluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTagCourseToCourseTags : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TagCourses", newName: "CourseTags");
            DropForeignKey("dbo.Courses", "AuthorId", "dbo.Authors");
            DropPrimaryKey("dbo.CourseTags");
            AddPrimaryKey("dbo.CourseTags", new[] { "Course_Id", "Tag_Id" });
            AddForeignKey("dbo.Courses", "AuthorId", "dbo.Authors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "AuthorId", "dbo.Authors");
            DropPrimaryKey("dbo.CourseTags");
            AddPrimaryKey("dbo.CourseTags", new[] { "Tag_Id", "Course_Id" });
            AddForeignKey("dbo.Courses", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.CourseTags", newName: "TagCourses");
        }
    }
}
