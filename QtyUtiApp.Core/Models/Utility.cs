using System;

namespace QtyUtiApp.Core.Models
{
    public class Utility
    {
        public int Id { get; internal set; }
        public double Quantity { get; internal set; }
        public DateTime Date { get; internal set; }

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
