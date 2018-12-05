using System;

namespace QtyUtiApp.Core.Models
{
    public class Gas
    {
        public int Id { get; private set; }
        public double Quantity { get; private set; }
        public DateTime Date { get; private set; }

        public Gas(int id, double quantity, DateTime date)
        {
            Id = id;
            Quantity = quantity;
            Date = date;
        }

        protected Gas()
        {
        }
    }
}
