namespace CinemaApp.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chairs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SeatFK = c.Int(nullable: false),
                        ScheduleFK = c.Int(nullable: false),
                        Reservation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Schedules", t => t.ScheduleFK)
                .ForeignKey("dbo.Seats", t => t.SeatFK)
                .Index(t => t.SeatFK)
                .Index(t => t.ScheduleFK);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        movieFK = c.Int(nullable: false),
                        hallFK = c.Int(nullable: false),
                        AvailableSeats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Halls", t => t.hallFK)
                .ForeignKey("dbo.Movies", t => t.movieFK)
                .Index(t => t.movieFK)
                .Index(t => t.hallFK);
            
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationFK = c.Int(nullable: false),
                        TotalRows = c.Int(nullable: false),
                        TotalSeats = c.Int(nullable: false),
                        Name = c.String(),
                        WheelchairAccesibility = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationFK)
                .Index(t => t.LocationFK);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        ZipCode = c.String(),
                        Phone = c.String(),
                        Mail = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Language = c.String(),
                        Subtitle = c.String(),
                        Writer = c.String(),
                        Stars = c.String(),
                        Website = c.String(),
                        IMDB = c.String(),
                        Trailer = c.String(),
                        ImageData = c.String(),
                        Kijkwijzer = c.String(),
                        ThumbnailData = c.String(),
                        Type = c.String(),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RowFK = c.Int(nullable: false),
                        HallFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Halls", t => t.HallFK)
                .ForeignKey("dbo.Rows", t => t.RowFK)
                .Index(t => t.RowFK)
                .Index(t => t.HallFK);
            
            CreateTable(
                "dbo.Rows",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HallFK = c.Int(nullable: false),
                        TotalSeats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Halls", t => t.HallFK)
                .Index(t => t.HallFK);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Kijkwijzers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Character = c.String(),
                        ImageData = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderCode = c.Int(nullable: false),
                        ScheduleFK = c.Int(nullable: false),
                        TicketFK = c.Int(nullable: false),
                        Paid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Schedules", t => t.ScheduleFK)
                .Index(t => t.ScheduleFK);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MovieFK = c.Int(nullable: false),
                        HallFK = c.Int(nullable: false),
                        RowFK = c.Int(nullable: false),
                        SeatFK = c.Int(nullable: false),
                        RateFK = c.Int(nullable: false),
                        OrderCode = c.Int(nullable: false),
                        ScheduleFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Halls", t => t.HallFK)
                .ForeignKey("dbo.Movies", t => t.MovieFK)
                .ForeignKey("dbo.Rates", t => t.RateFK)
                .ForeignKey("dbo.Rows", t => t.RowFK)
                .ForeignKey("dbo.Schedules", t => t.ScheduleFK)
                .ForeignKey("dbo.Seats", t => t.SeatFK)
                .Index(t => t.MovieFK)
                .Index(t => t.HallFK)
                .Index(t => t.RowFK)
                .Index(t => t.SeatFK)
                .Index(t => t.RateFK)
                .Index(t => t.ScheduleFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "SeatFK", "dbo.Seats");
            DropForeignKey("dbo.Tickets", "ScheduleFK", "dbo.Schedules");
            DropForeignKey("dbo.Tickets", "RowFK", "dbo.Rows");
            DropForeignKey("dbo.Tickets", "RateFK", "dbo.Rates");
            DropForeignKey("dbo.Tickets", "MovieFK", "dbo.Movies");
            DropForeignKey("dbo.Tickets", "HallFK", "dbo.Halls");
            DropForeignKey("dbo.Orders", "ScheduleFK", "dbo.Schedules");
            DropForeignKey("dbo.Chairs", "SeatFK", "dbo.Seats");
            DropForeignKey("dbo.Seats", "RowFK", "dbo.Rows");
            DropForeignKey("dbo.Rows", "HallFK", "dbo.Halls");
            DropForeignKey("dbo.Seats", "HallFK", "dbo.Halls");
            DropForeignKey("dbo.Chairs", "ScheduleFK", "dbo.Schedules");
            DropForeignKey("dbo.Schedules", "movieFK", "dbo.Movies");
            DropForeignKey("dbo.Schedules", "hallFK", "dbo.Halls");
            DropForeignKey("dbo.Halls", "LocationFK", "dbo.Locations");
            DropIndex("dbo.Tickets", new[] { "ScheduleFK" });
            DropIndex("dbo.Tickets", new[] { "RateFK" });
            DropIndex("dbo.Tickets", new[] { "SeatFK" });
            DropIndex("dbo.Tickets", new[] { "RowFK" });
            DropIndex("dbo.Tickets", new[] { "HallFK" });
            DropIndex("dbo.Tickets", new[] { "MovieFK" });
            DropIndex("dbo.Orders", new[] { "ScheduleFK" });
            DropIndex("dbo.Rows", new[] { "HallFK" });
            DropIndex("dbo.Seats", new[] { "HallFK" });
            DropIndex("dbo.Seats", new[] { "RowFK" });
            DropIndex("dbo.Halls", new[] { "LocationFK" });
            DropIndex("dbo.Schedules", new[] { "hallFK" });
            DropIndex("dbo.Schedules", new[] { "movieFK" });
            DropIndex("dbo.Chairs", new[] { "ScheduleFK" });
            DropIndex("dbo.Chairs", new[] { "SeatFK" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Rates");
            DropTable("dbo.Orders");
            DropTable("dbo.Kijkwijzers");
            DropTable("dbo.Genres");
            DropTable("dbo.Rows");
            DropTable("dbo.Seats");
            DropTable("dbo.Movies");
            DropTable("dbo.Locations");
            DropTable("dbo.Halls");
            DropTable("dbo.Schedules");
            DropTable("dbo.Chairs");
        }
    }
}
