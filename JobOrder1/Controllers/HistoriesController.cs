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
    public class HistoriesController : ApiController
    {
        private JobOrder1Context db = new JobOrder1Context();

        // GET: api/Histories
        public IQueryable<History> GetHistories()
        {
            return db.Histories;
        }

        // GET: api/Histories/5
        [ResponseType(typeof(History))]
        public async Task<IHttpActionResult> GetHistory(int id)
        {
            History history = await db.Histories.FindAsync(id);
            if (history == null)
            {
                return NotFound();
            }

            return Ok(history);
        }

        // PUT: api/Histories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHistory(int id, History history)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != history.Id)
            {
                return BadRequest();
            }

            db.Entry(history).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoryExists(id))
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

        // POST: api/Histories
        [ResponseType(typeof(History))]
        public async Task<IHttpActionResult> PostHistory(History history)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Histories.Add(history);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = history.Id }, history);
        }

        // DELETE: api/Histories/5
        [ResponseType(typeof(History))]
        public async Task<IHttpActionResult> DeleteHistory(int id)
        {
            History history = await db.Histories.FindAsync(id);
            if (history == null)
            {
                return NotFound();
            }

            db.Histories.Remove(history);
            await db.SaveChangesAsync();

            return Ok(history);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistoryExists(int id)
        {
            return db.Histories.Count(e => e.Id == id) > 0;
        }
    }
}