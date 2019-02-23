using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RecognitionTest
{
    class Program
    {

        /* This program is used for testing string recognition algorithms performance
         * Following characteristics are measured:
         * - Time
         * 
         * 
         */

        /* Algorithms to be tested:
         * levenshtein distance
         * dice coefficient
         * longest common subsequence (LCS)
         * "word match" (from EIT project)
         */
        static void Main(string[] args)
        {
            Console.WriteLine($"Enter minimum similarity % between compared words");

            // user inputs required match score in % (90 -> 90%  which is converted into difference in characters)
            int requiredMatch = Convert.ToInt32(Console.ReadLine());
            
            List <string> words = testWords(); // make more generic

            string testWord = "uzeihzxuurprgub"; // hard coded test word for now

            int maxDist = (100 - requiredMatch) / (100 / testWord.Length); // % -> max distance

            List<RecognitionAlgorithm> algorithms = new List<RecognitionAlgorithm>();

            RecognitionAlgorithm levenshtein = new LevenshteinDistance(maxDist,"Levenshtein Distance");
            RecognitionAlgorithm dicecoeff = new DiceCoefficient(maxDist,"Dice Coefficient");
            RecognitionAlgorithm lcs = new LongestCommonSubsequence(maxDist,"LCS");

            algorithms.Add(levenshtein);
            algorithms.Add(dicecoeff);
            algorithms.Add(lcs);

            Stopwatch sw = new Stopwatch();
            foreach(RecognitionAlgorithm algorithm in algorithms)
            {
                sw.Start();
                compareWords(algorithm,words,testWord);
                sw.Stop();
                Console.WriteLine($"RESULTS:{algorithm.name} found match in: {sw.Elapsed}");
                sw.Reset();
            }

            //levenshteinTest(words, testWord, requiredMatch);
            
            Console.WriteLine("read new match % y/n");
            string yn = Console.ReadLine(); // awaits user input before exiting 
            if (yn.Equals("y")) Main(args);
        }

        private static void compareWords(RecognitionAlgorithm algorithm, List<string> words, string testWord)
        {// TODO: make backup mechanism to get a match closest to the requirement
            foreach (string str in words)
            {
                int score = algorithm.GetDistance(testWord, str);
                if (score <= algorithm.min_score)
                {
                    Console.WriteLine($"INFO:{algorithm.name} found match with score:{score}");
                }
            }
        }

        public static void levenshteinTest(List<string> testWords, string testWord, int requiredMatch)
        { // TODO: make backup mechanism to get a match closest to the requirement
            Console.WriteLine($"{requiredMatch}");
            int maxDist = (100-requiredMatch) / (100 / testWord.Length); // % -> max distance
            Console.WriteLine($"INFO: max distance converted from {requiredMatch} % to {maxDist} characters");
            Stopwatch sw = new Stopwatch();
           // List<RecognitionObject> matched = new List<RecognitionObject>();
            sw.Start();
            foreach (string str in testWords)
            {
         //       int score = LevenshteinDistance.GetDistance(testWord, str);
         //       if (score <= maxDist) 
         //       {
         //           matched.Add(new RecognitionObject(str, score));
         //       }
                // else
            }
            sw.Stop();
            Console.WriteLine($"DEBUG: elapsed: {sw.Elapsed}");
        }

        static List<String> testWords()
        {
            List<string> testWords = new List<string>();
            string[] lines = System.IO.File.ReadAllLines(@"stringDB.txt");
            testWords.AddRange(lines);
            Console.WriteLine($"INFO: {lines.Length} words added");
            return testWords;
        }

    }
}