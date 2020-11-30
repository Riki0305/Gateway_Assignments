namespace SourceControlAssignment1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserCode = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Pincode = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        Mobile = c.Int(nullable: false),
                        Landline = c.Int(nullable: false),
                        CreditCard = c.Int(nullable: false),
                        ImageName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
