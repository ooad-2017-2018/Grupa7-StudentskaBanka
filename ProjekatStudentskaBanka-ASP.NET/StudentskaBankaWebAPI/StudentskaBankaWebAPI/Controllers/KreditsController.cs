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
    public class KreditsController : ApiController
    {
        private BankaModel db = new BankaModel();

        // GET: api/Kredits
        public IQueryable<Kredit> GetKredit()
        {
            return db.Kredit;
        }

        // GET: api/Kredits/5
        [ResponseType(typeof(Kredit))]
        public async Task<IHttpActionResult> GetKredit(int id)
        {
            Kredit kredit = await db.Kredit.FindAsync(id);
            if (kredit == null)
            {
                return NotFound();
            }

            return Ok(kredit);
        }

        // PUT: api/Kredits/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKredit(int id, Kredit kredit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kredit.ID)
            {
                return BadRequest();
            }

            db.Entry(kredit).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KreditExists(id))
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

        // POST: api/Kredits
        [ResponseType(typeof(Kredit))]
        public async Task<IHttpActionResult> PostKredit(Kredit kredit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kredit.Add(kredit);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = kredit.ID }, kredit);
        }

        // DELETE: api/Kredits/5
        [ResponseType(typeof(Kredit))]
        public async Task<IHttpActionResult> DeleteKredit(int id)
        {
            Kredit kredit = await db.Kredit.FindAsync(id);
            if (kredit == null)
            {
                return NotFound();
            }

            db.Kredit.Remove(kredit);
            await db.SaveChangesAsync();

            return Ok(kredit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KreditExists(int id)
        {
            return db.Kredit.Count(e => e.ID == id) > 0;
        }
    }
}