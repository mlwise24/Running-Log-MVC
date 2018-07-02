namespace RunnersLog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idendity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserRuns",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Run_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Run_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Runs", t => t.Run_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Run_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserRuns", "Run_Id", "dbo.Runs");
            DropForeignKey("dbo.ApplicationUserRuns", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserRuns", new[] { "Run_Id" });
            DropIndex("dbo.ApplicationUserRuns", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserRuns");
        }
    }
}
