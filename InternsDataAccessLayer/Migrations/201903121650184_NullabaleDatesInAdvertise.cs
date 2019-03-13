namespace InternsDataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullabaleDatesInAdvertise : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Advertises", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Advertises", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Advertises", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Advertises", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
