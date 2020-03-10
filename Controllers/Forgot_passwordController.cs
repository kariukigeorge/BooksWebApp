using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WaterMS.Data;
using WaterMS.Models;

namespace WaterMS.Controllers
{
    public class Forgot_passwordController : Controller
    {


        private LibraryContext _context;

        public Forgot_passwordController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Forgot_password()
        {
            return View();
        }

        public IActionResult Retrieve_Password(Users user)
        {
            
            if (user.ConfirmPassword == user.password)
            {
                string pass;
                pass = hashPassword(user.password);
                Users s = _context.Users.Where(us => us.email == user.email).First();
                s.password = pass;
                _context.SaveChanges();
                return RedirectToAction("Account", "Account", new { area = "" });
            }

            return RedirectToAction("Forgot_password", "Forgot_password", new { area = "" });
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