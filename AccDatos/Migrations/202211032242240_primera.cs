namespace AccDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primera : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adress",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdressName = c.String(nullable: false),
                        Number = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.ClientId, cascadeDelete: false)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DNI = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BussinesName = c.String(nullable: false, maxLength: 50),
                        CUIT = c.String(nullable: false, maxLength: 11),
                        FantasyName = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        Adress = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompanyId = c.Int(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: false)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        SN = c.Int(nullable: false),
                        IsClosed = c.Boolean(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: false)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.SaleLine",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: false)
                .ForeignKey("dbo.Sale", t => t.SaleId, cascadeDelete: false)
                .Index(t => t.SaleId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Password = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Client_Id = c.Int(),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.Client_Id)
                .ForeignKey("dbo.Company", t => t.Company_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.Role", "User_Id", "dbo.User");
            DropForeignKey("dbo.User", "Client_Id", "dbo.Client");
            DropForeignKey("dbo.SaleLine", "SaleId", "dbo.Sale");
            DropForeignKey("dbo.SaleLine", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Sale", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Product", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Adress", "ClientId", "dbo.Client");
            DropIndex("dbo.Role", new[] { "User_Id" });
            DropIndex("dbo.User", new[] { "Company_Id" });
            DropIndex("dbo.User", new[] { "Client_Id" });
            DropIndex("dbo.SaleLine", new[] { "ProductId" });
            DropIndex("dbo.SaleLine", new[] { "SaleId" });
            DropIndex("dbo.Sale", new[] { "CompanyId" });
            DropIndex("dbo.Product", new[] { "CompanyId" });
            DropIndex("dbo.Adress", new[] { "ClientId" });
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.SaleLine");
            DropTable("dbo.Sale");
            DropTable("dbo.Product");
            DropTable("dbo.Company");
            DropTable("dbo.Client");
            DropTable("dbo.Adress");
        }
    }
}
