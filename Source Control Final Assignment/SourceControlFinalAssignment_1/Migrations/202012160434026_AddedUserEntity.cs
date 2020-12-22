namespace SourceControlFinalAssignment_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Code = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
