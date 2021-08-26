using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Application.Utils
{
    public class RandomDate
    {
        private Random gen = new Random();
        public DateTime DateRandom()
        {
            DateTime start = new DateTime(2020, 1, 1);
            int range = (DateTime.UtcNow - start).Days;
            return start.AddDays(gen.Next(range));
        }

    }
}
