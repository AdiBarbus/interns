namespace InternsDataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRememberMeUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "RememberMe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "RememberMe", c => c.Boolean(nullable: false));
        }
    }
}
