namespace InternsDataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false),
                        County = c.String(),
                        Street = c.String(nullable: false),
                        Number = c.Int(nullable: false),
                        Zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Advertisments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Details = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        City = c.String(nullable: false),
                        SubDomain_ID = c.Int(),
                        Domain_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SubDomains", t => t.SubDomain_ID)
                .ForeignKey("dbo.Domains", t => t.Domain_ID)
                .Index(t => t.SubDomain_ID)
                .Index(t => t.Domain_ID);
            
            CreateTable(
                "dbo.QAs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false),
                        Answer = c.String(nullable: false),
                        Advertisment_ID = c.Int(),
                        SubDomain_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Advertisments", t => t.Advertisment_ID)
                .ForeignKey("dbo.SubDomains", t => t.SubDomain_ID)
                .Index(t => t.Advertisment_ID)
                .Index(t => t.SubDomain_ID);
            
            CreateTable(
                "dbo.SubDomains",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Domain_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Domains", t => t.Domain_ID)
                .Index(t => t.Domain_ID);
            
            CreateTable(
                "dbo.Domains",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SubDomainId = c.Int(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        Phone = c.String(),
                        University = c.String(),
                        RoleId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        AdvertismentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Advertisments", t => t.AdvertismentId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.AddressId)
                .Index(t => t.AdvertismentId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QAs", "SubDomain_ID", "dbo.SubDomains");
            DropForeignKey("dbo.Domains", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "AdvertismentId", "dbo.Advertisments");
            DropForeignKey("dbo.Users", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.SubDomains", "Domain_ID", "dbo.Domains");
            DropForeignKey("dbo.Advertisments", "Domain_ID", "dbo.Domains");
            DropForeignKey("dbo.Advertisments", "SubDomain_ID", "dbo.SubDomains");
            DropForeignKey("dbo.QAs", "Advertisment_ID", "dbo.Advertisments");
            DropIndex("dbo.Users", new[] { "AdvertismentId" });
            DropIndex("dbo.Users", new[] { "AddressId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Domains", new[] { "User_ID" });
            DropIndex("dbo.SubDomains", new[] { "Domain_ID" });
            DropIndex("dbo.QAs", new[] { "SubDomain_ID" });
            DropIndex("dbo.QAs", new[] { "Advertisment_ID" });
            DropIndex("dbo.Advertisments", new[] { "Domain_ID" });
            DropIndex("dbo.Advertisments", new[] { "SubDomain_ID" });
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Domains");
            DropTable("dbo.SubDomains");
            DropTable("dbo.QAs");
            DropTable("dbo.Advertisments");
            DropTable("dbo.Addresses");
        }
    }
}
