namespace Arrays
{
    /// <summary> Rotates an array (i.e. moves all its elements to the left or the right) </summary>
    internal class Rotator_Attempts
    {
        // Let's start simple with an algorithm that rotates an array by one position to the left.
        // given the array   1 2 3 4 5
        // it should return  2 3 4 5 1

        private static int[] Attempt1_GetLeftRotatedByOne_SpaceComplexityUnacceptable(int[] a)
        {
            int[] ret = new int[a.Length];  // space complexity O(n)

            for (int index = 0; index < a.Length; index++)
            {
                int newIndex = index + 1;
                if (newIndex >= a.Length) newIndex -= a.Length; // when I reach the end of the array go back the beginning
                ret[newIndex] = a[index];
            }

            return ret;
        }
        
        // BUT! O(n) space complexity is not the best I can do. I have a gut feeling that I can use the same array
        // And in the cases where I need to have both the original and the rotated array I can easily keep a copy of the array
        // before I rotate it. So...
        
        // given the array   1 2 3 4 5
        // it should return  2 3 4 5 1

        private static void Attempt2_LeftRotateByOne_LastElementLost(int[] a)
        {
            for (int index = 0; index < a.Length; index++)
            {
                int newIndex = index + 1;
                if (newIndex >= a.Length) newIndex -= a.Length; // when I reach the end of the array go back the beginning
                a[index] = a[newIndex]; 
            }
            // ARGH! last element was lost!
        }

        // The last element was lost. But this is easy... Do not iterate all the elements.
        // Iterate all but the last. Put the first element at the end.

        private static void Attempt3_LeftRotateByOne_OnlyOneRotation(int[] a)
        {
            int temp = a[0];
            for (int index = 0; index < a.Length -1; index++)
            {
                int indexFrom = index + 1;
                if (indexFrom >= a.Length) indexFrom -= a.Length; // when I reach the end of the array go back the beginning
                a[index] = a[indexFrom];
            }

            a[a.Length-1] = temp;
        }

        // That's nice! It works. Of course it only works for one rotation and only to the left.
        // I also assume that the number of rotations will not be greater than the number of array elements.
        // What if I try to rotate to the right?
        
        // given  1 2 3 4 5
        // return 5 1 2 3 4

        private static void Attempt4_RightRotateByOne(int[] a)
        {
            int temp = a[a.Length -1];
            for (int index = a.Length - 1; index >= 0; index--)
            {
                int indexFrom = index - 1;
                if (indexFrom < 0) indexFrom += a.Length; // when I reach the start of the array go back the end
                a[index] = a[indexFrom];
            }

            a[0] = temp;
        }

        // For the left rotation I iterate from the start towards the end
        // But for the right rotate I iterate backwards. This could be a problem if I ever want to merge these two functions into one

        // But for the time being let's accept this and move on to crafting an algorithm that will allow for N rotations
        
        // Here's the first thing that comes to mind: Simply repeat the previous algorithm [rotations] time
        // It works but the complexity is N * rotations. Plus space complexity is now O(rotations) instead of O(1)
        private static void Attempt5_LeftRotateByN_TimeAndSpaceComplexityUnacceptable(int[] a, int rotations)
        {
            for (int i = 0; i < rotations; i++) Attempt3_LeftRotateByOne_OnlyOneRotation(a);
        }

        private static void Attempt6_LeftRotateByN_Failed_WouldRequireExtraSpaceComplexity(int[] a, int rotations)
        {
            // save the first element
            int temp = a[0];

            // I need a.Length iterations
            for (int index=0; index <a.Length; index++)
            {
                int indexTakeFrom = index + rotations;
                if (indexTakeFrom > a.Length) indexTakeFrom -= a.Length;
                a[index] = a[indexTakeFrom];
            }

            // oops! this won't work. For a simple 1 2 3 4 5 6 7 8 9 array, after 2 iterations I got:
            // 3 4 3 4 5 6 7 8 9. Notice that both 1 and 2 have been overwritten. 
            // If I keep going this way I will have to find a way to store <rotations> elements.
            // This would result in O(rotations) space complexity but I need to find an O(1) solution
        }

        // The above solution is worth trying a little bit more.
        // Since I want to have only 1 item overwritten every time I must overwrite only the element that I copied
        // to the new index. This can only be done if I overwrite the previous copied element (the one that exists twice in the array)
        // This results in hopping from one element to the other.
        // The hop length is equal to the number of rotations
        // The iteration variable cannot be named 'index' as it will not be index any more
        // I just need to iterate N times
        private static void Attempt7_LeftRotateByN_FirstElementLost(int[] a, int rotations)
        {
            int indexToReplace = 0;

            // I need a.Length iterations
            for (int i = 0; i < a.Length; i++)
            {
                int indexTakeFrom = indexToReplace + rotations;
                if (indexTakeFrom >= a.Length) indexTakeFrom -= a.Length;
                a[indexToReplace] = a[indexTakeFrom];
                indexToReplace = indexTakeFrom;
            }

            // for input 1 2 3 4 5 
            // returned  3 4 5 3 2
        }

