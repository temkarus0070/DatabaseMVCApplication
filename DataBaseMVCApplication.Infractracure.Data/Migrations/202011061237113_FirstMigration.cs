namespace DataBaseMVCApplication.Infractracure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        BuyerId = c.Long(nullable: false, identity: true),
                        FIO = c.String(),
                        Phone = c.String(),
                        IsLegalEntity = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BuyerId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Long(nullable: false, identity: true),
                        SellerId = c.Long(),
                        BuyerId = c.Long(),
                        IsDeliver = c.Boolean(nullable: false),
                        IsSetup = c.Boolean(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        DeliverDate = c.DateTime(nullable: false),
                        SetupDate = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Buyers", t => t.BuyerId)
                .ForeignKey("dbo.Sellers", t => t.SellerId)
                .Index(t => t.SellerId)
                .Index(t => t.BuyerId);
            
            CreateTable(
                "dbo.OrderPositions",
                c => new
                    {
                        OrderPositionId = c.Long(nullable: false, identity: true),
                        OrderId = c.Long(),
                        WindowId = c.Long(),
                        Length = c.Double(nullable: false),
                        Width = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.OrderPositionId)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Windows", t => t.WindowId)
                .Index(t => t.OrderId)
                .Index(t => t.WindowId);
            
            CreateTable(
                "dbo.Windows",
                c => new
                    {
                        WindowId = c.Long(nullable: false, identity: true),
                        ManufactorId = c.Long(),
                        Price = c.Double(nullable: false),
                        Color = c.String(),
                        Having = c.Boolean(nullable: false),
                        Image = c.Binary(),
                        Description = c.String(),
                        Manufactor_ManufactorId = c.Int(),
                    })
                .PrimaryKey(t => t.WindowId)
                .ForeignKey("dbo.Manufactors", t => t.Manufactor_ManufactorId)
                .Index(t => t.Manufactor_ManufactorId);
            
            CreateTable(
                "dbo.Manufactors",
                c => new
                    {
                        ManufactorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ManufactorId);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        SellerId = c.Long(nullable: false, identity: true),
                        FIO = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        PercentFromOrder = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.SellerId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        PriceToOne = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.OrderPositions", "WindowId", "dbo.Windows");
            DropForeignKey("dbo.Windows", "Manufactor_ManufactorId", "dbo.Manufactors");
            DropForeignKey("dbo.OrderPositions", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "BuyerId", "dbo.Buyers");
            DropIndex("dbo.Windows", new[] { "Manufactor_ManufactorId" });
            DropIndex("dbo.OrderPositions", new[] { "WindowId" });
            DropIndex("dbo.OrderPositions", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "BuyerId" });
            DropIndex("dbo.Orders", new[] { "SellerId" });
            DropTable("dbo.Services");
            DropTable("dbo.Sellers");
            DropTable("dbo.Manufactors");
            DropTable("dbo.Windows");
            DropTable("dbo.OrderPositions");
            DropTable("dbo.Orders");
            DropTable("dbo.Buyers");
        }
    }
}
