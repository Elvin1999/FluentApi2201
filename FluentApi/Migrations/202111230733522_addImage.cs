namespace FluentApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Imagepath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Imagepath");
        }
    }
}
