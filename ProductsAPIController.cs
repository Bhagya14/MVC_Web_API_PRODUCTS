using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_Web_API_Products.Models;

namespace MVC_Web_API_Products.Controllers
{
    public class ProductsAPIController : ApiController
    {
        MyDbContext db = new MyDbContext();
        // GET: api/ProductsAPI
        public IEnumerable<ProductModel> Get()
        {
            return db.Products.ToList();

        }

        // GET: api/ProductsAPI/5
        public ProductModel Get(int id)
        {
            return db.Products.FirstOrDefault(p => p.productid == id);
        }

        // POST: api/ProductsAPI
        public bool Post([FromBody]ProductModel value)
        {
            db.Products.Add(value);
            db.SaveChanges();
            return true;
        }

        // PUT: api/ProductsAPI/5
        public void Put(int id, [FromBody]ProductModel value)
        {
            var dbmodel = db.Products.FirstOrDefault(p => p.productid == id);
            dbmodel.productname = value.productname;
            dbmodel.productprice = value.productprice;
            dbmodel.productcategory = value.productcategory;

        }

        // DELETE: api/ProductsAPI/5
        public void Delete(int id)
        {
            var model = (from o in db.Products
                         where o.productid == id
                         select o).FirstOrDefault();
            db.Products.Remove(model);
            db.SaveChanges();
        }
        [Route("api/ProductsAPI/Search/{key}")]
        [HttpGet]
        public IEnumerable<ProductModel> Search(string key)
        {
            var model = db.Products.Where(o => o.productname.Contains(key) || o.productcategory.Contains(key)).ToList();
            return model;
        }
    }
}

