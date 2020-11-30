namespace SourceControlAssignment1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mobileNom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "MobileNom", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Mobile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Mobile", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "MobileNom");
        }
    }
}
