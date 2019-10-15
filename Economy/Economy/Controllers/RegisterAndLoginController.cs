using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Economy.Common;
using Economy.Models;

namespace Economy.Controllers
{
    public class RegisterAndLoginController : Controller
    {
        // Register Application
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            EconomyDbContext db = null;
            db = new EconomyDbContext();
            if(ModelState.IsValid)
            {
                var _user = new User()
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    Email = user.Email,
                    CreatedDate = DateTime.Now
                };
                db.Users.Add(_user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        // Login application
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            if(ModelState.IsValid)
            {
                if(CheckAccount(user.Email, user.Password) == true)
                {
                    var userSession = new UserLogin();
                    var _user = GetUserByID(user.Email);
                    userSession.UserID = _user.ID;
                    userSession.UserName = _user.UserName;

                    //Add 2 object into Session.Add();
                    Session.Add(CommonConstant.USER_SESSION, userSession);

                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return View();
                }
                
            }
            else
            {
                return View();
            }
        }
        public bool CheckAccount(string email, string passWord)
        {
            EconomyDbContext db = null;
            db = new EconomyDbContext();
            var _user = db.Users.FirstOrDefault(x => x.Email == email && x.Password == passWord);
            if (_user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public User GetUserByID(string email)
        {
            EconomyDbContext db = null;
            db = new EconomyDbContext();

            var _user = db.Users.FirstOrDefault(x => x.Email == email);
            return _user;
            
        }

        // Log out application
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }
}