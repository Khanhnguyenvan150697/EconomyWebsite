using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class CategoryDao
    {
        EconomyDbContext db = new EconomyDbContext();

        public List<Category> categories()
        {
            List<Category> cates = db.Categories.ToList();
            return cates;
        }
    }
}
