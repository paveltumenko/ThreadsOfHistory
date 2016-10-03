namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        Description = c.String(),
                        Scale = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        HistoryThread_Id = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HistoryThread", t => t.HistoryThread_Id)
                .Index(t => t.HistoryThread_Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FirstName = c.String(),
                        MidName = c.String(),
                        LastName = c.String(),
                        Born = c.DateTime(nullable: false),
                        Died = c.DateTime(),
                        Country_Code = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.Country_Code)
                .Index(t => t.Country_Code);
            
            CreateTable(
                "dbo.HistoryThread",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonEvent",
                c => new
                    {
                        Person_Id = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Event_Id = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Event_Id })
                .ForeignKey("dbo.Person", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Event", t => t.Event_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Event_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "HistoryThread_Id", "dbo.HistoryThread");
            DropForeignKey("dbo.PersonEvent", "Event_Id", "dbo.Event");
            DropForeignKey("dbo.PersonEvent", "Person_Id", "dbo.Person");
            DropForeignKey("dbo.Person", "Country_Code", "dbo.Country");
            DropIndex("dbo.PersonEvent", new[] { "Event_Id" });
            DropIndex("dbo.PersonEvent", new[] { "Person_Id" });
            DropIndex("dbo.Person", new[] { "Country_Code" });
            DropIndex("dbo.Event", new[] { "HistoryThread_Id" });
            DropTable("dbo.PersonEvent");
            DropTable("dbo.HistoryThread");
            DropTable("dbo.Person");
            DropTable("dbo.Event");
            DropTable("dbo.Country");
        }
    }
}
