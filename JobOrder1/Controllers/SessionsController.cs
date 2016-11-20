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
    public class SessionsController : ApiController
    {
        private JobOrder1Context db = new JobOrder1Context();

        // GET: api/Sessions
        public IQueryable<Session> GetSessions()
        {
            return db.Sessions;
        }

        // GET: api/Sessions/5
        [ResponseType(typeof(Session))]
        public async Task<IHttpActionResult> GetSession(int id)
        {
            Session session = await db.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }

            return Ok(session);
        }

        // PUT: api/Sessions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSession(int id, Session session)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != session.Id)
            {
                return BadRequest();
            }

            db.Entry(session).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionExists(id))
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

        // POST: api/Sessions
        [ResponseType(typeof(Session))]
        public async Task<IHttpActionResult> PostSession(Session session)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sessions.Add(session);
            await db.SaveChangesAsync();
            
       //     var response = Request.CreateResponse(HttpStatusCode.Found);
          //  response.Headers.Location = new Uri(Url.Link("DefaultApi", new { controller = "Statuses", id = 1, type = "PUT" }));
            return CreatedAtRoute("DefaultApi", new { id = session.Id }, session);  
        }

        // DELETE: api/Sessions/5
        [ResponseType(typeof(Session))]
        public async Task<IHttpActionResult> DeleteSession(int id)
        {
            Session session = await db.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }

            db.Sessions.Remove(session);
            await db.SaveChangesAsync();

            return Ok(session);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SessionExists(int id)
        {
            return db.Sessions.Count(e => e.Id == id) > 0;
        }
    }
}