﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Economy.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult CreateNewProduct()
        {
            return View();
        }
    }
}