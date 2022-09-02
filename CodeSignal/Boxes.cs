using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeSignal
{
    [TestClass]
    public class Boxes
    {
        [TestMethod]
        public void Test()
        {
            //var length = new int[] { 1, 2, 3 };
            //var width = new int[] { 1, 2, 3 };
            //var height= new int[] { 1, 2, 3 };
            //var length = new int[] { 1, 1 };
            //var width = new int[] { 1, 1 };
            //var height = new int[] { 1, 1 };
            var length = new int[] { 9980, 9984, 9981 };
            var width = new int[] { 9980, 9984, 9983 };
            var height = new int[] { 9981, 9984, 9982 };
            var k = solution(length, width, height);
        }

        // You are given n rectangular boxes, the ith box has the length lengthi, the width widthi and the height heighti.
        // Your task is to check if it is possible to pack all boxes into one so that inside each box there is no more than one another box (which, in turn, can contain at most one another box, and so on). More formally, your task is to check whether there is such sequence of n different numbers pi(1 ≤ pi ≤ n) that for each 1 ≤ i<n the box number pi can be put into the box number pi+1.
        // A box can be put into another box if all sides of the first one are less than the respective ones of the second one.You can rotate each box as you wish, i.e.you can swap its length, width and height if necessary.

        bool solution(int[] length, int[] width, int[] height)
        {
            var boxes = Box.FromArrays(length, width, height).OrderBy(b => b.OrderString).ToList();

            for (var i = 0; i < boxes.Count - 1; i++)
            {
                if (!boxes[i].FitsInside(boxes[i + 1])) return false;
            }
            return true;
        }

        class Box
        {
            private int[] dimensions;

            public static IEnumerable<Box> FromArrays(int[] length, int[] width, int[] height)
            {
                for (int i = 0; i < length.Length; i++) 
                { 
                    yield return new Box(length[i], width[i], height[i]);
                }
            }

            public Box(params int[] dimensions)
            {
                this.dimensions = dimensions.ToList().OrderBy(x => x).ToArray();
            }
            
            public bool FitsInside(Box other)
            {
                for(int i = 0; i < dimensions.Length; i++)
                {
                    if (dimensions[i] >= other.dimensions[i]) return false;
                }
                return true;
            }

            public string OrderString => dimensions.Aggregate(string.Empty, (a, b) => a.ToString() + b.ToString());
        }
    }
}
