namespace SBS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForgotPasswordToken : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ForgotPasswordTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(),
                        UserId = c.Int(nullable: false),
                        RequestDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ForgotPasswordTokens");
        }
    }
}
