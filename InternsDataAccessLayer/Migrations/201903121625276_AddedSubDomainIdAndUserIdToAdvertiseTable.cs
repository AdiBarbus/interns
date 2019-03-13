namespace InternsDataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSubDomainIdAndUserIdToAdvertiseTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Advertises", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Advertises", "SubDomain_Id", "dbo.SubDomains");
            DropIndex("dbo.Advertises", new[] { "SubDomain_Id" });
            DropIndex("dbo.Advertises", new[] { "User_Id" });
            RenameColumn(table: "dbo.Advertises", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.Advertises", name: "SubDomain_Id", newName: "SubDomainId");
            AlterColumn("dbo.Advertises", "SubDomainId", c => c.Int(nullable: false));
            AlterColumn("dbo.Advertises", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Advertises", "UserId");
            CreateIndex("dbo.Advertises", "SubDomainId");
            AddForeignKey("dbo.Advertises", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Advertises", "SubDomainId", "dbo.SubDomains", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advertises", "SubDomainId", "dbo.SubDomains");
            DropForeignKey("dbo.Advertises", "UserId", "dbo.Users");
            DropIndex("dbo.Advertises", new[] { "SubDomainId" });
            DropIndex("dbo.Advertises", new[] { "UserId" });
            AlterColumn("dbo.Advertises", "UserId", c => c.Int());
            AlterColumn("dbo.Advertises", "SubDomainId", c => c.Int());
            RenameColumn(table: "dbo.Advertises", name: "SubDomainId", newName: "SubDomain_Id");
            RenameColumn(table: "dbo.Advertises", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Advertises", "User_Id");
            CreateIndex("dbo.Advertises", "SubDomain_Id");
            AddForeignKey("dbo.Advertises", "SubDomain_Id", "dbo.SubDomains", "Id");
            AddForeignKey("dbo.Advertises", "User_Id", "dbo.Users", "Id");
        }
    }
}
