using System;
using System.Collections.Generic;
using System.Text;

namespace RecognitionTest
{
    class LongestCommonSubsequence : RecognitionAlgorithm
    {
        public int min_score { get; set; }

        public String name { get; set; }

        public LongestCommonSubsequence(int min_score, String name)
        {
            this.min_score = min_score;
        }

        public int GetDistance(string str1, string str2)
        {
            throw new NotImplementedException();
        }
    }
}
