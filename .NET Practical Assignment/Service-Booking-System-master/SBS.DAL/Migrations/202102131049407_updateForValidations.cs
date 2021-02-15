namespace SBS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateForValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Address1", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "ZipCode", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Contact", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "LicensePlate", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "Make", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "Model", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "ChasisNo", c => c.String(nullable: false));
            AlterColumn("dbo.Mechanics", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Mechanics", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Mechanics", "Contact", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Dealers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Dealers", "Address1", c => c.String(nullable: false));
            AlterColumn("dbo.Dealers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Dealers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Dealers", "Contact", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dealers", "Contact", c => c.String());
            AlterColumn("dbo.Dealers", "Password", c => c.String());
            AlterColumn("dbo.Dealers", "Email", c => c.String());
            AlterColumn("dbo.Dealers", "Address1", c => c.String());
            AlterColumn("dbo.Dealers", "Name", c => c.String());
            AlterColumn("dbo.Services", "Name", c => c.String());
            AlterColumn("dbo.Mechanics", "Contact", c => c.String());
            AlterColumn("dbo.Mechanics", "Email", c => c.String());
            AlterColumn("dbo.Mechanics", "Name", c => c.String());
            AlterColumn("dbo.Vehicles", "ChasisNo", c => c.String());
            AlterColumn("dbo.Vehicles", "Model", c => c.String());
            AlterColumn("dbo.Vehicles", "Make", c => c.String());
            AlterColumn("dbo.Vehicles", "LicensePlate", c => c.String());
            AlterColumn("dbo.Customers", "Contact", c => c.String());
            AlterColumn("dbo.Customers", "Password", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "ZipCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Address1", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}
