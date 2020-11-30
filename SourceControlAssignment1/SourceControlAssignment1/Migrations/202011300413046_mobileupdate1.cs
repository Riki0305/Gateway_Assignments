namespace SourceControlAssignment1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mobileupdate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "MobileNom", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "MobileNom", c => c.Int(nullable: false));
        }
    }
}
