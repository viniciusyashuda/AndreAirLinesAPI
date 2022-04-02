using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreAirLinesAPI.Model.Model;
using AndreAirLinesAPI.Model;
using AutoFixture;

namespace AndreAirLinesAPI.Data
{
    public class AndreAirLinesAPIContext : DbContext
    {
        public AndreAirLinesAPIContext (DbContextOptions<AndreAirLinesAPIContext> options)
            : base(options)
        {
        }

        public DbSet<AndreAirLinesAPI.Model.Model.Passenger> Passenger { get; set; }

        public DbSet<AndreAirLinesAPI.Model.Address> Address { get; set; }

        public DbSet<AndreAirLinesAPI.Model.Aircraft> Aircraft { get; set; }

        public DbSet<AndreAirLinesAPI.Model.Airport> Airport { get; set; }

        public DbSet<AndreAirLinesAPI.Model.Flight> Flight { get; set; }
    }
}
