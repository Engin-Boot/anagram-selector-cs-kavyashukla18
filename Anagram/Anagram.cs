using System;
using System.Collections.Generic;

namespace Anagram
{
    public class AnagramSelector
    {
        int[] hashOfWord1 = new int[257];
        public void MapEachWord(string word1)
        {
            Array.Clear(hashOfWord1, 0, hashOfWord1.Length);
            for (int i = 0; i < word1.Length; i++)
            {
                hashOfWord1[word1[i] - 'a']++;
            }
        }
        public bool WordPairIsAnagram(string word1, string word2) {
            word1.ToLower();
            word2.ToLower();
            word1 = word1.Replace(" ", string.Empty);
            word2 = word2.Replace(" ", string.Empty);
            MapEachWord(word1);
            if (word1.Length != word2.Length)
                return false;
            for (int i = 0; i < word2.Length; i++)
                {
                    if (hashOfWord1[word2[i] - 'a'] <= 0)
                    {
                        return false;
                    }
                    hashOfWord1[word2[i] - 'a']--;
                }
             return true;
        }
        public List<string> SelectAnagrams(string word, List<string> candidates) {
            for(int i = 0; i < candidates.Count; i++)
            {
                if(!WordPairIsAnagram(word, candidates[i]))
                {
                    candidates.RemoveAt(i);
                }
            }
            return candidates;
        }
    }
}
