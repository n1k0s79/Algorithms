using System.Collections.Generic;

namespace Math
{
    public class WordedNumber
    {
        private List<Group> groups;
        private string _text;

        public WordedNumber(long number)
        {
            groups = SplitToGroups(number);
            var l = new List<string>();
            foreach (var g in groups) l.Add(g.ToString());
            _text = string.Join(" ", l);
        }

        public override string ToString()
        {
            return _text;
        }

        private static List<Group> SplitToGroups(long number)
        {
            var ret = new List<Group>();
            int gClass = (int)Group.GClass.Units;
            while (number >= 1000)
            {
                var r = number % 1000;
                number = number / 1000;
                ret.Add(new Group((int)r, (Group.GClass)gClass));
                gClass++;
            }
            if (number > 0) ret.Add(new Group((int)number, (Group.GClass)gClass));
            ret.Reverse();
            return ret;
        }

        private class Group
        {
            public enum GClass
            {
                Units,
                Thousand,
                Million,
                Billion,
                Trillion,
                Quatrillion,
                Quintillion
            }

            int units = 0;
            int tens = 0;
            int hundreds = 0;

            GClass gclass;

            public Group(int n, GClass gclass)
            {
                hundreds = n / 100;
                n -= hundreds * 100;
                tens = n / 10;
                n -= tens * 10;
                units = n;
                this.gclass = gclass;
            }

            public override string ToString()
            {
                var l = new List<string>();
                if (this.hundreds > 0)
                {
                    l.Add(Hundreds(this.hundreds));
                    if (this.tens > 0 || this.units > 0) l.Add("and");
                }

                if (this.tens == 1 && this.units > 0)
                {
                    l.Add(Teens(10 + this.units));
                }
                else
                {
                    if (this.tens > 0) l.Add(Tens(this.tens));
                    if (this.units > 0) l.Add(Ones(this.units));
                }

                var c = ClassToString(gclass);
                if (!string.IsNullOrEmpty(c)) l.Add(c);
                return string.Join(" ", l);
            }

            private static string ClassToString(Group.GClass gclass)
            {
                switch (gclass)
                {
                    case GClass.Units:
                        return string.Empty;
                    case GClass.Thousand:
                        return "thousand";
                    case GClass.Million:
                        return "million";
                    case GClass.Billion:
                        return "billion";
                    case GClass.Trillion:
                        return "trillion";
                    case GClass.Quatrillion:
                        return "quatrillion";
                    case GClass.Quintillion:
                        return "quintillion";
                }

                return string.Empty;
            }

            private static string Ones(int number)
            {
                switch (number)
                {
                    case 1:
                        return "one";
                    case 2:
                        return "two";
                    case 3:
                        return "three";
                    case 4:
                        return "four";
                    case 5:
                        return "five";
                    case 6:
                        return "six";
                    case 7:
                        return "seven";
                    case 8:
                        return "eight";
                    case 9:
                        return "nine";
                }

                return string.Empty;
            }

            private static string Teens(int number)
            {
                switch (number)
                {
                    case 11:
                        return "eleven";
                    case 12:
                        return "twelve";
                    case 13:
                        return "thirteen";
                    case 14:
                        return "fourteen";
                    case 15:
                        return "fifteen";
                    case 16:
                        return "sixteen";
                    case 17:
                        return "seventeen";
                    case 18:
                        return "eighteen";
                    case 19:
                        return "nineteen";
                }

                return "";
            }

            private static string Tens(int number)
            {
                switch (number)
                {
                    case 1:
                        return "ten";
                    case 2:
                        return "twenty";
                    case 3:
                        return "thirty";
                    case 4:
                        return "forty";
                    case 5:
                        return "fifty";
                    case 6:
                        return "sixty";
                    case 7:
                        return "seventy";
                    case 8:
                        return "eighty";
                    case 9:
                        return "ninety";
                }

                return string.Empty;
            }

            private static string Hundreds(int number)
            {
                if (number > 0) return Ones(number) + " hundred";
                return string.Empty;
            }
        }
    }
}