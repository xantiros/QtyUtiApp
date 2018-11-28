using System;

namespace QtyUtiApp.Core.Models
{
    public class WaterHot : Utility
    {
        public WaterHot(int id, DateTime date, double quantity) : base(id, date, quantity)
        {
        }

        protected WaterHot()
        {
        }
    }
}
