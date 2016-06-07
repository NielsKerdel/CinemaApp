namespace CinemaApp.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "isHoliday", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "isHoliday");
        }
    }
}
