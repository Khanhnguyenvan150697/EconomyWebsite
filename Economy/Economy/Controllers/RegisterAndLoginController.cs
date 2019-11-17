using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using Economy.Common;
using Economy.Models;

namespace Economy.Controllers
{
    public class RegisterAndLoginController : Controller
    {
        EconomyDbContext db = new EconomyDbContext();
        // Register Application
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel register)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if(dao.CheckEmail(register.Email) == true)
                {
                    ModelState.AddModelError("","Email này đã tồn tại !");
                }
                else
                {
                    if(register.Password == register.RePassword)
                    {
                        var _user = new User() {
                            UserName = register.UserName,
                            Email = register.Email,
                            Password = register.Password,
                            Avatar = register.Avatar,
                            CreatedDate = DateTime.Now
                        };
                        db.Users.Add(_user);
                        db.SaveChanges();
                        ViewBag.succsess = "Đăng ký thành công";
                    }
                    else
                    {
                        ModelState.AddModelError("","Mật khẩu không trùng nhau");
                    }
                }
                return View();
            }
            else
            {
                return View();
            }
        }
        //Login application
       [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var checkAcc = new UserDao();
                if (checkAcc.CheckAccount(user.Email, user.Password) == true)
                {
                    var userSession = new UserLogin();
                    var _user = new UserDao().GetUserByID(user.Email);
                    userSession.UserID = _user.ID;
                    userSession.UserName = _user.UserName;
                    userSession.UserEmail = _user.Email;
                    userSession.Avatar = _user.Avatar;

                    //Add 2 object into Session.Add();
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    ViewBag.succsess = "Đăng nhập thành công";

                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "Email hoặc mật khẩu không đúng.");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Bạn chưa điền đầy đủ thông tin.");
                return View();
            }
        }
        // Log out application
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult DemoLogin(string txtEmail, string txtPass, string strUrl)
        {
            if (ModelState.IsValid)
            {
                var checkAcc = new UserDao();
                if (checkAcc.CheckAccount(txtEmail, txtPass) == true)
                {
                    var userSession = new UserLogin();
                    var _user = new UserDao().GetUserByID(txtEmail);
                    userSession.UserID = _user.ID;
                    userSession.UserName = _user.UserName;
                    userSession.UserEmail = _user.Email;
                    userSession.Avatar = _user.Avatar;

                    //Add 2 object into Session.Add();
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return Redirect(strUrl);
                }
                else
                {
                    ModelState.AddModelError("","Email hoặc mật khẩu không đúng");
                    return Redirect(strUrl);
                }
            }
            else
            {
                ModelState.AddModelError("", "Các trường không được để trống.");
                return Redirect(strUrl);
            }
        }
    }
}