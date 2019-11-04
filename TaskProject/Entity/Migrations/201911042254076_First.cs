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
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateId = c.Int(nullable: false),
                        AssignedId = c.Int(nullable: false),
                        Title = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Description = c.String(unicode: false, storeType: "text"),
                        Flag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AssignedId, cascadeDelete: false
                )
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
                        Birthday = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        Gender = c.String(),
                        Flag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "CreateId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "AssignedId", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "AssignedId" });
            DropIndex("dbo.Tasks", new[] { "CreateId" });
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
            DropTable("dbo.Files");
        }
    }
}
