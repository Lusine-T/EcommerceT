using System;

namespace MyStringsWithTesting
{
    public static class StringAnalyzer
    {
        // 1️⃣ Counting the maximum number of unequal consecutive characters
        public static int MaxUnequalConsecutiveChars(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            int max = 1;
            int current = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != input[i - 1])
                {
                    current++;
                    max = Math.Max(max, current);
                }
                else
                {
                    current = 1;
                }
            }

            return max;
        }

        // 2️⃣ Maximum number of consecutive identical Latin letters
        public static int MaxConsecutiveIdenticalLatinLetters(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            int max = 0;
            int current = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]) && IsLatinLetter(input[i]))
                {
                    if (i > 0 && input[i] == input[i - 1])
                    {
                        current++;
                    }
                    else
                    {
                        current = 1;
                    }

                    max = Math.Max(max, current);
                }
                else
                {
                    current = 0;
                }
            }

            return max;
        }

        // 3️⃣ Maximum number of consecutive identical digits
        public static int MaxConsecutiveIdenticalDigits(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            int max = 0;
            int current = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    if (i > 0 && input[i] == input[i - 1])
                    {
                        current++;
                    }
                    else
                    {
                        current = 1;
                    }

                    max = Math.Max(max, current);
                }
                else
                {
                    current = 0;
                }
            }

            return max;
        }

        private static bool IsLatinLetter(char c)
        {
            return c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z';
        }
    }
}