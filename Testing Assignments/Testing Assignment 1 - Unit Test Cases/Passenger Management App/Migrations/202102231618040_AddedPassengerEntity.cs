namespace Passenger_Management_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPassengerEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PassengerNo = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Passengers");
        }
    }
}
