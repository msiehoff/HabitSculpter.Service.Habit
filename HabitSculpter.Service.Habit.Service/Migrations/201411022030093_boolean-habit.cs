namespace HabitSculpter.Service.Habit.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class booleanhabit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BooleanHabits",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        GoalValue = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Habits");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Habits",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.BooleanHabits");
        }
    }
}
