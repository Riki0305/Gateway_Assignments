namespace SourceControlFinalAssignment_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedStringLengths : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "ImagePath", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "ImagePath", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
