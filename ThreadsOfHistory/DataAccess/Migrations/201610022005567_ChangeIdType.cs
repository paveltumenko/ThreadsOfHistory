namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIdType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonEvent", "Event_Id", "dbo.Event");
            DropForeignKey("dbo.PersonEvent", "Person_Id", "dbo.Person");
            DropForeignKey("dbo.Event", "HistoryThread_Id", "dbo.HistoryThread");
            DropIndex("dbo.Event", new[] { "HistoryThread_Id" });
            DropIndex("dbo.PersonEvent", new[] { "Person_Id" });
            DropIndex("dbo.PersonEvent", new[] { "Event_Id" });
            DropPrimaryKey("dbo.Event");
            DropPrimaryKey("dbo.Person");
            DropPrimaryKey("dbo.HistoryThread");
            DropPrimaryKey("dbo.PersonEvent");
            AlterColumn("dbo.Event", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Event", "HistoryThread_Id", c => c.Long());
            AlterColumn("dbo.Person", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.HistoryThread", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.PersonEvent", "Person_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.PersonEvent", "Event_Id", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Event", "Id");
            AddPrimaryKey("dbo.Person", "Id");
            AddPrimaryKey("dbo.HistoryThread", "Id");
            AddPrimaryKey("dbo.PersonEvent", new[] { "Person_Id", "Event_Id" });
            CreateIndex("dbo.Event", "HistoryThread_Id");
            CreateIndex("dbo.PersonEvent", "Person_Id");
            CreateIndex("dbo.PersonEvent", "Event_Id");
            AddForeignKey("dbo.PersonEvent", "Event_Id", "dbo.Event", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonEvent", "Person_Id", "dbo.Person", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Event", "HistoryThread_Id", "dbo.HistoryThread", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "HistoryThread_Id", "dbo.HistoryThread");
            DropForeignKey("dbo.PersonEvent", "Person_Id", "dbo.Person");
            DropForeignKey("dbo.PersonEvent", "Event_Id", "dbo.Event");
            DropIndex("dbo.PersonEvent", new[] { "Event_Id" });
            DropIndex("dbo.PersonEvent", new[] { "Person_Id" });
            DropIndex("dbo.Event", new[] { "HistoryThread_Id" });
            DropPrimaryKey("dbo.PersonEvent");
            DropPrimaryKey("dbo.HistoryThread");
            DropPrimaryKey("dbo.Person");
            DropPrimaryKey("dbo.Event");
            AlterColumn("dbo.PersonEvent", "Event_Id", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PersonEvent", "Person_Id", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoryThread", "Id", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Person", "Id", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Event", "HistoryThread_Id", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Event", "Id", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddPrimaryKey("dbo.PersonEvent", new[] { "Person_Id", "Event_Id" });
            AddPrimaryKey("dbo.HistoryThread", "Id");
            AddPrimaryKey("dbo.Person", "Id");
            AddPrimaryKey("dbo.Event", "Id");
            CreateIndex("dbo.PersonEvent", "Event_Id");
            CreateIndex("dbo.PersonEvent", "Person_Id");
            CreateIndex("dbo.Event", "HistoryThread_Id");
            AddForeignKey("dbo.Event", "HistoryThread_Id", "dbo.HistoryThread", "Id");
            AddForeignKey("dbo.PersonEvent", "Person_Id", "dbo.Person", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonEvent", "Event_Id", "dbo.Event", "Id", cascadeDelete: true);
        }
    }
}
