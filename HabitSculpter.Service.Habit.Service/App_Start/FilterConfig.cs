using System.Web;
using System.Web.Mvc;

namespace HabitSculpter.Service.Habit.Service
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
