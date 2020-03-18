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
    public class AccountController : Controller
    {


        private LibraryContext _context;

        public AccountController(LibraryContext context)
        {
            _context = context;
        }
        public IActionResult Account()
        {
            return View();
        }

        public IActionResult SignIn(Users user)
        {
            string pass;
            pass = Base64Encode(user.password);
            try
            {
                Users us = _context.Users.Where(u => u.email == user.email && u.password == pass).First();
                if (us != null)
                {
                    return RedirectToAction("Home", "Home", new { area = "" });
                }
      
            }catch(Exception ex)
            {

            }
            return RedirectToAction("Account", "Account", new { area = "" });
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}