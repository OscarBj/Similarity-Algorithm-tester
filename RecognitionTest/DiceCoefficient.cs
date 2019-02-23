using System;
using System.Collections.Generic;
using System.Text;

namespace RecognitionTest
{
    class DiceCoefficient : RecognitionAlgorithm
    {
        public int min_score { get; set; }

        private HashSet<string> setA;
        private HashSet<string> setB;

        public String name { get; set; }

        public DiceCoefficient(int min_score, String name)
        {
            this.min_score = min_score;
            setA = new HashSet<string>();
            setB = new HashSet<string>();

        }

        public int GetDistance(string strA, string strB)
        {
   
            for (int i = 0; i < strA.Length - 1; ++i)
                setA.Add(strA.Substring(i, 2));

            for (int i = 0; i < strB.Length - 1; ++i)
                setB.Add(strB.Substring(i, 2));

            HashSet<string> intersection = new HashSet<string>(setA);
            intersection.IntersectWith(setB);

            return (2.0 * intersection.Count) / (setA.Count + setB.Count);
        }
    }
}
