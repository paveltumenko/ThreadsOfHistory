namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameID : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Event", new[] { "HistoryThread_Id" });
            DropIndex("dbo.PersonEvent", new[] { "Person_Id" });
            DropIndex("dbo.PersonEvent", new[] { "Event_Id" });
            CreateIndex("dbo.Event", "HistoryThread_ID");
            CreateIndex("dbo.PersonEvent", "Person_ID");
            CreateIndex("dbo.PersonEvent", "Event_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PersonEvent", new[] { "Event_ID" });
            DropIndex("dbo.PersonEvent", new[] { "Person_ID" });
            DropIndex("dbo.Event", new[] { "HistoryThread_ID" });
            CreateIndex("dbo.PersonEvent", "Event_Id");
            CreateIndex("dbo.PersonEvent", "Person_Id");
            CreateIndex("dbo.Event", "HistoryThread_Id");
        }
    }
}
