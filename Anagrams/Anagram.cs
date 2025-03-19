namespace Anagrams
{
    /// <summary>
    /// Provides methods to count pairs of substrings that are anagrams of one another.
    /// </summary>
   public abstract class Anagram
    {
        /// <summary>
        /// Determines how many anagrammatic substring pairs there are in a given string.
        /// </summary>
        /// <param name="s">Input string .</param>
        /// <returns>The count of anagrammatic pairs.</returns>
        public static int GetAnagrams(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentException("Input string cannot be null or empty.");
            }

            if (s.Length < 3 || s.Length > 100)
            {
                throw new ArgumentException("Input string length must be between 3 and 100 characters.");
            }

            if (s.Any(c => c < 'a' || c > 'z'))
            {
                throw new ArgumentException("Input string must contain only lowercase letters.");
            }

            var pairCount = 0;
            for (var len = 1; len <= s.Length; len++)
            {
                pairCount += CountAnagramPairs(s, len);
            }
            return pairCount;
        }
        
        private static int CountAnagramPairs(string s, int length)
        {
            var pairCount = 0;
            var maxGroups = s.Length - length + 1;
            var signatures = new int[maxGroups][];

            for (var i = 0; i < maxGroups; i++)
            {
                signatures[i] = GetSignature(s, i, length);
            }

            for (var i = 0; i < maxGroups - 1; i++)
            {
                for (var j = i + 1; j < maxGroups; j++)
                {
                    if (AreSignaturesEqual(signatures[i], signatures[j]))
                    {
                        pairCount++;
                    }
                }
            }
            return pairCount;
        }
        
        private static int[] GetSignature(string s, int start, int length)
        {
            var frequency = new int[26];
            for (var i = 0; i < length; i++)
            {
                frequency[s[start + i] - 'a']++;
            }
            return frequency;
        }

        private static bool AreSignaturesEqual(int[] sig1, int[] sig2)
        {
            for (var i = 0; i < 26; i++)
            {
                if (sig1[i] != sig2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
    
}
