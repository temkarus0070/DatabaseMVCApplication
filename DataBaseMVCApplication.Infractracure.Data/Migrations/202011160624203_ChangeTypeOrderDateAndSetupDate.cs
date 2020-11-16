namespace DataBaseMVCApplication.Infractracure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeOrderDateAndSetupDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "DeliverDate", c => c.DateTime());
            AlterColumn("dbo.Orders", "SetupDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "SetupDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "DeliverDate", c => c.DateTime(nullable: false));
        }
    }
}
