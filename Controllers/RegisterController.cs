using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WaterMS.Models;
using WaterMS.Data;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace WaterMS.Controllers
{
    public class RegisterController : Controller
    {
        private LibraryContext _context;

        public RegisterController(LibraryContext context)
        {
            _context = context;
        }
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterUser(Users user)
        {
           

            if (user.password == user.ConfirmPassword)
            {
                string pass = Base64Encode(user.password);
                    user.password = pass;
                    user.date_created = DateTime.Now;
                    user.date_deleted = DateTime.Now;
                    user.created_by = user.first_name;
                    user.status = "Active";
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return RedirectToAction("Account", "Account", new { area = "" });
               
            }
            return RedirectToAction("Register", "Register", new { area = "" });

        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}