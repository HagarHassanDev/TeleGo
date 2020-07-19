namespace TeleGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tmo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductImage", c => c.Binary());
        }
    }
}
