using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaiThiKimHien_2122110261.Models
{
    public class HomeModel
    {
        public List<CartModel> Cart { get; set; }
        public Product Product { get; set; }
        public List<Product> ListProduct { get; set; }
        public List<Category> ListCategory { get; set; }
        public List<Brand> ListBrand { get; set; }
        public List<Banner> ListBanner { get; set; }
       
    }
}