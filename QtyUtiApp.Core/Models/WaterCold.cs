using System;

namespace QtyUtiApp.Core.Models
{
    public class WaterCold : Utility
    {
        public WaterCold(int id, DateTime date, double quantity) : base(id, date, quantity)
        {
        }

        protected WaterCold()
        {
        }
    }
}
