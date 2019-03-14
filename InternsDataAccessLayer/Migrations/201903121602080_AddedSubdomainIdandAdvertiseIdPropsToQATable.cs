namespace InternsDataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSubdomainIdandAdvertiseIdPropsToQATable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Qas", "Advertise_Id", "dbo.Advertises");
            DropForeignKey("dbo.Qas", "SubDomain_Id", "dbo.SubDomains");
            DropIndex("dbo.Qas", new[] { "SubDomain_Id" });
            DropIndex("dbo.Qas", new[] { "Advertise_Id" });
            RenameColumn(table: "dbo.Qas", name: "Advertise_Id", newName: "AdvertiseId");
            RenameColumn(table: "dbo.Qas", name: "SubDomain_Id", newName: "SubDomainId");
            AlterColumn("dbo.Qas", "SubDomainId", c => c.Int(nullable: false));
            AlterColumn("dbo.Qas", "AdvertiseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Qas", "SubDomainId");
            CreateIndex("dbo.Qas", "AdvertiseId");
            AddForeignKey("dbo.Qas", "AdvertiseId", "dbo.Advertises", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Qas", "SubDomainId", "dbo.SubDomains", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Qas", "SubDomainId", "dbo.SubDomains");
            DropForeignKey("dbo.Qas", "AdvertiseId", "dbo.Advertises");
            DropIndex("dbo.Qas", new[] { "AdvertiseId" });
            DropIndex("dbo.Qas", new[] { "SubDomainId" });
            AlterColumn("dbo.Qas", "AdvertiseId", c => c.Int());
            AlterColumn("dbo.Qas", "SubDomainId", c => c.Int());
            RenameColumn(table: "dbo.Qas", name: "SubDomainId", newName: "SubDomain_Id");
            RenameColumn(table: "dbo.Qas", name: "AdvertiseId", newName: "Advertise_Id");
            CreateIndex("dbo.Qas", "Advertise_Id");
            CreateIndex("dbo.Qas", "SubDomain_Id");
            AddForeignKey("dbo.Qas", "SubDomain_Id", "dbo.SubDomains", "Id");
            AddForeignKey("dbo.Qas", "Advertise_Id", "dbo.Advertises", "Id");
        }
    }
}
