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