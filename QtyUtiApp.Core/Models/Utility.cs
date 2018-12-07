using SQLite;
using System;

namespace QtyUtiApp.Core.Models
{
    [Table("utility")]
    public class Utility
    {
        [PrimaryKey, AutoIncrement, NotNull, Unique]
        public int Id { get; set; }
        public double GasQuantity { get; set; }
        public double ColdWaterQuantity { get; set; }
        public double HotWaterQuantity { get; set; }
        public DateTime Date { get; set; }

        public Utility()
        {
        }

        public Utility(double gasQuantity, double cWaterQuantity, double hWaterQuantity, DateTime date)
        {
            GasQuantity = gasQuantity;
            ColdWaterQuantity = cWaterQuantity;
            HotWaterQuantity = hWaterQuantity;
            Date = date;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Gas: {GasQuantity}, CWater: {ColdWaterQuantity}, HWater: {HotWaterQuantity}, {Date.ToShortDateString()}";
        }
    }
}
