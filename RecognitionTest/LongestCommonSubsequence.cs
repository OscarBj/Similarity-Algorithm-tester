using System;
using System.Collections.Generic;
using System.Text;

namespace RecognitionTest
{
    class LongestCommonSubsequence : RecognitionAlgorithm
    {
        public int score { get; set; }
        
        public String name { get; set; }

        public LongestCommonSubsequence(int min_score, String name)
        {
            this.score = min_score;
        }

        public int GetDistance(string str1, string str2)
        {
            throw new NotImplementedException();
        }
    }
}
