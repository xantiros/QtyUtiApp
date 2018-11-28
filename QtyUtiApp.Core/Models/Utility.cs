using System;

namespace QtyUtiApp.Core.Models
{
    public class Utility
    {
        public int Id { get; private set; } 
        public DateTime Date { get; private set; }
        public double Quantity { get; private set; }

        protected Utility()
        {
        }

        public Utility(int id, DateTime date, double quantity)
        {
            Id = id;
            Date = date;
            Quantity = quantity;
        }
    }
}
