﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class UserDao
    {
        EconomyDbContext db = new EconomyDbContext();
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
    }
}
