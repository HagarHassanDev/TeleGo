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
using TeleGo.Models;

namespace TeleGo.Controllers
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Products
        public /*IQueryable*/List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            db.SaveChanges();

           return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
            //return Ok();

        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.FirstOrDefault(i=>i.ProductID==id);
            if (product == null)
            {
                return NotFound();
            }
            product.CategoryID =0;
            product.SellerID = null;

            product.FavouriteBuyers = null;
            product.Seller = null;
            product.Category = null;
            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }

        //[Route("api/product/{name}")]
        // [Route("api/product/{name:alpha}")]
        //[HttpGet]
        [Route("api/Product/{name}")]
        public IHttpActionResult GetProductforsellers(string name)
        {
            List<Product> mypro = new List<Product>();
            var product = new List<Product>();
             product= db.Products.Where(x=>x.SellerID==name).ToList();
            Console.WriteLine(product);
            if (product == null)
            {
                return NotFound();
            }
           // mypro.Add(product.ToList());

            return Ok(product);
        }


        //============FOR COOKIE 

        public static List<Product> myArray = new List<Product>();
        [Route("api/clearList")]
        [HttpGet]
        public IHttpActionResult getclearList()
        {
            myArray.Clear();
            return Ok();
        }

    }
}