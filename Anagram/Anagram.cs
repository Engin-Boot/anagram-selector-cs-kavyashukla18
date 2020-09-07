using System;
using System.Collections.Generic;

namespace Anagram
{
    public class AnagramSelector
    {
        int[] hashOfWord1 = new int[257];

        public string RemoveSpaceFromWord(string word)
        {
            return word.Replace(" ", string.Empty);
        }
        public void MapEachWord(string word1)
        {
            Array.Clear(hashOfWord1, 0, hashOfWord1.Length);
            for (int iterateWord1 = 0; iterateWord1 < word1.Length; iterateWord1++)
            {
                if (word1[iterateWord1] >= 'a' && word1[iterateWord1] <= 'z')
                {
                    hashOfWord1[word1[iterateWord1] - 'a']++;
                }

            }
        }
        public bool WordPairIsAnagram(string word1, string word2) {
            //Insert the correct implementation here

            word1.ToLower();
            word2.ToLower();

            word1 = RemoveSpaceFromWord(word1);
            word2 = RemoveSpaceFromWord(word2);
            MapEachWord(word1);

            if (word1.Length != word2.Length)
                return false;
            else
            {
                for (int iterateWord2 = 0; iterateWord2 < word2.Length; iterateWord2++)
                {
                    if (hashOfWord1[word2[iterateWord2] - 'a'] > 0)
                    {
                        hashOfWord1[word2[iterateWord2] - 'a']--;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public List<string> SelectAnagrams(string word, List<string> candidates) {
            //Insert the correct implementation here

            for(int iterateCandidates = 0; iterateCandidates < candidates.Count; iterateCandidates++)
            {
                if(!WordPairIsAnagram(word, candidates[iterateCandidates]))
                {
                    candidates.RemoveAt(iterateCandidates);
                }
            }
            return candidates;
        }
    }
}
