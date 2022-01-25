using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using travellersApi.Data;
using travellersApi.Entities;

namespace travellersApi.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("register")]
        public async Task<ActionResult<AppTraveller>> Register(string username, string password){
            using var hmac = new HMACSHA512();
            var traveller = new AppTraveller {
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };
            _context.Travellers.Add(traveller);
            await _context.SaveChangesAsync();
            return traveller;
        }
    }
}