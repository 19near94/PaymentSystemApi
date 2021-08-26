using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Application.Utils
{
    public class RandomDate
    {
        private Random gen = new Random();

        /// <summary>
        /// Helper to get random date from 2020-1-1 onwards.
        /// </summary>
        /// <returns>The random generated date.</returns>
        public DateTime DateRandom()
        {
            DateTime start = new DateTime(2020, 1, 1);
            int range = (DateTime.UtcNow - start).Days;
            return start.AddDays(gen.Next(range));
        }

    }
}
