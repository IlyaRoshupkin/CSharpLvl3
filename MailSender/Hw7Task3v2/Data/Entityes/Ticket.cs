using System;
using System.Collections.Generic;
using System.Text;

namespace Hw7Task3v2.Data.Entityes
{
    public abstract class Entity
    {
        public int id { get; set; }
        public string Time { get; set; }
    }

    public class Ticket:Entity
    {
        public string CustomerName { get; set; }
        public string Place { get; set; }
        public int Price { get; set; }

        public virtual MovieSession MovieSession { get; set; }
    }
    public class MovieSession:Entity
    {
        public string Description { get; set; }
        public int NumberOfPlaces { get; set; }
        public string MovieName { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
