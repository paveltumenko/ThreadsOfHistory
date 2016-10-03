namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "MiddleName", c => c.String(maxLength: 50));
            AddColumn("dbo.Person", "CountryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Country", "Name", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Event", "Name", c => c.String(nullable: false, maxLength: 160));
            AlterColumn("dbo.Event", "Description", c => c.String(maxLength: 1024));
            AlterColumn("dbo.Person", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Person", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.HistoryThread", "Name", c => c.String(nullable: false, maxLength: 160));
            DropColumn("dbo.Person", "MidName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "MidName", c => c.String());
            AlterColumn("dbo.HistoryThread", "Name", c => c.String());
            AlterColumn("dbo.Person", "LastName", c => c.String());
            AlterColumn("dbo.Person", "FirstName", c => c.String());
            AlterColumn("dbo.Event", "Description", c => c.String());
            AlterColumn("dbo.Event", "Name", c => c.String());
            AlterColumn("dbo.Country", "Name", c => c.String());
            DropColumn("dbo.Person", "CountryId");
            DropColumn("dbo.Person", "MiddleName");
        }
    }
}
