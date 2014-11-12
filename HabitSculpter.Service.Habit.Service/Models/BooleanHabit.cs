using System.Collections.Generic;

namespace HabitSculpter.Service.Habit.Service.Models
{
    public class BooleanHabit : Habit<bool>
    {
        public override List<ActivityLog<bool>> ActivityLogs { get; set; }

        public override bool WasGoalAccomplished(ActivityLog<bool> activityLog)
        {
            return activityLog.ActivityValue == GoalValue;
        }

        public override void LogActivity(IHabitContext context, ActivityLog<bool> activityLog)
        {
            this.ActivityLogs.Add(activityLog);

            context.SaveChanges();
        }

         
    }
}