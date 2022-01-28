using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using travellersApi.Data;
using travellersApi.Entities;

namespace travellersApi.Controllers
{

    public class TravellersController : BaseApiController
    {
        private readonly DataContext _context;
        public TravellersController(DataContext context)
        {
            _context = context;

        }
        [HttpGet]
        [AllowAnonymous]
        public  async  Task<ActionResult<IEnumerable<AppTraveller>>> GetTravellers(){
           return await _context.Travellers.ToListAsync();

        }

         [HttpGet("{id}")]
         [Authorize]
        public async  Task<ActionResult<AppTraveller>> GetTraveller(int id){
            return await _context.Travellers.FindAsync(id);
            
           // return traveller;
        }
    }
}