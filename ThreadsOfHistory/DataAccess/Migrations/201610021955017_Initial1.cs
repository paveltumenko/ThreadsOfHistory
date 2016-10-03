namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Event", "StartDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Event", "EndDate", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Person", "Born", c => c.DateTime(nullable: false, precision: 3, storeType: "datetime2"));
            AlterColumn("dbo.Person", "Died", c => c.DateTime(precision: 3, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Person", "Died", c => c.DateTime());
            AlterColumn("dbo.Person", "Born", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Event", "EndDate", c => c.DateTime());
            AlterColumn("dbo.Event", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
