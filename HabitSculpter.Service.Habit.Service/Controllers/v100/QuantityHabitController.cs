using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using HabitSculpter.Service.Habit.Service.Models;

namespace HabitSculpter.Service.Habit.Service.Controllers.v100
{
    public class QuantityHabitController : ApiController
    {
        private readonly HabitContext _db = new HabitContext();

        // GET api/QuantityHabit
        public IQueryable<QuantityHabit> GetQuantityHabits()
        {
            return _db.QuantityHabits;
        }

        // GET api/QuantityHabit/5
        [ResponseType(typeof(QuantityHabit))]
        public IHttpActionResult GetQuantityHabit(long id)
        {
            QuantityHabit quantityhabit = _db.QuantityHabits.Find(id);
            if (quantityhabit == null)
            {
                return NotFound();
            }

            return Ok(quantityhabit);
        }

        // PUT api/QuantityHabit/5
        public IHttpActionResult PutQuantityHabit(long id, QuantityHabit quantityhabit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quantityhabit.Id)
            {
                return BadRequest();
            }

            _db.Entry(quantityhabit).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuantityHabitExists(id))
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

        // POST api/QuantityHabit
        [ResponseType(typeof(QuantityHabit))]
        public IHttpActionResult PostQuantityHabit(QuantityHabit quantityhabit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.QuantityHabits.Add(quantityhabit);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = quantityhabit.Id }, quantityhabit);
        }

        // DELETE api/QuantityHabit/5
        [ResponseType(typeof(QuantityHabit))]
        public IHttpActionResult DeleteQuantityHabit(long id)
        {
            QuantityHabit quantityhabit = _db.QuantityHabits.Find(id);
            if (quantityhabit == null)
            {
                return NotFound();
            }

            _db.QuantityHabits.Remove(quantityhabit);
            _db.SaveChanges();

            return Ok(quantityhabit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuantityHabitExists(long id)
        {
            return _db.QuantityHabits.Count(e => e.Id == id) > 0;
        }
    }
}