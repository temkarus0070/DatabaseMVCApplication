namespace DataBaseMVCApplication.Infractracure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBaseEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "BuyerId", "dbo.Buyers");
            DropForeignKey("dbo.OrderPositions", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.OrderPositions", "WindowId", "dbo.Windows");
            DropForeignKey("dbo.Windows", "Manufactor_ManufactorId", "dbo.Manufactors");
            DropIndex("dbo.Orders", new[] { "SellerId" });
            DropIndex("dbo.Orders", new[] { "BuyerId" });
            DropIndex("dbo.OrderPositions", new[] { "OrderId" });
            DropIndex("dbo.OrderPositions", new[] { "WindowId" });
            DropIndex("dbo.Windows", new[] { "Manufactor_ManufactorId" });
            DropColumn("dbo.Windows", "ManufactorId");
            RenameColumn(table: "dbo.Windows", name: "Manufactor_ManufactorId", newName: "ManufactorId");
            DropPrimaryKey("dbo.Buyers");
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.OrderPositions");
            DropPrimaryKey("dbo.Windows");
            DropPrimaryKey("dbo.Manufactors");
            DropPrimaryKey("dbo.Sellers");
            DropPrimaryKey("dbo.Services");
            DropColumn("dbo.Buyers", "BuyerId");
            DropColumn("dbo.Orders", "OrderId");
            DropColumn("dbo.OrderPositions", "OrderPositionId");
            DropColumn("dbo.Windows", "WindowId");
            DropColumn("dbo.Manufactors", "ManufactorId");
            DropColumn("dbo.Sellers", "SellerId");
            DropColumn("dbo.Services", "ServiceId");
            AddColumn("dbo.Buyers", "Id", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.Orders", "Id", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.OrderPositions", "Id", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.Windows", "Id", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.Manufactors", "Id", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.Sellers", "Id", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.Services", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Orders", "SellerId", c => c.Long(nullable: false));
            AlterColumn("dbo.Orders", "BuyerId", c => c.Long(nullable: false));
            AlterColumn("dbo.OrderPositions", "OrderId", c => c.Long(nullable: false));
            AlterColumn("dbo.OrderPositions", "WindowId", c => c.Long(nullable: false));
            AlterColumn("dbo.Windows", "ManufactorId", c => c.Long(nullable: false));
            AlterColumn("dbo.Windows", "ManufactorId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Buyers", "Id");
            AddPrimaryKey("dbo.Orders", "Id");
            AddPrimaryKey("dbo.OrderPositions", "Id");
            AddPrimaryKey("dbo.Windows", "Id");
            AddPrimaryKey("dbo.Manufactors", "Id");
            AddPrimaryKey("dbo.Sellers", "Id");
            AddPrimaryKey("dbo.Services", "Id");
            CreateIndex("dbo.Orders", "SellerId");
            CreateIndex("dbo.Orders", "BuyerId");
            CreateIndex("dbo.OrderPositions", "OrderId");
            CreateIndex("dbo.OrderPositions", "WindowId");
            CreateIndex("dbo.Windows", "ManufactorId");
            AddForeignKey("dbo.Orders", "BuyerId", "dbo.Buyers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderPositions", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "SellerId", "dbo.Sellers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderPositions", "WindowId", "dbo.Windows", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Windows", "ManufactorId", "dbo.Manufactors", "Id", cascadeDelete: true);
          
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "ServiceId", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.Sellers", "SellerId", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.Manufactors", "ManufactorId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Windows", "WindowId", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.OrderPositions", "OrderPositionId", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.Orders", "OrderId", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.Buyers", "BuyerId", c => c.Long(nullable: false, identity: true));
            DropForeignKey("dbo.Windows", "ManufactorId", "dbo.Manufactors");
            DropForeignKey("dbo.OrderPositions", "WindowId", "dbo.Windows");
            DropForeignKey("dbo.Orders", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.OrderPositions", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "BuyerId", "dbo.Buyers");
            DropIndex("dbo.Windows", new[] { "ManufactorId" });
            DropIndex("dbo.OrderPositions", new[] { "WindowId" });
            DropIndex("dbo.OrderPositions", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "BuyerId" });
            DropIndex("dbo.Orders", new[] { "SellerId" });
            DropPrimaryKey("dbo.Services");
            DropPrimaryKey("dbo.Sellers");
            DropPrimaryKey("dbo.Manufactors");
            DropPrimaryKey("dbo.Windows");
            DropPrimaryKey("dbo.OrderPositions");
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.Buyers");
            AlterColumn("dbo.Windows", "ManufactorId", c => c.Int());
            AlterColumn("dbo.Windows", "ManufactorId", c => c.Long());
            AlterColumn("dbo.OrderPositions", "WindowId", c => c.Long());
            AlterColumn("dbo.OrderPositions", "OrderId", c => c.Long());
            AlterColumn("dbo.Orders", "BuyerId", c => c.Long());
            AlterColumn("dbo.Orders", "SellerId", c => c.Long());
            DropColumn("dbo.Services", "Id");
            DropColumn("dbo.Sellers", "Id");
            DropColumn("dbo.Manufactors", "Id");
            DropColumn("dbo.Windows", "Id");
            DropColumn("dbo.OrderPositions", "Id");
            DropColumn("dbo.Orders", "Id");
            DropColumn("dbo.Buyers", "Id");
            AddPrimaryKey("dbo.Services", "ServiceId");
            AddPrimaryKey("dbo.Sellers", "SellerId");
            AddPrimaryKey("dbo.Manufactors", "ManufactorId");
            AddPrimaryKey("dbo.Windows", "WindowId");
            AddPrimaryKey("dbo.OrderPositions", "OrderPositionId");
            AddPrimaryKey("dbo.Orders", "OrderId");
            AddPrimaryKey("dbo.Buyers", "BuyerId");
            RenameColumn(table: "dbo.Windows", name: "ManufactorId", newName: "Manufactor_ManufactorId");
            AddColumn("dbo.Windows", "ManufactorId", c => c.Long());
            CreateIndex("dbo.Windows", "Manufactor_ManufactorId");
            CreateIndex("dbo.OrderPositions", "WindowId");
            CreateIndex("dbo.OrderPositions", "OrderId");
            CreateIndex("dbo.Orders", "BuyerId");
            CreateIndex("dbo.Orders", "SellerId");
            AddForeignKey("dbo.Windows", "Manufactor_ManufactorId", "dbo.Manufactors", "ManufactorId");
            AddForeignKey("dbo.OrderPositions", "WindowId", "dbo.Windows", "WindowId");
            AddForeignKey("dbo.Orders", "SellerId", "dbo.Sellers", "SellerId");
            AddForeignKey("dbo.OrderPositions", "OrderId", "dbo.Orders", "OrderId");
            AddForeignKey("dbo.Orders", "BuyerId", "dbo.Buyers", "BuyerId");
        }
    }
}
