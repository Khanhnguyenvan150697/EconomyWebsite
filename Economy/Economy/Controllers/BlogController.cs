using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace Economy.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Blog()
        {
            var dao = new BlogDao();

            return View(dao.lstBlog());
        }
        public ActionResult BlogDetail(int id)
        {
            var dao = new BlogDao();
            var cmtDao = new CommentDao().lst4CmtBlog(id);
            ViewBag.comment = cmtDao;

            ViewBag.Session = Session[Common.CommonConstant.USER_SESSION];

            return View(dao.BlogDetail(id));
        }
    }
}