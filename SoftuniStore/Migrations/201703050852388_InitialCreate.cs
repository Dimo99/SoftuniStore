namespace SoftuniStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        FullName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        IsAdministrator = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Trailer = c.String(),
                        ImageThumbnail = c.String(),
                        Size = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        ReleaseDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GameUsers",
                c => new
                    {
                        Game_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Game_Id, t.User_Id })
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Game_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logins", "User_Id", "dbo.Users");
            DropForeignKey("dbo.GameUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.GameUsers", "Game_Id", "dbo.Games");
            DropIndex("dbo.GameUsers", new[] { "User_Id" });
            DropIndex("dbo.GameUsers", new[] { "Game_Id" });
            DropIndex("dbo.Logins", new[] { "User_Id" });
            DropTable("dbo.GameUsers");
            DropTable("dbo.Games");
            DropTable("dbo.Users");
            DropTable("dbo.Logins");
        }
    }
}
