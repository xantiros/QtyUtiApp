using System;

namespace QtyUtiApp.Core.Models
{
    public class Utility
    {
        public int Id { get; private set; }
        public double Quantity { get; private set; }
        public DateTime Date { get; private set; }

        protected Utility()
        {
        }

        public Utility(double quantity, DateTime date)
        {
            Quantity = quantity;
            Date = date;
        }
        public Utility(int id, double quantity, DateTime date)
        {
            Id = id;
            Quantity = quantity;
            Date = date;
        }
    }
}
