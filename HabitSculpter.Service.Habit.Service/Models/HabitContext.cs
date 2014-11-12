using System.Data.Entity;

namespace HabitSculpter.Service.Habit.Service.Models
{
    public interface IHabitContext
    {
        DbSet<BooleanHabit> BooleanHabits { get; set; }
        DbSet<QuantityHabit> QuantityHabits { get; set; }

        int SaveChanges();
    }

    public class HabitContext : DbContext, IHabitContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public HabitContext() : base("name=HabitContext")
        {
        }

        public DbSet<BooleanHabit> BooleanHabits { get; set; }

        public DbSet<QuantityHabit> QuantityHabits { get; set; }

        
    
    }
}
