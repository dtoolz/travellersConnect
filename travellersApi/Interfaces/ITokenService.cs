using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using travellersApi.Entities;

namespace travellersApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppTraveller traveller);
    }
}