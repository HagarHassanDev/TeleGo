//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Description;
//using TeleGo.Models;

//namespace TeleGo.Controllers
//{
//    public class BuyersController : ApiController
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: api/Buyers
//        public IQueryable<Buyer> GetBuyers()
//        {
//            return db.Buyers;
//        }

//        // GET: api/Buyers/5
//        [ResponseType(typeof(Buyer))]
//        public IHttpActionResult GetBuyer(string id)
//        {
//            Buyer buyer = db.Buyers.Find(id);
//            if (buyer == null)
//            {
//                return NotFound();
//            }

//            return Ok(buyer);
//        }

//        // PUT: api/Buyers/5
//        [ResponseType(typeof(void))]
//        public IHttpActionResult PutBuyer(string id, Buyer buyer)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != buyer.UserID)
//            {
//                return BadRequest();
//            }

//            db.Entry(buyer).State = EntityState.Modified;

//            try
//            {
//                db.SaveChanges();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!BuyerExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/Buyers
//        [ResponseType(typeof(Buyer))]
//        public IHttpActionResult PostBuyer(Buyer buyer)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            db.Buyers.Add(buyer);

//            try
//            {
//                db.SaveChanges();
//            }
//            catch (DbUpdateException)
//            {
//                if (BuyerExists(buyer.UserID))
//                {
//                    return Conflict();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return CreatedAtRoute("DefaultApi", new { id = buyer.UserID }, buyer);
//        }

//        // DELETE: api/Buyers/5
//        [ResponseType(typeof(Buyer))]
//        public IHttpActionResult DeleteBuyer(string id)
//        {
//            Buyer buyer = db.Buyers.Find(id);
//            if (buyer == null)
//            {
//                return NotFound();
//            }

//            db.Buyers.Remove(buyer);
//            db.SaveChanges();

//            return Ok(buyer);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool BuyerExists(string id)
//        {
//            return db.Buyers.Count(e => e.UserID == id) > 0;
//        }
//        [HttpPost]
//        [Route("api/watch/{id}/{idprod}")]
//        public IHttpActionResult POSTFAVOURITE(string id ,int idprod)
//        {
//            Product pr = new Product();
//            pr = db.Products.FirstOrDefault((x) => x.ProductID == idprod);

//            Buyer b = new Buyer();
//            b = db.Buyers.FirstOrDefault((x) => x.UserID == id);
//            b.FavouriteProducts.Add(pr);


//            return Ok(b.FavouriteProducts);
//        }
//    }
//}





/*------------*/





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
    public class BuyersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Buyers
        public /*IQueryable*/List<Buyer> GetBuyers()
        {
            return db.Buyers.ToList();
        }

        // GET: api/Buyers/5
        [ResponseType(typeof(Buyer))]
        public IHttpActionResult GetBuyer(string id)
        {
            Buyer buyer = db.Buyers.Find(id);
            if (buyer == null)
            {
                return NotFound();
            }
            return Ok(buyer);
        }

        // PUT: api/Buyers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBuyer(string id, Buyer buyer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != buyer.UserID)
            {
                return BadRequest();
            }

            db.Entry(buyer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyerExists(id))
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

        // POST: api/Buyers
        [ResponseType(typeof(Buyer))]
        public IHttpActionResult PostBuyer(Buyer buyer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Buyers.Add(buyer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BuyerExists(buyer.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = buyer.UserID }, buyer);
        }

        // DELETE: api/Buyers/5
        [ResponseType(typeof(Buyer))]
        public IHttpActionResult DeleteBuyer(string id)
        {
            Buyer buyer = db.Buyers.Find(id);
            if (buyer == null)
            {
                return NotFound();
            }

            db.Buyers.Remove(buyer);
            db.SaveChanges();

            return Ok(buyer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BuyerExists(string id)
        {
            return db.Buyers.Count(e => e.UserID == id) > 0;
        }

        //---------------------YOsra
        [HttpPost]
        [Route("api/wishlist/{id}/{idprod}")]
        public IHttpActionResult postFavourite(string id, int idprod, Product product)
        {

            var buyer = db.Buyers.FirstOrDefault(x => x.UserID == id);

            //fetch the classes from database (by id)
            var favouriteProduct = db.Products.FirstOrDefault(x => x.ProductID == idprod);

            buyer.FavouriteProducts.Add(favouriteProduct);
            product.FavouriteBuyers.Add(buyer);

            db.Entry(buyer).State = EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("api/buyer/{name}")]
        public /*IQueryable*/List<Product> getFavouriteProByBuerId(string name)
        {
            var result = db.Buyers.FirstOrDefault(p => p.UserID == name);
            var product = result.FavouriteProducts;
            // var productId=result.FavouriteProducts.Select(f => f.ProductID);

            //var result = (
            //// instance from context
            //from a in db.Buyers
            //    // instance from navigation property
            //from b in a.FavouriteProducts
            //    //join to bring useful data
            //join c in db.Products on b.ProductID equals c.ProductID
            //where a.UserID == name
            //select new Product
            //{
            //    ProductID = c.ProductID,
            //    ProductName = c.ProductName
            //}).ToList();

            return product.Select(p => p).ToList();

            //return db.Buyers.ToList();
        }



    }


}