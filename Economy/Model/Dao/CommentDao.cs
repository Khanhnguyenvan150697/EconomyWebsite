using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class CommentDao
    {
        EconomyDbContext db = new EconomyDbContext();

        //Get 4 comment to display
        public List<CommentProuct> lst4Cmt(long? id)
        {
            var lstComment = db.CommentProucts.Where(x => x.ProductID == id).OrderByDescending(x => x.ID).Take(4).ToList();
            return lstComment;
        }

        public List<CommentBlog> lst4CmtBlog(long? id)
        {
            var lstComment = db.CommentBlogs.Where(x => x.BlogID == id).OrderByDescending(x => x.ID).Take(4).ToList();
            return lstComment;
        }

        //Get all comment to display
        public List<CommentProuct> lstAllCmt(long? id)
        {
            var lstComment = db.CommentProucts.Where(x => x.ProductID == id).OrderByDescending(x => x.ID).ToList();
            return lstComment;
        }
        public List<CommentBlog> lstAllCmtBlog(long? id)
        {
            var lstComment = db.CommentBlogs.Where(x => x.BlogID == id).OrderByDescending(x => x.ID).ToList();
            return lstComment;
        }
    }
}
