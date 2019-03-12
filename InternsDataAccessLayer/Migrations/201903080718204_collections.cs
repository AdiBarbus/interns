namespace InternsDataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class collections : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Role_Id", c => c.Int());
            AddColumn("dbo.Advertises", "SubDomain_Id", c => c.Int());
            AddColumn("dbo.QAs", "SubDomain_Id", c => c.Int());
            AddColumn("dbo.QAs", "Advertise_Id", c => c.Int());
            AddColumn("dbo.SubDomains", "Domain_Id", c => c.Int());
            CreateIndex("dbo.Users", "Role_Id");
            CreateIndex("dbo.Advertises", "SubDomain_Id");
            CreateIndex("dbo.SubDomains", "Domain_Id");
            CreateIndex("dbo.QAs", "SubDomain_Id");
            CreateIndex("dbo.QAs", "Advertise_Id");
            AddForeignKey("dbo.Advertises", "SubDomain_Id", "dbo.SubDomains", "Id");
            AddForeignKey("dbo.QAs", "SubDomain_Id", "dbo.SubDomains", "Id",cascadeDelete:true);
            AddForeignKey("dbo.SubDomains", "Domain_Id", "dbo.Domains", "Id", cascadeDelete:true);
            AddForeignKey("dbo.QAs", "Advertise_Id", "dbo.Advertises", "Id");
            AddForeignKey("dbo.Users", "Role_Id", "dbo.Roles", "Id");
            AddColumn("dbo.Users", "UserName", c => c.String(nullable: false));
            DropColumn("dbo.Users", "FirstName");
            DropColumn("dbo.Users", "LastName");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.QAs", "Advertise_Id", "dbo.Advertises");
            DropForeignKey("dbo.SubDomains", "Domain_Id", "dbo.Domains");
            DropForeignKey("dbo.QAs", "SubDomain_Id", "dbo.SubDomains");
            DropForeignKey("dbo.Advertises", "SubDomain_Id", "dbo.SubDomains");
            DropIndex("dbo.QAs", new[] { "Advertise_Id" });
            DropIndex("dbo.QAs", new[] { "SubDomain_Id" });
            DropIndex("dbo.SubDomains", new[] { "Domain_Id" });
            DropIndex("dbo.Advertises", new[] { "SubDomain_Id" });
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropColumn("dbo.SubDomains", "Domain_Id");
            DropColumn("dbo.QAs", "Advertise_Id");
            DropColumn("dbo.QAs", "SubDomain_Id");
            DropColumn("dbo.Advertises", "SubDomain_Id");
            DropColumn("dbo.Users", "Role_Id");
            AddColumn("dbo.Users", "LastName", c => c.String());
            AddColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.Users", "UserName");
        }
    }
}
