using SQLite;
using System;

namespace QtyUtiApp.Core.Models
{
    [Table("gas")]
    public class Gas
    {
        [PrimaryKey, AutoIncrement, NotNull, Unique]
        public int Id { get; set; }
        public double Quantity { get; set; }
        public DateTime Date { get; set; }

        public Gas(int id, double quantity, DateTime date)
        {
            Id = id;
            Quantity = quantity;
            Date = date;
        }
        public Gas(double quantity, DateTime date)
        {
            Quantity = quantity;
            Date = date;
        }
        public Gas()
        {
        }
        public override string ToString()
        {
            return $"Id: {Id}, Qty: {Quantity}, {Date.ToShortDateString()}";
        }
    }
}
