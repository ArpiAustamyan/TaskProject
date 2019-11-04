namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumStatus : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", new[] { "CreateId", "AssignedId" }, "dbo.Tasks");
            DropPrimaryKey("dbo.Files");
            AddColumn("dbo.Files", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Users", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tasks", "Status", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Files", "Id");
            AddForeignKey("dbo.Files", new[] { "CreateId", "AssignedId" }, "dbo.Tasks", new[] { "CreateId", "AssignedId" }, cascadeDelete: true);
            DropColumn("dbo.Users", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Date", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Files", new[] { "CreateId", "AssignedId" }, "dbo.Tasks");
            DropPrimaryKey("dbo.Files");
            AlterColumn("dbo.Tasks", "Status", c => c.String());
            DropColumn("dbo.Users", "CreateDate");
            DropColumn("dbo.Files", "Id");
            AddPrimaryKey("dbo.Files", new[] { "CreateId", "AssignedId" });
            AddForeignKey("dbo.Files", new[] { "CreateId", "AssignedId" }, "dbo.Tasks", new[] { "CreateId", "AssignedId" });
        }
    }
}
