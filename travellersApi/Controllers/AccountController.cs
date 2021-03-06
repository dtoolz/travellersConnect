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
using travellersApi.Interfaces;

namespace travellersApi.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }
        [HttpPost("register")]
        public async Task<ActionResult<TravellerDto>> Register(RegisterDto registerDto){
           if( await TravellerExists(registerDto.Username)) return BadRequest("Username is Taken!");

            using var hmac = new HMACSHA512();
            var traveller = new AppTraveller {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
            _context.Travellers.Add(traveller);
            await _context.SaveChangesAsync();
            return new TravellerDto{
                Username = traveller.UserName,
                Token = _tokenService.CreateToken(traveller)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<TravellerDto>> Login (LoginDto loginDto){
           var traveller = await _context.Travellers.SingleOrDefaultAsync(result => result.UserName == loginDto.Username);
           if ( traveller == null ) return Unauthorized("Username is invalid!");

           using var hmac = new HMACSHA512(traveller.PasswordSalt);
           var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

           for ( int i = 0; i < computedHash.Length; i++ ) {
                if ( computedHash[i] != traveller.PasswordHash[i]) return Unauthorized("Invalid Password");
           }
           return new TravellerDto{
                Username = traveller.UserName,
                Token = _tokenService.CreateToken(traveller)
            };
        }

        private async Task<bool> TravellerExists(string username){
            return await _context.Travellers.AnyAsync(result => result.UserName == username.ToLower());
        }
    }
}