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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class NaseljaController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Naselja
        public IQueryable<Naselja> GetNaselja()
        {
            return db.Naselja;
        }

        // GET: api/Naselja/5
        [ResponseType(typeof(Naselja))]
        public IHttpActionResult GetNaselja(int id)
        {
            Naselja naselja = db.Naselja.Find(id);
            if (naselja == null)
            {
                return NotFound();
            }

            return Ok(naselja);
        }

        // PUT: api/Naselja/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNaselja(int id, Naselja naselja)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != naselja.NaseljeId)
            {
                return BadRequest();
            }

            db.Entry(naselja).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NaseljaExists(id))
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

        // POST: api/Naselja
        [ResponseType(typeof(Naselja))]
        public IHttpActionResult PostNaselja(Naselja naselja)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Naselja.Add(naselja);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (NaseljaExists(naselja.NaseljeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = naselja.NaseljeId }, naselja);
        }

        // DELETE: api/Naselja/5
        [ResponseType(typeof(Naselja))]
        public IHttpActionResult DeleteNaselja(int id)
        {
            Naselja naselja = db.Naselja.Find(id);
            if (naselja == null)
            {
                return NotFound();
            }

            db.Naselja.Remove(naselja);
            db.SaveChanges();

            return Ok(naselja);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NaseljaExists(int id)
        {
            return db.Naselja.Count(e => e.NaseljeId == id) > 0;
        }
    }
}