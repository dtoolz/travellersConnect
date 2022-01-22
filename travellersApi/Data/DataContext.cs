using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using travellersApi.Entities;

namespace travellersApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppTraveller> Travellers { get; set; } //targetting the class to create a database for, in this case is AppTraveller and naming the database Travellers
    }
}