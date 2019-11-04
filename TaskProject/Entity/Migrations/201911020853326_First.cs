namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        CreateId = c.Int(nullable: false),
                        AssignedId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.CreateId, t.AssignedId })
                .ForeignKey("dbo.Tasks", t => new { t.CreateId, t.AssignedId })
                .Index(t => new { t.CreateId, t.AssignedId });
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        CreateId = c.Int(nullable: false),
                        AssignedId = c.Int(nullable: false),
                        Title = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        Description = c.String(unicode: false, storeType: "text"),
                        Flag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.CreateId, t.AssignedId })
                .ForeignKey("dbo.Users", t => t.AssignedId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.CreateId, cascadeDelete: false)
                .Index(t => t.CreateId)
                .Index(t => t.AssignedId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Date = c.DateTime(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        Gender = c.String(),
                        Flag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", new[] { "CreateId", "AssignedId" }, "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "CreateId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "AssignedId", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "AssignedId" });
            DropIndex("dbo.Tasks", new[] { "CreateId" });
            DropIndex("dbo.Files", new[] { "CreateId", "AssignedId" });
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
            DropTable("dbo.Files");
        }
    }
}
