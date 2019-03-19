namespace InternsDataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RememberMeUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RememberMe", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "RememberMe");
        }
    }
}
