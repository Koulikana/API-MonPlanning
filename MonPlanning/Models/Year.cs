using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonPlanning.Models
{
    public class Year
    {
        readonly int year;
        readonly bool bissextile;

        public Year(int _year)
        {
            year = _year;
            if (year % 4 == 0)
            {
                bissextile = true;
            }
            else
            {
                bissextile = false;
            }
        }

        public int Year_ => year;
        public bool Bissextile => bissextile;

    }
}
