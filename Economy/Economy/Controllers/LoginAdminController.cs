using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Economy.Models;
using Economy.Common.Admin;

namespace Economy.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: LoginAdmin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminAccModel ad)
        {
            if(ModelState.IsValid)
            {
                if(CheckAdminAcc(ad.AdminEmail, ad.AdminPassword) == true)
                {
                    var adminSession = new AdminLogin();
                    var _ad = CheckAdminAcc(ad.AdminEmail);
                    adminSession.IDAdmin = _ad.IDAdmin;
                    adminSession.AdminName = _ad.AdminName;

                    Session.Add(Economy.Common.Admin.CommonConstant.ADMIN_SESSION, adminSession);

                    return RedirectToAction("HomeAdmin","HomeAdmin");
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

        public bool CheckAdminAcc(string email, string pass)
        {
            EconomyDbContext db = null;
            db = new EconomyDbContext();

            var admin = db.Admins.FirstOrDefault(x => x.AdminEmail == email && x.AdminPassword == pass);
            if(admin != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Admin CheckAdminAcc(string email)
        {
            EconomyDbContext db = null;
            db = new EconomyDbContext();

            var _ad = db.Admins.FirstOrDefault(x => x.AdminEmail == email);
            return _ad;
        }

        //Log out AdminAccount
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }
}