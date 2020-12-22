namespace SourceControlFinalAssignment_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedImageAttribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "ImagePath", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "ImagePath", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
