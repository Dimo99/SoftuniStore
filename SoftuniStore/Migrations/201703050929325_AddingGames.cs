namespace SoftuniStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingGames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GameUsers", newName: "UserGames");
            DropPrimaryKey("dbo.UserGames");
            AddPrimaryKey("dbo.UserGames", new[] { "User_Id", "Game_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserGames");
            AddPrimaryKey("dbo.UserGames", new[] { "Game_Id", "User_Id" });
            RenameTable(name: "dbo.UserGames", newName: "GameUsers");
        }
    }
}
