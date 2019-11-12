using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class BlogDao
    {
        EconomyDbContext db = new EconomyDbContext();
        
        public List<Blog> lstBlog()
        {
            var lst = db.Blogs.ToList();
            return lst;
        }

        public Blog BlogDetail(int id)
        {
            var detail = db.Blogs.Where(x => x.ID == id).FirstOrDefault();
            return detail;
        }
    }
}
