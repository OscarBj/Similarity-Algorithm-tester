using System;
using System.Collections.Generic;
using System.Text;

namespace RecognitionTest
{
    class DiceCoefficient : RecognitionAlgorithm
    {
        public int score { get; set; } // In chars

        private int maxDist { get; set; } // In % 

        private HashSet<string> setA;
        private HashSet<string> setB;

        public String name { get; set; }

        public DiceCoefficient(int score, int maxDist, String name)
        {
            this.score = score;
            this.maxDist= maxDist;
            this.name = name;
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

            return (int) ((strA.Length*2) * (2.0 * intersection.Count) / (setA.Count + setB.Count));
        }
        
    }
}
