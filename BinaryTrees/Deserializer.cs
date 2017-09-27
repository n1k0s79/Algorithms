using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class Deserializer
    {
        /// <summary>
        /// Returns a binary tree from a string that forms a pyramid:
        ///    3
        ///   7 4
        ///  2 4 6
        /// 8 5 9 3
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public static Node FromPyramidWithDuplicates(string pyramid)
        {
            Node ret = null;
            var lines = pyramid.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var previousNodes = new List<Node>();
            foreach(var line in lines)
            {                
                var items = line.Split(' ');
                var addedNodes = new List<Node>();
                foreach(var item in items)
                {
                    var node = new Node(int.Parse(item));
                    addedNodes.Add(node);
                }

                if (addedNodes.Count == 1) ret = addedNodes[0]; // return the first node
                if (previousNodes.Count > 0)
                {
                    for(int i=0; i< previousNodes.Count; i++)
                    {
                        previousNodes[i].left = addedNodes[i];
                        previousNodes[i].right = addedNodes[i+1];
                    }
                }

                previousNodes.Clear();
                previousNodes.AddRange(addedNodes.ToArray());
            }

            return ret;
        }
    }
}
