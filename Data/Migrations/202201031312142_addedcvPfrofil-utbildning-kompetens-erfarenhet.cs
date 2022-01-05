namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcvPfrofilutbildningkompetenserfarenhet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cvs", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectApplicationUsers", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.ProjectApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserProjects", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserProjects", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ApplicationUserProjects", new[] { "ApplicationUserId" });
            DropIndex("dbo.ApplicationUserProjects", new[] { "ProjectId" });
            DropIndex("dbo.Cvs", new[] { "ApplicationUserId" });
            DropIndex("dbo.ProjectApplicationUsers", new[] { "Project_Id" });
            DropIndex("dbo.ProjectApplicationUsers", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "Namn");
            DropColumn("dbo.AspNetUsers", "Adress");
            DropColumn("dbo.AspNetUsers", "PrivatKonto");
            DropTable("dbo.ApplicationUserProjects");
            DropTable("dbo.Cvs");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectApplicationUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProjectApplicationUsers",
                c => new
                    {
                        Project_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Project_Id, t.ApplicationUser_Id });
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Namn = c.String(),
                        Beskrivning = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cvs",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        Kompetens = c.String(),
                        Utbildning = c.String(),
                        Erfarenhet = c.String(),
                    })
                .PrimaryKey(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.ApplicationUserProjects",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicationUserId);
            
            AddColumn("dbo.AspNetUsers", "PrivatKonto", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Adress", c => c.String());
            AddColumn("dbo.AspNetUsers", "Namn", c => c.String());
            CreateIndex("dbo.ProjectApplicationUsers", "ApplicationUser_Id");
            CreateIndex("dbo.ProjectApplicationUsers", "Project_Id");
            CreateIndex("dbo.Cvs", "ApplicationUserId");
            CreateIndex("dbo.ApplicationUserProjects", "ProjectId");
            CreateIndex("dbo.ApplicationUserProjects", "ApplicationUserId");
            AddForeignKey("dbo.ApplicationUserProjects", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserProjects", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ProjectApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProjectApplicationUsers", "Project_Id", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cvs", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
