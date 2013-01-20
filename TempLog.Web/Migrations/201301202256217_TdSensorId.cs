namespace TempLog.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TdSensorId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sensors", "TdSensorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sensors", "TdSensorId");
        }
    }
}
