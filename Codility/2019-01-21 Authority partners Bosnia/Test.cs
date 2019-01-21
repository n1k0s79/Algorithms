//using System;
//using System.Collections.Generic;

//namespace ConsoleApp10
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World!");
//            int[] A = { 1, 2, -5, 5, -12 };
//            Array.Sort(A);

//            var kot = solution(A);
//        }

//        public static int solution(int[] A)
//        {
//            var nar = new NegArray(A);

//            return 0;
//        }

//        private class NegArray
//        {
//            private int offset;
//            private bool[] arr;

//            private static void minmax(int[] A, out int min, out int max)
//            {
//                min = int.MaxValue;
//                max = int.MinValue;

//                for (int i = 0; i < A.Length; i++)
//                {
//                    if (A[i] > max) max = A[i];
//                    if (A[i] < min) min = A[i];
//                }
//            }

//            public NegArray(int[] A)
//            {
//                int min = 0;
//                int max = 0;
//                minmax(A, out min, out max);
//                int l = max - min;
//                if (min < 0) l = max - min;
//                l++;
//                arr = new bool[l];
//                offset = min;
//                for (int i = 0; i < A.Length; i++)
//                {
//                    this[A[i]] = true;
//                }
//            }

//            public bool this[int index]
//            {
//                get
//                {
//                    return arr[index - offset];
//                }
//                set
//                {
//                    var offsetIndex = index - offset;
//                    arr[offsetIndex] = value;
//                }
//            }
//        }
//    }
//}
