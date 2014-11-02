using System;
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

        //public Type ValueType { get { return typeof(TValueType); } }
        public TValueType GoalValue { get; set; }

        //public abstract List<ActivityLog<TValueType>> ActivityLogs { get; set; }

        public abstract bool WasGoalAccomplished(ActivityLog<TValueType> activityLog);
    }

    public class BooleanHabit : Habit<bool>
    {
        //public override List<ActivityLog<bool>> ActivityLogs { get; set; }

        public override bool WasGoalAccomplished(ActivityLog<bool> activityLog)
        {
            return activityLog.ActivityValue == GoalValue;
        }
    }

    public abstract class ActivityLog<TValueType>
    {
        public DateTime ActivityDate { get; set; }
        public TValueType ActivityValue { get; set; }
    }
}