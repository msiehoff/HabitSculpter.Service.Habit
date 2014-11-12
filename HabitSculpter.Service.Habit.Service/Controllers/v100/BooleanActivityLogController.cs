using System;
using System.Web.Http;
using HabitSculpter.Service.Habit.Service.Models;

namespace HabitSculpter.Service.Habit.Service.Controllers.v100
{
    public class LogBooleanActivityRequest
    {
        public ActivityLog<bool> ActivityLog { get; set; }
        public long HabitId { get; set; }
    }

    public class BooleanActivityLogController : ApiController
    {
        // POST: api/BooleanActivityLog/
        [Route("api/BooleanActivityLog")]
        [HttpPost]
        public IHttpActionResult PostBooleanActivityLog(LogBooleanActivityRequest request)
        {
            if (request.ActivityLog == null || request.HabitId == 0)
                return BadRequest();

            using (var context = new HabitContext())
            {
                BooleanHabit habit = context.BooleanHabits.Find(request.HabitId);

                if (habit == null)
                    return NotFound();

                try
                {
                    habit.LogActivity(context, request.ActivityLog);
                }
                catch (Exception e)
                {
                    return InternalServerError(e);
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = request.HabitId }, request.ActivityLog);
        }
	}
}