using System;

namespace HabitSculpter.Service.Habit.Service.Models
{
    public abstract class ActivityLog<TValueType>
    {
        public DateTime ActivityDate { get; set; }
        public TValueType ActivityValue { get; set; }
    }
}