namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tredjetestet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CvProfils",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Privat = c.Boolean(nullable: false),
                        Username = c.String(),
                        Namn = c.String(),
                        Adress = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Erfarenhets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Namn = c.String(nullable: false),
                        CvId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kompetens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Namn = c.String(nullable: false),
                        CvId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Avsändare = c.String(nullable: false),
                        Datum = c.DateTime(nullable: false),
                        Läst = c.Boolean(nullable: false),
                        Content = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Namn = c.String(),
                        Beskrivning = c.String(),
                        Username = c.String(),
                        Datum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Utbildnings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Namn = c.String(nullable: false),
                        CvId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUserProjects",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Project_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Project_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Project_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserProjects", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.ApplicationUserProjects", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserProjects", new[] { "Project_Id" });
            DropIndex("dbo.ApplicationUserProjects", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserProjects");
            DropTable("dbo.Utbildnings");
            DropTable("dbo.Projects");
            DropTable("dbo.Messages");
            DropTable("dbo.Kompetens");
            DropTable("dbo.Erfarenhets");
            DropTable("dbo.CvProfils");
        }
    }
}
