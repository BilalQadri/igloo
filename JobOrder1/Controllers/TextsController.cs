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
    public class TextsController : ApiController
    {
        private JobOrder1Context db = new JobOrder1Context();

        // GET: api/Texts
        public IQueryable<Text> GetTexts()
        {
            return db.Texts;
        }

        // GET: api/Texts/5
        [ResponseType(typeof(Text))]
        public async Task<IHttpActionResult> GetText(int id)
        {
            Text text = await db.Texts.FindAsync(id);
            if (text == null)
            {
                return NotFound();
            }

            return Ok(text);
        }

        // PUT: api/Texts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutText(int id, Text text)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != text.Id)
            {
                return BadRequest();
            }

            db.Entry(text).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TextExists(id))
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

        // POST: api/Texts
        [ResponseType(typeof(Text))]
        public async Task<IHttpActionResult> PostText(Text text)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Texts.Add(text);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = text.Id }, text);
        }

        // DELETE: api/Texts/5
        [ResponseType(typeof(Text))]
        public async Task<IHttpActionResult> DeleteText(int id)
        {
            Text text = await db.Texts.FindAsync(id);
            if (text == null)
            {
                return NotFound();
            }

            db.Texts.Remove(text);
            await db.SaveChangesAsync();

            return Ok(text);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TextExists(int id)
        {
            return db.Texts.Count(e => e.Id == id) > 0;
        }
    }
}