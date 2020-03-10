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
            pass = hashPassword(user.password);
            try
            {
                Users us = _context.Users.Where(u => u.email == user.email && u.password == user.password).First();
                if (us != null)
                {
                    return RedirectToAction("Home", "Home", new { area = "" });
                }
      
            }catch(Exception ex)
            {

            }
            return RedirectToAction("Account", "Account", new { area = "" });
        }

        public String hashPassword(string pass)
        {

            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pass,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}