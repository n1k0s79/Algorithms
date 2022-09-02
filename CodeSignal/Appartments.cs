using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeSignal
{
    [TestClass]
    public class Appartments
    {
        [TestMethod]
        public void Test()
        {
            var l = new AppListing() { description = "This luxurious studio apartment is in the heart of downtown." };
            var n = l.GetNrOfBedrooms();
        }


        class AppListing
        {
            public int id { get; set; }
            public string agent { get; set; }
            public string unit { get; set; }
            public string description { get; set; }
            public int num_bedrooms { get; set; }

            public int GetNrOfBedrooms()
            {
                var s = "studio";
                var b = "1-bedroom";
                var desc = description.ToLowerInvariant();
                if (!desc.Contains(s) && !desc.Contains(b)) return num_bedrooms;
                var si = desc.IndexOf(s);
                var bi = desc.IndexOf(b);

                var studioTypes = new string[] { "yoga", "dance", "art" };
                if (studioTypes.Any(t => desc.Contains(t)))
                {
                    var ti = studioTypes.Select(t => desc.IndexOf(t)).First();
                    if (ti > -1 && (ti < si || ti < bi)) return num_bedrooms;
                }
                if (desc.Contains(s)) return 0;
                if (desc.Contains(b)) return 1;
                return num_bedrooms;
            }
        }
    }
}
