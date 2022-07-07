using System;

namespace LookingForLettersRecursively
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "It is just a sample for test and see the result!";
            int result = GetLettersCount(str, new char[] { 'a', 'e' }, 2, 20, 7);
            Console.WriteLine(result);
        }

        public static int GetLettersCount(string str, char[] chars, int startIndex, int endIndex, int limit)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (startIndex > endIndex || startIndex > str.Length || startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (endIndex > str.Length || endIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex));
            }

            if (limit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(limit));
            }

            return GetConcurrences(str, chars, startIndex, endIndex, limit);
        }

        public static int GetChar(string str, char ch, int index, int endIndex, int count = 0)
        {
            if (index < str?.Length && index <= endIndex)
            {
                if (str[index] == ch)
                {
                    count++;
                }

                index++;
                return GetChar(str, ch, index, endIndex, count);
            }

            return count;
        }

        public static int GetConcurrences(string str, char[] chars, int startIndex = 0, int endIndex = int.MaxValue, int limit = int.MaxValue, int index = 0, int numberOfConcurrences = 0)
        {
            if (index < chars?.Length)
            {
                numberOfConcurrences += GetChar(str, chars[index], startIndex, endIndex);
                index++;
                return GetConcurrences(str, chars, startIndex, endIndex, limit, index, numberOfConcurrences);
            }

            if (numberOfConcurrences > limit)
            {
                return limit;
            }

            return numberOfConcurrences;
        }
    }
}
