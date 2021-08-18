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
using CoinJarWebApi.Models;

namespace CoinJarWebApi.Controllers
{
    public class CoinJarController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/CoinJar
        public IQueryable<CoinJar> GetCoinJars()
        {
            return db.CoinJars;
        }

      
        [HttpGet]
        [Route("api/CoinJar/GetTotalAmount")]
        public IHttpActionResult GetTotalAmount(decimal Amount)
        {
            return Ok(Amount);
        }

        // GET: api/CoinJar/5
        [ResponseType(typeof(CoinJar))]
        public IHttpActionResult GetCoinJar(int id)
        {
            CoinJar coinJar = db.CoinJars.Find(id);
            if (coinJar == null)
            {
                return NotFound();
            }

            return Ok(coinJar);
        }

        // PUT: api/CoinJar/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCoinJar(int id, CoinJar coinJar)
        {     
            if (id != coinJar.Id)
            {
                return BadRequest();
            }

            db.Entry(coinJar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoinJarExists(id))
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

        // POST: api/CoinJar
        [ResponseType(typeof(CoinJar))]
        public IHttpActionResult PostCoinJar(CoinJar coinJar)
        {
            db.CoinJars.Add(coinJar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = coinJar.Id }, coinJar);
        }

        // DELETE: api/CoinJar/5
        [ResponseType(typeof(CoinJar))]
        public IHttpActionResult DeleteCoinJar(int id)
        {
            CoinJar coinJar = db.CoinJars.Find(id);
            if (coinJar == null)
            {
                return NotFound();
            }

            db.CoinJars.Remove(coinJar);
            db.SaveChanges();

            return Ok(coinJar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoinJarExists(int id)
        {
            return db.CoinJars.Count(e => e.Id == id) > 0;
        }
    }
}