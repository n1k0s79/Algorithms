namespace Math
{
    public class Palindrome
    {
        /// <summary> Returns the palindrome number </summary>
        /// <remarks>Strategy:
        /// Divide by 10 and get the remainder. This gives me the last digit
        /// The last digit becomes the first. To do shift all the previous digits to the left (multiply by 10) and add the remainder.
        /// </remarks>
        public static int GetPalindrome(int n)
        {
            int ret = 0;

            while (n != 0)
            {
                int remainder = n % 10; 
                ret = ret * 10 + remainder;
                n /= 10;
            }

            return ret;
        }

        public static bool IsPalindrome(int n)
        {
            int p = GetPalindrome(n);
            return p == n;
        }
    }
}