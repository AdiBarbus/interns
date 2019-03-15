namespace InternsDataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCreateDateToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            DropColumn("dbo.Users", "CreateDate");
        }
    }
}
