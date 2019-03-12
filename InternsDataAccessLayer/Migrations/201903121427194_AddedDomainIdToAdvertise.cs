namespace InternsDataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDomainIdToAdvertise : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Advertises", "Domain_Id", "dbo.Domains");
            DropIndex("dbo.Advertises", new[] { "Domain_Id" });
            RenameColumn(table: "dbo.Advertises", name: "Domain_Id", newName: "DomainId");
            AlterColumn("dbo.Advertises", "DomainId", c => c.Int(nullable: false));
            CreateIndex("dbo.Advertises", "DomainId");
            AddForeignKey("dbo.Advertises", "DomainId", "dbo.Domains", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advertises", "DomainId", "dbo.Domains");
            DropIndex("dbo.Advertises", new[] { "DomainId" });
            AlterColumn("dbo.Advertises", "DomainId", c => c.Int());
            RenameColumn(table: "dbo.Advertises", name: "DomainId", newName: "Domain_Id");
            CreateIndex("dbo.Advertises", "Domain_Id");
            AddForeignKey("dbo.Advertises", "Domain_Id", "dbo.Domains", "Id");
        }
    }
}
