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
using Product_Management.Models;
using Product_Management.Utility;

namespace Product_Management.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductContext db = new ProductContext();

        // GET: api/Products
        //Get all products
        public IQueryable<Product> GetProduct()
        {

            db.Product.Include(c => c.Category).ToList();
            IEnumerable<Product> products = db.Product.OrderBy(x => x.Name);
            MyLogger.GetInstance().Info("All products sent successfully.");
            return (IQueryable<Product>)products;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
           db.Product.Include(c => c.Category).ToList();
            Product product = db.Product.Find(id);

            if (product == null)
            {
                MyLogger.GetInstance().Warn("id : "+id+" Not found in database");
                return NotFound();
            }
            MyLogger.GetInstance().Info("id : " + id + " found in database");
            return Ok(product);
        }

        // GET: api/Products/searchBy/search
        //Product Search
        [HttpGet]
        [Route("api/Products/ProductSearch/{searchBy}/{search}")]
        public IHttpActionResult ProductSearch(string searchBy, string search)
        {


            db.Product.Include(c => c.Category).ToList();
            if (searchBy == "Category")
            {

                var product = db.Product.Where(x => x.Category.Name == search || search == null);
                MyLogger.GetInstance().Info("Search By category : "+search);
                return Ok(product);
            }
            else if (searchBy == "Name")
            {
                var product = db.Product.Where(x => x.Name.StartsWith(search) || search == null);
                MyLogger.GetInstance().Info("Search By Name : " + search);
                return Ok(product);
            }
            else
            {
                MyLogger.GetInstance().Error("SearchBy not found Error." );
                return NotFound();
            }

        }

        

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                MyLogger.GetInstance().Info("Product Id : "+id+" updated.");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    MyLogger.GetInstance().Error("Product does not exists with ID : " + id);
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

            db.Product.Add(product);
            db.SaveChanges();
            MyLogger.GetInstance().Info("Product saved with name : " + product.Name);
            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Product.Remove(product);
            db.SaveChanges();
            MyLogger.GetInstance().Info("Product Id : " + id + " removed.");
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
            return db.Product.Count(e => e.Id == id) > 0;
        }
    }
}