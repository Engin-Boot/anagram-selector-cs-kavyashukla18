using System;
using System.Collections.Generic;

namespace Anagram
{
    public class AnagramSelector
    {
        public bool CheckWordsAreAnagram(string word1, string word2)
        {
            word1.ToLower();
            word2.ToLower();
            int[] hashOfWord1 = new int[257];
            Array.Clear(hashOfWord1, 0, hashOfWord1.Length);
            for(int iterateWord1 = 0; iterateWord1 < word1.Length; iterateWord1++)
            {
                if(word1[iterateWord1] != ' '&& word1[iterateWord1] >= 'a' && word1[iterateWord1] <= 'z')
                {
                    hashOfWord1[word1[iterateWord1] - 'a']++;
                }
                
            }

            for(int iterateWord2 = 0; iterateWord2 < word2.Length; iterateWord2++)
            {
                if(hashOfWord1[word2[iterateWord2] - 'a'] > 0)
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
        public bool WordPairIsAnagram(string word1, string word2) {
            //Insert the correct implementation here
            if (word1.Length != word2.Length)
                return false;
            else if (CheckWordsAreAnagram(word1, word2))
                return true;
            else
            return false;
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
