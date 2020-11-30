namespace SourceControlAssignment1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fullupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Landline", c => c.String());
            AddColumn("dbo.Users", "CreditCard", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "CreditCard");
            DropColumn("dbo.Users", "Landline");
        }
    }
}
