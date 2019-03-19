namespace InternsDataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPasswordSalt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PasswordSalt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "PasswordSalt");
        }
    }
}
