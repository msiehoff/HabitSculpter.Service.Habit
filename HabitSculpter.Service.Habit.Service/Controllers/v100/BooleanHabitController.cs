using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HabitSculpter.Service.Habit.Service.Models;

namespace HabitSculpter.Service.Habit.Service.Controllers.v100
{
    public class BooleanHabitController : ApiController
    {
        private HabitContext db = new HabitContext();

        // GET api/BooleanHabit
        public IQueryable<BooleanHabit> GetBooleanHabits()
        {
            return db.BooleanHabits;
        }

        // GET api/BooleanHabit/5
        [ResponseType(typeof(BooleanHabit))]
        public IHttpActionResult GetBooleanHabit(long id)
        {
            BooleanHabit booleanhabit = db.BooleanHabits.Find(id);
            if (booleanhabit == null)
            {
                return NotFound();
            }

            return Ok(booleanhabit);
        }

        // PUT api/BooleanHabit/5
        public IHttpActionResult PutBooleanHabit(long id, BooleanHabit booleanhabit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != booleanhabit.Id)
            {
                return BadRequest();
            }

            db.Entry(booleanhabit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooleanHabitExists(id))
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

        // POST api/BooleanHabit
        [ResponseType(typeof(BooleanHabit))]
        public IHttpActionResult PostBooleanHabit(BooleanHabit booleanhabit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BooleanHabits.Add(booleanhabit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = booleanhabit.Id }, booleanhabit);
        }

        // DELETE api/BooleanHabit/5
        [ResponseType(typeof(BooleanHabit))]
        public IHttpActionResult DeleteBooleanHabit(long id)
        {
            BooleanHabit booleanhabit = db.BooleanHabits.Find(id);
            if (booleanhabit == null)
            {
                return NotFound();
            }

            db.BooleanHabits.Remove(booleanhabit);
            db.SaveChanges();

            return Ok(booleanhabit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BooleanHabitExists(long id)
        {
            return db.BooleanHabits.Count(e => e.Id == id) > 0;
        }
    }
}