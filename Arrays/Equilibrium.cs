namespace Arrays
{
    /// <summary>
    /// Equilibrium index of an array
    /// Equilibrium index of an array is an index such that the sum of elements at lower indexes is equal to the sum of elements at higher indexes. 
    /// 
    /// For example, in an arrya A:
    /// A[0] = -7, A[1] = 1, A[2] = 5, A[3] = 2, A[4] = -4, A[5] = 3, A[6]=0
    /// 
    /// 3 is an equilibrium index, because: 
    /// A[0] + A[1] + A[2] = A[4] + A[5] + A[6]
    /// </summary>
    public class Equilibirium
    {

        public static int FindEquilibrium(int[] array, AlgorithmComplexity comp = AlgorithmComplexity.On)
        {
            if (comp == AlgorithmComplexity.On) return FindEquilibrium_On(array);
            return FindEquilibrium_On2(array);
        }

        public enum AlgorithmComplexity
        {
            On2,
            On
        }

        /// <summary> Finds the equilibrium index of an array </summary>
        /// <remarks> 
        /// Time complexity O(n^2). 2-level nested loops. 
        /// Space complexity O(1)
        /// </remarks>
        private static int FindEquilibrium_On2(int[] array)
        {
            // Check for indexes one by one until an equilibrium index is found
            for (int i = 0; i < array.Length; ++i)
            {
                int j = 0;

                long leftsum = 0, rightsum = 0;

                // get left sum
                for (j = 0; j < i; j++) leftsum += array[j];

                // get right sum
                for (j = i + 1; j < array.Length; j++) rightsum += array[j];

                // if leftsum and rightsum are same, then we are done
                if (leftsum == rightsum) return i;
            }

            // return -1 if no equilibrium index is found
            return -1;
        }

        /// <summary> Finds the equilibrium index of an array </summary>
        /// <remarks> Time complexity O(n). No nested loops. 
        /// Space complexity O(1) 
        /// Refatcored from the above function.
        /// The refactoring was based on the observation that subtracting each array element step-by-step
        /// starting from the left I get the right sum. So I can remove the nested loop.
        /// </remarks>
        private static int FindEquilibrium_On(int[] array)
        {
            long sum = 0; // initialize sum of whole array
            long leftsum = 0; // initialize leftsum

            // Find sum of the whole array
            for (int i = 0; i < array.Length; ++i) sum += array[i];

            for (int i = 0; i < array.Length; ++i)
            {
                sum -= array[i]; // sum is now right sum for index i

                if (leftsum == sum) return i;

                leftsum += array[i];
            }

            // If no equilibrium index found, then return -1
            return -1;
        }
    }
}
