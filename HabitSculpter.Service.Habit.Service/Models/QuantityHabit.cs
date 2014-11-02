using System;
using System.Collections.Generic;

namespace HabitSculpter.Service.Habit.Service.Models
{
    public class QuantityHabit : Habit<int>
    {
        public override List<ActivityLog<int>> ActivityLogs { get; set; }
        public GoalComparison Comparison { get; set; }

        private readonly Dictionary<GoalComparison, Func<ActivityLog<int>, int, bool>> _comparisonFuncs = new Dictionary<GoalComparison, Func<ActivityLog<int>, int, bool>>()
        {
            {GoalComparison.EqualTo, (activityLog, goalValue) => activityLog.ActivityValue == goalValue},
            {GoalComparison.GreaterThan, (activityLog, goalValue) => activityLog.ActivityValue > goalValue},
            {GoalComparison.GreaterThanOrEqualTo, (activityLog, goalValue) => activityLog.ActivityValue >= goalValue},
            {GoalComparison.LessThan, (activityLog, goalValue) => activityLog.ActivityValue < goalValue},
            {GoalComparison.LessThanOrEqualTo, (activityLog, goalValue) => activityLog.ActivityValue <= goalValue},
        };

        public override bool WasGoalAccomplished(ActivityLog<int> activityLog)
        {
            Func<ActivityLog<int>, int, bool> comparisonFunction;
            if(!_comparisonFuncs.TryGetValue(Comparison, out comparisonFunction))
                throw new ArgumentOutOfRangeException();

            return comparisonFunction.Invoke(activityLog, GoalValue);
        }
    }
}