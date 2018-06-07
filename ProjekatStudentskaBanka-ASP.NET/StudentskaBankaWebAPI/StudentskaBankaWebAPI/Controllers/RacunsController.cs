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
    public class RacunsController : ApiController
    {
        private BankaModel db = new BankaModel();

        // GET: api/Racuns
        public IQueryable<Racun> GetRacun()
        {
            return db.Racun;
        }

        // GET: api/Racuns/5
        [ResponseType(typeof(Racun))]
        public async Task<IHttpActionResult> GetRacun(int id)
        {
            Racun racun = await db.Racun.FindAsync(id);
            if (racun == null)
            {
                return NotFound();
            }

            return Ok(racun);
        }

        // PUT: api/Racuns/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRacun(int id, Racun racun)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != racun.ID)
            {
                return BadRequest();
            }

            db.Entry(racun).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RacunExists(id))
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

        // POST: api/Racuns
        [ResponseType(typeof(Racun))]
        public async Task<IHttpActionResult> PostRacun(Racun racun)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Racun.Add(racun);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = racun.ID }, racun);
        }

        // DELETE: api/Racuns/5
        [ResponseType(typeof(Racun))]
        public async Task<IHttpActionResult> DeleteRacun(int id)
        {
            Racun racun = await db.Racun.FindAsync(id);
            if (racun == null)
            {
                return NotFound();
            }

            db.Racun.Remove(racun);
            await db.SaveChangesAsync();

            return Ok(racun);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RacunExists(int id)
        {
            return db.Racun.Count(e => e.ID == id) > 0;
        }
    }
}