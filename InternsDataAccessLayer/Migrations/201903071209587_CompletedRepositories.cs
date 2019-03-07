namespace InternsDataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompletedRepositories : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Advertisments", "SubDomain_ID", "dbo.SubDomains");
            DropForeignKey("dbo.QAs", "SubDomain_ID", "dbo.SubDomains");
            DropForeignKey("dbo.SubDomains", "Domain_ID", "dbo.Domains");
            DropForeignKey("dbo.QAs", "Advertisment_ID", "dbo.Advertisments");
            DropForeignKey("dbo.Users", "Role_ID", "dbo.Roles");
            DropIndex("dbo.Addresses", new[] { "UserID" });
            DropIndex("dbo.Users", new[] { "Role_ID" });
            DropIndex("dbo.Advertisments", new[] { "SubDomain_ID" });
            DropIndex("dbo.Advertisments", new[] { "Domain_ID" });
            DropIndex("dbo.Advertisments", new[] { "User_ID" });
            DropIndex("dbo.SubDomains", new[] { "Domain_ID" });
            DropIndex("dbo.QAs", new[] { "SubDomain_ID" });
            DropIndex("dbo.QAs", new[] { "Advertisment_ID" });
            CreateIndex("dbo.Addresses", "UserId");
            CreateIndex("dbo.Advertisments", "Domain_Id");
            CreateIndex("dbo.Advertisments", "User_Id");
            DropColumn("dbo.Users", "Role_ID");
            DropColumn("dbo.Advertisments", "SubDomain_ID");
            DropColumn("dbo.SubDomains", "Domain_ID");
            DropColumn("dbo.QAs", "SubDomain_ID");
            DropColumn("dbo.QAs", "Advertisment_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QAs", "Advertisment_ID", c => c.Int());
            AddColumn("dbo.QAs", "SubDomain_ID", c => c.Int());
            AddColumn("dbo.SubDomains", "Domain_ID", c => c.Int());
            AddColumn("dbo.Advertisments", "SubDomain_ID", c => c.Int());
            AddColumn("dbo.Users", "Role_ID", c => c.Int());
            DropIndex("dbo.Advertisments", new[] { "User_Id" });
            DropIndex("dbo.Advertisments", new[] { "Domain_Id" });
            DropIndex("dbo.Addresses", new[] { "UserId" });
            CreateIndex("dbo.QAs", "Advertisment_ID");
            CreateIndex("dbo.QAs", "SubDomain_ID");
            CreateIndex("dbo.SubDomains", "Domain_ID");
            CreateIndex("dbo.Advertisments", "User_ID");
            CreateIndex("dbo.Advertisments", "Domain_ID");
            CreateIndex("dbo.Advertisments", "SubDomain_ID");
            CreateIndex("dbo.Users", "Role_ID");
            CreateIndex("dbo.Addresses", "UserID");
            AddForeignKey("dbo.Users", "Role_ID", "dbo.Roles", "ID");
            AddForeignKey("dbo.QAs", "Advertisment_ID", "dbo.Advertisments", "ID");
            AddForeignKey("dbo.SubDomains", "Domain_ID", "dbo.Domains", "ID");
            AddForeignKey("dbo.QAs", "SubDomain_ID", "dbo.SubDomains", "ID");
            AddForeignKey("dbo.Advertisments", "SubDomain_ID", "dbo.SubDomains", "ID");
        }
    }
}
