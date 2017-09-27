namespace Arrays
{
    /// <summary> Rotates an array (i.e. moves all its elements to the left or the right) </summary>
    public class Rotator
    {
        public enum Directions
        {
            Left = 1,
            Right = -1
        }

        /// <summary> Rotates all the elements of the array to the left </summary>
        /// <remarks> see Rotator_Attempts for how this solution was reached </remarks>
        public static void Rotate_Old<T>(T[] a, int rotations = 1, Directions direction = Directions.Left)
        {
            if (a == null || a.Length <= 1) return;

            int qr = rotations % a.Length; // allow rotations > array length without wasting time
            if (qr == 0) return;

            int indexToReplace = 0;
            T temp = a[indexToReplace];  // save the first item because it will be replaced
            
            for (int i = 0; i < a.Length; i++)  // for all items in the array
            {
                int indexToTakeFrom = indexToReplace + (int)direction * qr;     // hop to the left or right to find the array element to take
                if (indexToTakeFrom >= a.Length) indexToTakeFrom -= a.Length;   // The hop might have taken me out of bounds...
                if (indexToTakeFrom < 0) indexToTakeFrom += a.Length;           // ...so ge back into bounds
                a[indexToReplace] = a[indexToTakeFrom];                         // Put the element in its final position (the previous element is overwritten)
                
                if (i != a.Length - 1)      
                    indexToReplace = indexToTakeFrom;   // Now go to the element that I used to replace the original.
                else
                    a[indexToReplace] = temp;   // in the last iteration replace with the first saved element
            }
        }

        /// <summary> Rotates all the elements of the array to the left </summary>
        /// <remarks> see Rotator_Attempts for how this solution was reached </remarks>
        public static void Rotate<T>(T[] a, int rotations = 1, Directions direction = Directions.Left)
        {
            if (a == null || a.Length <= 1) return;

            int qr = rotations % a.Length;                              // allow rotations > array length without wasting time
            if (qr == 0) return;

            rotations = rotations % a.Length;                           // so that I do not waste time
            int replacements = 0;

            int i = 0;
            while (replacements < a.Length)
            {
                int replace = i;
                T temp = a[replace];                                    // store the first element that is going to be replaced [1]
                while (true)
                {
                    int takeFrom = replace + (int)direction * rotations;    // hop to get the element to replace with
                    if (takeFrom >= a.Length) takeFrom -= a.Length;     // if I hop outside the array correct it
                    if (takeFrom < 0) takeFrom += a.Length;             // if I hop outside the array correct it
                    if (takeFrom == i) break;                           // but if I hopped back to the start then STOP
                    a[replace] = a[takeFrom];
                    replacements++;
                    replace = takeFrom;                                 // get ready to replace the next element at the hopped index                    
                }
                a[replace] = temp;                                      // for the last replacement use the element that I stored in the beginning [1]
                replacements++;
                i++;
            }
        }

        #region Other ways

        public static void LeftRotateR(int[] a, int d)
        {
            Util.Reverse(a, 0, d-1);
            Util.Reverse(a, d, a.Length - 1);
            Util.Reverse(a, 0, a.Length - 1);
        }

        public static void RightRotateR(int[] a, int d)
        {            
            if (a == null || a.Length == 1) return;
            d = d % a.Length;
            if (d == 0) return;

            Util.Reverse(a);
            Util.Reverse(a, d, a.Length - 1);
            Util.Reverse(a, 0, d - 1);
        }

        #endregion
    }
}