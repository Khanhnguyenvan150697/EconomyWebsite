﻿using System;
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
            if (ModelState.IsValid)
            {
                var checkAcc = new UserDao();
                if(checkAcc.CheckAccount(user.Email, user.Password) == true)
                {
                    var userSession = new UserLogin();
                    var _user = new UserDao().GetUserByID(user.Email);
                    userSession.UserID = _user.ID;
                    userSession.UserName = _user.UserName;
                    userSession.UserEmail = _user.Email;

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
        // Log out application
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
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

                    //Add 2 object into Session.Add();
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    ViewBag.succsess = "Thành công";
                    return Redirect(strUrl);
                }
                else
                {
                    return Redirect(strUrl);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}