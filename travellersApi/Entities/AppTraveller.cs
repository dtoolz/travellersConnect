using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace travellersApi.Entities
{
    public class AppTraveller
    {
        public int Id { get; set; } //auto implemented prop, use Id
        public string UserName { get; set; } //auto implemented prop, use UserName
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}