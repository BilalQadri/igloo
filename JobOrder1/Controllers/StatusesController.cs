using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using JobOrder1.Models;

namespace JobOrder1.Controllers
{
    public class StatusesController : ApiController
    {
        private JobOrder1Context db = new JobOrder1Context();

        // GET: api/Statuses
        public IQueryable<Statuse> GetStatuses()
        {
            return db.Statuses;
        }

        // GET: api/Statuses/5
        [ResponseType(typeof(Statuse))]
        public async Task<IHttpActionResult> GetStatuse(int id)
        {
            Statuse statuse = await db.Statuses.FindAsync(id);
            if (statuse == null)
            {
                return NotFound();
            }

            return Ok(statuse);
        }

        // PUT: api/Statuses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStatuse(int id, Statuse statuse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statuse.Id)
            {
                return BadRequest();
            }

            db.Entry(statuse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatuseExists(id))
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

        // POST: api/Statuses
        [ResponseType(typeof(Statuse))]
        public async Task<IHttpActionResult> PostStatuse(Statuse statuse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Statuses.Add(statuse);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = statuse.Id }, statuse);
        }

        // DELETE: api/Statuses/5
        [ResponseType(typeof(Statuse))]
        public async Task<IHttpActionResult> DeleteStatuse(int id)
        {
            Statuse statuse = await db.Statuses.FindAsync(id);
            if (statuse == null)
            {
                return NotFound();
            }

            db.Statuses.Remove(statuse);
            await db.SaveChangesAsync();

            return Ok(statuse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatuseExists(int id)
        {
            return db.Statuses.Count(e => e.Id == id) > 0;
        }
    }
}