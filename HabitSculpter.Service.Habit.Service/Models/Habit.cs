using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HabitSculpter.Service.Habit.Service.Models
{
    public abstract class Habit<TValueType>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public TValueType GoalValue { get; set; }

        public abstract List<ActivityLog<TValueType>> ActivityLogs { get; set; }

        public abstract bool WasGoalAccomplished(ActivityLog<TValueType> activityLog);
        public abstract void LogActivity(IHabitContext context, ActivityLog<TValueType> activityLog);
    }
}