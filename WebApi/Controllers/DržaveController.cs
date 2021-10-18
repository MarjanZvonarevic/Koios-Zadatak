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
    public class DržaveController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Države
        public IQueryable<Države> GetDržave()
        {
            return db.Države;
        }

        // GET: api/Države/5
        [ResponseType(typeof(Države))]
        public IHttpActionResult GetDržave(string id)
        {
            Države države = db.Države.Find(id);
            if (države == null)
            {
                return NotFound();
            }

            return Ok(države);
        }

        // PUT: api/Države/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDržave(string id, Države države)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != države.Država)
            {
                return BadRequest();
            }

            db.Entry(države).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DržaveExists(id))
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

        // POST: api/Države
        [ResponseType(typeof(Države))]
        public IHttpActionResult PostDržave(Države države)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Države.Add(države);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DržaveExists(države.Država))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = države.Država }, države);
        }

        // DELETE: api/Države/5
        [ResponseType(typeof(Države))]
        public IHttpActionResult DeleteDržave(string id)
        {
            Države države = db.Države.Find(id);
            if (države == null)
            {
                return NotFound();
            }

            db.Države.Remove(države);
            db.SaveChanges();

            return Ok(države);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DržaveExists(string id)
        {
            return db.Države.Count(e => e.Država == id) > 0;
        }
    }
}