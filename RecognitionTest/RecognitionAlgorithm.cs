using System;
using System.Collections.Generic;
using System.Text;

namespace RecognitionTest
{
    interface RecognitionAlgorithm
    {
        String name { get; set; }

        int min_score { get; set; }
        
        int GetDistance(String str1, String str2);
    }
}
