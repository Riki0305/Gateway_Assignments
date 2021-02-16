namespace Product_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Tests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
