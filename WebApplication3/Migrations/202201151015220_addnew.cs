namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meals", "category", c => c.String());
            AddColumn("dbo.Meals", "image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meals", "image");
            DropColumn("dbo.Meals", "category");
        }
    }
}
