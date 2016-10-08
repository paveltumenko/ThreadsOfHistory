namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 160),
                        Description = c.String(maxLength: 1024),
                        Scale = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        EndDate = c.DateTime(storeType: "date"),
                        HistoryThread_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HistoryThread", t => t.HistoryThread_ID)
                .Index(t => t.HistoryThread_ID);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Born = c.DateTime(nullable: false, storeType: "date"),
                        Died = c.DateTime(storeType: "date"),
                        CountryId = c.Int(nullable: false),
                        Country_Code = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Country", t => t.Country_Code)
                .Index(t => t.Country_Code);
            
            CreateTable(
                "dbo.HistoryThread",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 160),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PersonEvent",
                c => new
                    {
                        Person_ID = c.Long(nullable: false),
                        Event_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_ID, t.Event_ID })
                .ForeignKey("dbo.Person", t => t.Person_ID, cascadeDelete: true)
                .ForeignKey("dbo.Event", t => t.Event_ID, cascadeDelete: true)
                .Index(t => t.Person_ID)
                .Index(t => t.Event_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "HistoryThread_ID", "dbo.HistoryThread");
            DropForeignKey("dbo.PersonEvent", "Event_ID", "dbo.Event");
            DropForeignKey("dbo.PersonEvent", "Person_ID", "dbo.Person");
            DropForeignKey("dbo.Person", "Country_Code", "dbo.Country");
            DropIndex("dbo.PersonEvent", new[] { "Event_ID" });
            DropIndex("dbo.PersonEvent", new[] { "Person_ID" });
            DropIndex("dbo.Person", new[] { "Country_Code" });
            DropIndex("dbo.Event", new[] { "HistoryThread_ID" });
            DropTable("dbo.PersonEvent");
            DropTable("dbo.HistoryThread");
            DropTable("dbo.Person");
            DropTable("dbo.Event");
            DropTable("dbo.Country");
        }
    }
}
