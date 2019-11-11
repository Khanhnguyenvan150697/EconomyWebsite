using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class ProductDao
    {
        EconomyDbContext db = new EconomyDbContext();
        //Get all products
        public List<Product> getAllProduct()
        {
            var lstProducts = db.Products.ToList();
            return lstProducts;
        }

        public List<Product> getAllProductSearch(string key)
        {
            var lstProducts = db.Products.Where(x => x.Name.Contains(key)).OrderByDescending(x => x.Price).ToList();
            return lstProducts;
        }

        //Get Camera products
        public List<Product> getCamera()
        {
            List<Product> Camera = db.Products.Where(x => x.CategoryName == "Máy ảnh").Take(4).OrderByDescending(x => x.ID).ToList();
            return Camera;
        }

        //Get Lens products
        public List<Product> getLens()
        {
            List<Product> Lens = db.Products.Where(x => x.CategoryName == "Ống kính").Take(4).OrderByDescending(x => x.ID).ToList();
            return Lens;
        }
        //Get Tripod products
        public List<Product> getTripod()
        {
            List<Product> Tripod = db.Products.Where(x => x.CategoryName == "Tripod").Take(4).OrderByDescending(x => x.ID).ToList();
            return Tripod;
        }
        //Get Tripod products
        public List<Product> getApple()
        {
            List<Product> Apple = db.Products.Where(x => x.CategoryName == "Apple").Take(4).OrderByDescending(x => x.ID).ToList();
            return Apple;
        }
        //Get Other products
        public List<Product> getOther()
        {
            List<Product> Other = db.Products.Where(x => x.CategoryName == "Khác").Take(4).OrderByDescending(x => x.ID).ToList();
            return Other;
        }

        //Get product by category
        public List<Product> GetAllProductByCategory(string cate)
        {
            List<Product> prods = db.Products.Where(x => x.CategoryName == cate).ToList();
            return prods;
        }

        //Get product by brand
        public List<Product> GetAllProductByBrand(string brand)
        {
            List<Product> prods = db.Products.Where(x => x.BrandName == brand).ToList();
            return prods;
        }

        //get product by id
        public Product getProductById(long? id)
        {
            Product prod = db.Products.Where(x => x.ID == id).FirstOrDefault();
            return prod;
        }
    }
}
