namespace MyEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostContentRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Content", c => c.String());
        }
    }
}