        // the first element was lost!
        // Ah but that's easy to solve... I just forgot to save it

        public static void Attempt8_LeftRotateByN_Failed(int[] a, int rotations)
        {
            int indexToReplace = 0;
            int temp = a[indexToReplace];

            // I need a.Length iterations
            for (int i = 0; i < a.Length; i++)
            {
                int indexToTakeFrom = indexToReplace + rotations;
                if (indexToTakeFrom >= a.Length) indexToTakeFrom -= a.Length;
                a[indexToReplace] = a[indexToTakeFrom];
                if (i == a.Length - 1) a[indexToReplace] = temp;
                indexToReplace = indexToTakeFrom;
            }

            // This does not work because at the array boundaries the hops will replace already replaced elements
            // ANNOYINGLY this DOES work if a.Length % rotations != 0
            //      .-,(  ),-.    
            //   .-(          ).-.  
            //  (    ANNOYING!    )
            //   '-(          ).-' 
            //       '-.( ).-'     
            //                        
            // Yes, it was very annonying because it passed a lot of unit tests....
        }

        // ...so the priblem was in the break condition
        // I cannot simply use a for loop to do N repetitions, I have to check whether I reached the starting element.
        // If I reached it then I should stop.
        // In other words if the element with which to replace is the element from which I started then STOP
        // AND instead of replacing with the element that I got from hopping, replace with the element
        // that I stored temporarily as I started

        public static void Attempt9_LeftRotateByN(int[] a, int rotations)
        {
            rotations = rotations % a.Length;                           // so that I do not waste time

            for (int i = 0; i < rotations; i++)
            {                
                int replace = i;                
                int temp = a[replace];                                  // store the first element that is going to be replaced [1]
                while (true)
                {
                    int takeFrom = replace + rotations;                 // hop to get the element to replace with
                    if (takeFrom >= a.Length) takeFrom -= a.Length;     // if I hop outside the array correct it
                    if (takeFrom == i) break;                           // but if I hopped back to the start then STOP
                    a[replace] = a[takeFrom];
                    replace = takeFrom;                                 // get ready to replace the next element at the hopped index                    
                }
                a[replace] = temp;                                      // for the last replacement use the element that I stored in the beginning [1]
            }
        }

        // This works BUT only if rotations is LESS than some number WHICH number?
        // For array length 6 it works OK if rotations < 4.
        // For d = 4 the algorithm works OK up to some point. It constructs the array correctly and THEN it messes it up.
        // So the problem seems to be the number of repetitions
        // How many repetitions should I do?
        // If I stop at the right point then the array will be OK.
        // I can't figure out. (Of course the solution I found on the internet says do GreatestCommonDivisor(d,n) repetitions
        // But how do they reach this number? They do not explain. I need to have an explanation.
        // I DO however know that I need to do N replacements. 
        // So let's try counting the replacements and stop as soon as I reach N of them

        public static void Attempt10_LeftRotateByN(int[] a, int rotations)
        {
            if (a == null) return;
            if (a.Length <= 1) return;

            rotations = rotations % a.Length;                           // so that I do not waste time
            int replacements = 0;

            int i = 0;
            while(replacements < a.Length)
            {
                int replace = i;
                int temp = a[replace];                                  // store the first element that is going to be replaced [1]
                while (true)
                {
                    int takeFrom = replace + rotations;                 // hop to get the element to replace with
                    if (takeFrom >= a.Length) takeFrom -= a.Length;     // if I hop outside the array correct it
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
        
        // both directions
        public static void Attempt11_RightRotateByN(int[] a, int rotations)
        {
            if (a == null) return;
            if (a.Length <= 1) return;

            rotations = rotations % a.Length;                           // so that I do not waste time
            int replacements = 0;

            int i = 0;
            while (replacements < a.Length)
            {
                int replace = i;
                int temp = a[replace];                                  // store the first element that is going to be replaced [1]
                while (true)
                {
                    int takeFrom = replace - rotations;                 // hop to get the element to replace with
                    if (takeFrom >= a.Length) takeFrom -= a.Length;     // if I hop outside the array correct it
                    if (takeFrom < 0) takeFrom += a.Length;     // if I hop outside the array correct it
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

    }
}