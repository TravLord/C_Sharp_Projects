namespace ToDoListAppV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RmvPL : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ToDo", "PriorityLevel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ToDo", "PriorityLevel", c => c.Int(nullable: false));
        }
    }
}
