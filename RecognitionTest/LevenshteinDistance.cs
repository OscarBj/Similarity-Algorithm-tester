using System;
using System.Collections.Generic;
using System.Text;

namespace RecognitionTest
{
    // this algorithm should be edited so that it breaks off when the match % exceeds the specified score
    // d[,] needs the dimensions for beeing able to iterate the strings, not for storing elements
    class LevenshteinDistance : RecognitionAlgorithm
    {

        public int score { get; set; }

        private int maxDist { get; set; }

        public String name { get; set; }

        public LevenshteinDistance(int min_score, int maxDist, String name)
        {
            this.score = min_score;
            this.maxDist = maxDist;
            this.name = name;
        }

        public int GetDistance(string src, string dest)
        {
            int[,] d = new int[src.Length + 1, dest.Length + 1];
            int i, j, cost;
            char[] str1 = src.ToCharArray();
            char[] str2 = dest.ToCharArray();

            for (i = 0; i <= str1.Length; i++)
            {
                d[i, 0] = i;
            }
            for (j = 0; j <= str2.Length; j++)
            {
                d[0, j] = j;
            }
            for (i = 1; i <= str1.Length; i++)
            {
                for (j = 1; j <= str2.Length; j++)
                {
                   
                    if (str1[i - 1] == str2[j - 1])
                        cost = 0;
                    else
                        cost = 1;

                    d[i, j] =
                        Math.Min(
                            d[i - 1, j] + 1,              // Deletion
                            Math.Min(
                                d[i, j - 1] + 1,          // Insertion
                                d[i - 1, j - 1] + cost)); // Substitution

                    if ((i > 1) && (j > 1) && (str1[i - 1] ==
                        str2[j - 2]) && (str1[i - 2] == str2[j - 1]))
                    {
                        d[i, j] = Math.Min(d[i, j], d[i - 2, j - 2] + cost); // transposition
                    }
                    // checks the score (optimization)
                    if (d[str1.Length, str2.Length] > maxDist)
                    {
                        return d[str1.Length, str2.Length];
                    }
                }
            }
            return d[str1.Length, str2.Length];
        }
    }
}
