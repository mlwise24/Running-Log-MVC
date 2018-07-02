namespace RunnersLog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class runID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Runs", "RunId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Runs", "RunId");
        }
    }
}
