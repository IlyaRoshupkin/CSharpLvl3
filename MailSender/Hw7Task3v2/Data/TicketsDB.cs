using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hw7Task3v2.Data.Entityes
{
    public class TicketsDB:DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<MovieSession> MovieSessions { get; set; }

        public TicketsDB(DbContextOptions<TicketsDB> options) : base(options) { }
    }
}
