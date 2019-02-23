This program is for testing string recognition algorithms and their performance.
Performance is tested using System.Diagnostics stopwatch class. String db with 5000 words with lenght 15 is included for testing (generated using https://www.random.org/strings/). 

Keep in mind that one of the two strings compared is constant.

How to:
	//TODO

Example usage:
	// TODO: db implementation

Recognition algorithms:

	-Levenshtein Distance
		Calculates character distance
			deletion, insertion, substitution, transposition
		Optimized version
			Algorithm breaks when score is exceeded

	-Dice Coefficient
		
	-Longest Common Subsequence (LCS)
("word match" (from childSim project))

Algortihm source: https://en.wikibooks.org/wiki/Algorithm_Implementation/Strings