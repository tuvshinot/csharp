namespace CodeFirstExistingDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTitleInCoursesToName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Name", c => c.String(nullable: false));
            // before drop we need to do get values from this to our new name 
            //1.
            //RenameColumn("dbo.Courses", "Title", "Name");
            //2
            Sql("Update Courses Set Name = Title");
            DropColumn("dbo.Courses", "Title");
        }
        
        public override void Down() // when you mess up with database and want to back version 
        {
            AddColumn("dbo.Courses", "Title", c => c.String(nullable: false));
            Sql("Update Courses Set Title = Name");
            DropColumn("dbo.Courses", "Name");
        }
    }
}
