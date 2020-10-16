using Hw7Task3v2.Data.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hw7Task3v2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string connection_str = @"Data Source=(LocalDB)\MSSQLLocalDB;
                        Initial Catalog=Tickets.DB;Integrated Security=True";
            
            using (var db = new TicketsDB(new DbContextOptionsBuilder<TicketsDB>()
                .UseSqlServer(connection_str).Options))
            {
                await db.Database.EnsureCreatedAsync();
                var tickets_count = await db.Tickets.CountAsync();
                Console.WriteLine("Number of tickets - {0}", tickets_count);
            }
            using (var db = new TicketsDB(new DbContextOptionsBuilder<TicketsDB>()
                .UseSqlServer(connection_str).Options))
            {
                var k = 0;
                if(await db.Tickets.CountAsync()==0)
                for (var i = 0; i < 10; i++)
                {
                    var movie_session = new MovieSession
                    {
                        MovieName = $"Fast&Furious {i}",
                        Description = "The new {i} part. Diesel and Johnson are together again.",
                        NumberOfPlaces = 100 - (i * 3),
                        Tickets = new List<Ticket>(),
                        Time = $"{i + 12}:{i * 5 + 10}"
                    };
                    for(var j = 0; j < 10; j++)
                    {
                        var ticket = new Ticket
                        {
                            CustomerName = $"Customer {k}",
                            Place = $"{k + 1}-{j + i + 1}",
                            Price = 300 + j * 10
                        };
                        k++;
                        movie_session.Tickets.Add(ticket);
                    }
                await db.MovieSessions.AddAsync(movie_session);
                }
                await db.SaveChangesAsync();
            }
        }
    }
}
