namespace CinemaApp.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSeatsEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seats", "SeatID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Seats", "SeatID");
        }
    }
}
