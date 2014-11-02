namespace HabitSculpter.Service.Habit.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quantityhabit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuantityHabits",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Comparison = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        GoalValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.QuantityHabits");
        }
    }
}
