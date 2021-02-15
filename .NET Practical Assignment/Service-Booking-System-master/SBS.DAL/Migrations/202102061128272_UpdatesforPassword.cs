﻿namespace SBS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesforPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Password", c => c.String());
            AddColumn("dbo.Dealers", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dealers", "Password");
            DropColumn("dbo.Customers", "Password");
        }
    }
}
