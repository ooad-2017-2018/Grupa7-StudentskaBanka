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
using StudentskaBankaWebAPI.Models;

namespace StudentskaBankaWebAPI.Controllers
{
    public class TransakcijasController : ApiController
    {
        private BankaModel db = new BankaModel();

        // GET: api/Transakcijas
        public IQueryable<Transakcija> GetTransakcija()
        {
            return db.Transakcija;
        }

        // GET: api/Transakcijas/5
        [ResponseType(typeof(Transakcija))]
        public async Task<IHttpActionResult> GetTransakcija(int id)
        {
            Transakcija transakcija = await db.Transakcija.FindAsync(id);
            if (transakcija == null)
            {
                return NotFound();
            }

            return Ok(transakcija);
        }

        // PUT: api/Transakcijas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTransakcija(int id, Transakcija transakcija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transakcija.ID)
            {
                return BadRequest();
            }

            db.Entry(transakcija).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransakcijaExists(id))
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

        // POST: api/Transakcijas
        [ResponseType(typeof(Transakcija))]
        public async Task<IHttpActionResult> PostTransakcija(Transakcija transakcija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Transakcija.Add(transakcija);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = transakcija.ID }, transakcija);
        }

        // DELETE: api/Transakcijas/5
        [ResponseType(typeof(Transakcija))]
        public async Task<IHttpActionResult> DeleteTransakcija(int id)
        {
            Transakcija transakcija = await db.Transakcija.FindAsync(id);
            if (transakcija == null)
            {
                return NotFound();
            }

            db.Transakcija.Remove(transakcija);
            await db.SaveChangesAsync();

            return Ok(transakcija);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransakcijaExists(int id)
        {
            return db.Transakcija.Count(e => e.ID == id) > 0;
        }
    }
}