namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUserProhejct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "UserName");
        }
    }
}
