using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class Year
    {
        int year;
        public Year(int year)
        {
            this.year = year;
        }

        //A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
        public bool IsLeap
        {
            get
            {
                if (year % 400 == 0) return true;
                if (year % 100 == 0) return false;
                if (year % 4 == 0) return true;
                return false;
            }
        }

        public int NumberOfDays
        {
            get
            {
                return IsLeap ? 366 : 365;
            }
        }

        public static int CountLeapYearsInclusive(int year1, int year2)
        {
            int ret = 0;
            for (int i = year1; i <= year2; i++)
            {
                var h = new Year(i);
                if (h.IsLeap) ret++;
            }
            return ret;
        }

        public static int GetNumberOfDaysBetweenInclusive(int year1, int year2)
        {
            var a = (year2 - year1 + 1) * 365;
            var b = CountLeapYearsInclusive(year1, year2);
            return a + b;
        }
    }
}