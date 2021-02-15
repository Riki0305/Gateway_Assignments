namespace SBS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRoleId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "RoleId", c => c.Int(nullable: false));
            AddColumn("dbo.Dealers", "RoleId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dealers", "RoleId");
            DropColumn("dbo.Customers", "RoleId");
        }
    }
}
