using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace Economy.Controllers
{
    public class CommentController : Controller
    {
        EconomyDbContext db = new EconomyDbContext();
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CommentProductPartial(long? txtID, string txtUserName, string contentCmt, string txtAvatar)
        {
            var cmtProd = new CommentProuct()
            {
                ProductID = txtID,
                UserName = txtUserName,
                CmtContent = contentCmt,
                Avatar = txtAvatar,
                CreatedDate = DateTime.Now
            };
            db.CommentProucts.Add(cmtProd);
            db.SaveChanges();
            return PartialView(cmtProd);
        }

        [HttpPost]
        public ActionResult GetAllComment(long? idProdtxt)
        {
            var cmtDao = new CommentDao().lstAllCmt(idProdtxt);
            return PartialView(cmtDao);

        }



        // Comment function for blog
        [HttpPost]
        public ActionResult CommentBlogPartial(long? txtID, string txtUserName, string contentCmt, string txtAvatar)
        {
            var cmtBlog = new CommentBlog()
            {
                BlogID = txtID,
                UserName = txtUserName,
                CmtContent = contentCmt,
                Avatar = txtAvatar,
                CreatedDate = DateTime.Now
            };
            db.CommentBlogs.Add(cmtBlog);
            db.SaveChanges();
            return PartialView(cmtBlog);
        }

        [HttpPost]
        public ActionResult GetAllCommentBlog(long? idProdtxt)
        {
            var cmtDao = new CommentDao().lstAllCmtBlog(idProdtxt);
            return PartialView(cmtDao);

        }
    }
}