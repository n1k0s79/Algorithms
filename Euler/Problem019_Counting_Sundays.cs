using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Euler
{
    //You are given the following information, but you may prefer to do some research for yourself.

    //1 Jan 1900 was a Monday.
    //Thirty days has September,
    //April, June and November.
    //All the rest have thirty-one,
    //Saving February alone,
    //Which has twenty-eight, rain or shine.
    //And on leap years, twenty-nine.
    //A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

    //How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?

    [TestClass]
    public class Problem019_Counting_Sundays
    {
        [TestMethod]
        public void Compare()
        {
            var d1 = GetCalendarDays();
            var d2 = GetDivisionDays();

            Assert.AreEqual(171, d1.Count);
            Assert.AreEqual(171, d2.Count);

            foreach (var kvp in d1)
            {
                Assert.AreEqual(kvp.Value, d2[kvp.Key]);
            }
        }

        /// <summary> Find the Sudays using the system's calendar and checking each day</summary>
        public Dictionary<int, string> GetCalendarDays()
        {
            var ret = new Dictionary<int, string>();
            int dayCount = 0;
            var d = new DateTime(1901, 1, 1);
            while (true)
            {
                dayCount++;
                if (d.DayOfWeek == DayOfWeek.Sunday && d.Day == 1)
                {
                    ret.Add(dayCount, d.ToString("d/M/yyyy") + " " + d.DayOfWeek.ToString());
                }
                d = d.AddDays(1);
                if (d.Year == 2001) break;
            }

            return ret;
        }

        /// <summary> Find the Sundays with divisions </summary>
        private Dictionary<int, string> GetDivisionDays()
        {
            var ret = new Dictionary<int, string>();
            var monthDays = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int sundays = 0;
            int d = 1;
            for (int year = 1901; year <= 2000; year++)
            {
                bool isLeap = year % 400 == 0 || (year % 4 == 0 && year % 100 != 0);
                for (int month = 1; month <= 12; month++)
                {
                    // 1/1/1900 was a Monday 
                    // 1900 was not leap year (365 days, 52 whole weeks (52*7=364) plus one more day)
                    // so 1/1/1901 is a Tuesday
                    // T W T F S S M T W  T  F  S  S M  T  W  T  F  S  S  M  T  W  T  F  S  S  M  T  W
                    // 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30
                    // therefore day n will be a Sunday if n % 7 == 6

                    bool isSunday = d % 7 == 6;
                    if (isSunday)
                    {
                        ret.Add(d, "1/" + month + "/" + year.ToString() + " Sunday");
                        sundays++;
                    }
                    int daysOfMonth = monthDays[month - 1];
                    if (isLeap && month == 2) daysOfMonth++;
                    d += daysOfMonth;
                }
            }
            return ret;
        }
    }
}