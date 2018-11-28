using System;

namespace QtyUtiApp.Core.Models
{
    public class Gas : Utility
    {
        public Gas(int id, DateTime date, double quantity) : base(id, date, quantity)
        {
        }

        protected Gas()
        {
        }
    }
}
