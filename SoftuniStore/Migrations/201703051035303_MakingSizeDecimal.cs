namespace SoftuniStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingSizeDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "Size", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "Size", c => c.Int(nullable: false));
        }
    }
}
