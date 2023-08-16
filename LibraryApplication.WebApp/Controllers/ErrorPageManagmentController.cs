using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.WebApp.Controllers
{
    public class ErrorPageManagmentController : Controller
    {
        public IActionResult ErrorPage(int? code)
        {
            switch (code)
            {
                case 400:
                    return View("400");
                case 404:
                    return View("404");
                case 500:
                    return View("500");
            }

            return View();
        }
    }
}
