using Hw7Task3v2.Data.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hw7Task3v2.Data
{
    public class TicketsDBContextFactory:
        IDesignTimeDbContextFactory<TicketsDB>
    {
        public TicketsDB CreateDbContext(string[] args)
        {
            var optionsBuilder = 
                new DbContextOptionsBuilder<TicketsDB>();
            const string connection_str = @"Data Source=(LocalDB)\MSSQLLocalDB;
                        Initial Catalog=Tickets.DB;Integrated Security=True";

            optionsBuilder.UseSqlServer(connection_str);
            return new TicketsDB(optionsBuilder.Options);
        }
    }
}
