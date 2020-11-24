namespace DataBaseMVCApplication.Infractracure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelToWindow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Windows", "Model", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Windows", "Model");
        }
    }
}
