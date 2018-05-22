namespace RunnersLog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Runs");
            AddColumn("dbo.Runs", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Runs", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Runs");
            DropColumn("dbo.Runs", "Id");
            AddPrimaryKey("dbo.Runs", "Date");
        }
    }
}
