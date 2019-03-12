namespace InternsDataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSubdomainIdandAdvertiseIdPropsToQATable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QAs", "Advertise_Id", "dbo.Advertises");
            DropForeignKey("dbo.QAs", "SubDomain_Id", "dbo.SubDomains");
            DropIndex("dbo.QAs", new[] { "SubDomain_Id" });
            DropIndex("dbo.QAs", new[] { "Advertise_Id" });
            RenameColumn(table: "dbo.QAs", name: "Advertise_Id", newName: "AdvertiseId");
            RenameColumn(table: "dbo.QAs", name: "SubDomain_Id", newName: "SubDomainId");
            AlterColumn("dbo.QAs", "SubDomainId", c => c.Int(nullable: false));
            AlterColumn("dbo.QAs", "AdvertiseId", c => c.Int(nullable: false));
            CreateIndex("dbo.QAs", "SubDomainId");
            CreateIndex("dbo.QAs", "AdvertiseId");
            AddForeignKey("dbo.QAs", "AdvertiseId", "dbo.Advertises", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QAs", "SubDomainId", "dbo.SubDomains", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QAs", "SubDomainId", "dbo.SubDomains");
            DropForeignKey("dbo.QAs", "AdvertiseId", "dbo.Advertises");
            DropIndex("dbo.QAs", new[] { "AdvertiseId" });
            DropIndex("dbo.QAs", new[] { "SubDomainId" });
            AlterColumn("dbo.QAs", "AdvertiseId", c => c.Int());
            AlterColumn("dbo.QAs", "SubDomainId", c => c.Int());
            RenameColumn(table: "dbo.QAs", name: "SubDomainId", newName: "SubDomain_Id");
            RenameColumn(table: "dbo.QAs", name: "AdvertiseId", newName: "Advertise_Id");
            CreateIndex("dbo.QAs", "Advertise_Id");
            CreateIndex("dbo.QAs", "SubDomain_Id");
            AddForeignKey("dbo.QAs", "SubDomain_Id", "dbo.SubDomains", "Id");
            AddForeignKey("dbo.QAs", "Advertise_Id", "dbo.Advertises", "Id");
        }
    }
}
