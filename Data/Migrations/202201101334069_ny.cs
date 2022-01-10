namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ny : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "UserName", c => c.String());
            DropColumn("dbo.Messages", "Mottagare");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Mottagare", c => c.String());
            DropColumn("dbo.Messages", "UserName");
        }
    }
}
