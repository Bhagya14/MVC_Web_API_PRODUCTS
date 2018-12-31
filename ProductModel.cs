using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Web_API_Products.Models
{
    public class ProductModel
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public int productprice { get; set; }
        public string productcategory { get; set; }

    }
}