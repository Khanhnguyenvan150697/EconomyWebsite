using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class BrandDao
    {
        EconomyDbContext db = new EconomyDbContext();

        public List<Brand> Brands()
        {
            List<Brand> brands = db.Brands.ToList();
            return brands;
        }
    }
}
