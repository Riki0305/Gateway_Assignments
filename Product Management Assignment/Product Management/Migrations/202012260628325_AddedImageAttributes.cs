namespace Product_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageAttributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "SmallImagePath", c => c.String());
            AddColumn("dbo.Products", "LongImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "LongImagePath");
            DropColumn("dbo.Products", "SmallImagePath");
        }
    }
}
