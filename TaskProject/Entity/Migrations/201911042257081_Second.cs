namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "TaskId", c => c.Int(nullable: false));
            CreateIndex("dbo.Files", "TaskId");
            AddForeignKey("dbo.Files", "TaskId", "dbo.Tasks", "Id", cascadeDelete:false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "TaskId", "dbo.Tasks");
            DropIndex("dbo.Files", new[] { "TaskId" });
            DropColumn("dbo.Files", "TaskId");
        }
    }
}
