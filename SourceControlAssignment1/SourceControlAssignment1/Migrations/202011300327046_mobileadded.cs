namespace SourceControlAssignment1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mobileadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Mobile", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Mobile");
        }
    }
}
