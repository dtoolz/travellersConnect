using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using travellersApi.Data;
using travellersApi.DTOs;
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
        public async Task<ActionResult<AppTraveller>> Register(RegisterDto registerDto){
           if( await TravellerExists(registerDto.Username)) return BadRequest("Username is Taken!");

            using var hmac = new HMACSHA512();
            var traveller = new AppTraveller {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
            _context.Travellers.Add(traveller);
            await _context.SaveChangesAsync();
            return traveller;
        }
        private async Task<bool> TravellerExists(string username){
            return await _context.Travellers.AnyAsync(result => result.UserName == username.ToLower());
        }
    }
}