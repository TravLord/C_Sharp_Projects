namespace ToDoListAppV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToDoPriorityAndDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDo", "ItemDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ToDo", "PriorityLevel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDo", "PriorityLevel");
            DropColumn("dbo.ToDo", "ItemDate");
        }
    }
}
