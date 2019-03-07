namespace InternsDataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        City = c.String(nullable: false),
                        County = c.String(),
                        Street = c.String(nullable: false),
                        Number = c.Int(nullable: false),
                        Zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        Phone = c.String(),
                        University = c.String(),
                        Role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.Role_ID)
                .Index(t => t.Role_ID);
            
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
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SubDomains", t => t.SubDomain_ID)
                .ForeignKey("dbo.Domains", t => t.Domain_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.SubDomain_ID)
                .Index(t => t.Domain_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Domains",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                "dbo.QAs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false),
                        Answer = c.String(nullable: false),
                        SubDomain_ID = c.Int(),
                        Advertisment_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SubDomains", t => t.SubDomain_ID)
                .ForeignKey("dbo.Advertisments", t => t.Advertisment_ID)
                .Index(t => t.SubDomain_ID)
                .Index(t => t.Advertisment_ID);
            
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
            DropForeignKey("dbo.Users", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.Advertisments", "User_ID", "dbo.Users");
            DropForeignKey("dbo.QAs", "Advertisment_ID", "dbo.Advertisments");
            DropForeignKey("dbo.Advertisments", "Domain_ID", "dbo.Domains");
            DropForeignKey("dbo.SubDomains", "Domain_ID", "dbo.Domains");
            DropForeignKey("dbo.QAs", "SubDomain_ID", "dbo.SubDomains");
            DropForeignKey("dbo.Advertisments", "SubDomain_ID", "dbo.SubDomains");
            DropForeignKey("dbo.Addresses", "UserID", "dbo.Users");
            DropIndex("dbo.QAs", new[] { "Advertisment_ID" });
            DropIndex("dbo.QAs", new[] { "SubDomain_ID" });
            DropIndex("dbo.SubDomains", new[] { "Domain_ID" });
            DropIndex("dbo.Advertisments", new[] { "User_ID" });
            DropIndex("dbo.Advertisments", new[] { "Domain_ID" });
            DropIndex("dbo.Advertisments", new[] { "SubDomain_ID" });
            DropIndex("dbo.Users", new[] { "Role_ID" });
            DropIndex("dbo.Addresses", new[] { "UserID" });
            DropTable("dbo.Roles");
            DropTable("dbo.QAs");
            DropTable("dbo.SubDomains");
            DropTable("dbo.Domains");
            DropTable("dbo.Advertisments");
            DropTable("dbo.Users");
            DropTable("dbo.Addresses");
        }
    }
}
