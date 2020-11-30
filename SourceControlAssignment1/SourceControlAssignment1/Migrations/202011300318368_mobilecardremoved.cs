namespace SourceControlAssignment1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mobilecardremoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Mobile");
            DropColumn("dbo.Users", "Landline");
            DropColumn("dbo.Users", "CreditCard");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "CreditCard", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Landline", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Mobile", c => c.Int(nullable: false));
        }
    }
}
