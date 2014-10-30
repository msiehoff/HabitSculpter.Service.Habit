using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using HabitSculpter.Service.Habit.Service.Models;
using ServiceModels = HabitSculpter.Service.Habit.Service.Models;

namespace HabitSculpter.Service.Habit.Service.Controllers.v100
{
    public class HabitController : ApiController
    {
        private HabitContext db = new HabitContext();

        // GET api/Habit
        public IQueryable<ServiceModels.Habit> GetHabits()
        {
            return db.Habits;
        }

        // GET api/Habit/5
        [ResponseType(typeof(ServiceModels.Habit))]
        public IHttpActionResult GetHabit(Guid id)
        {
            ServiceModels.Habit habit = db.Habits.Find(id);
            if (habit == null)
            {
                return NotFound();
            }

            return Ok(habit);
        }

        // PUT api/Habit/5
        public IHttpActionResult PutHabit(long id, ServiceModels.Habit habit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != habit.Id)
            {
                return BadRequest();
            }

            db.Entry(habit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Habit
        [ResponseType(typeof(ServiceModels.Habit))]
        public IHttpActionResult PostHabit(ServiceModels.Habit habit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Habits.Add(habit);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HabitExists(habit.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = habit.Id }, habit);
        }

        // DELETE api/Habit/5
        [ResponseType(typeof(ServiceModels.Habit))]
        public IHttpActionResult DeleteHabit(long id)
        {
            ServiceModels.Habit habit = db.Habits.Find(id);
            if (habit == null)
            {
                return NotFound();
            }

            db.Habits.Remove(habit);
            db.SaveChanges();

            return Ok(habit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HabitExists(long id)
        {
            return db.Habits.Count(e => e.Id == id) > 0;
        }
    }
}