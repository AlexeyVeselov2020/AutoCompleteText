using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            StringBuilder newstr = new StringBuilder();
            string[] words = phraseBeginning.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length>1)
            {
                if (nextWords.ContainsKey(phraseBeginning))
                {
                    newstr.AppendFormat("{0} {1}", phraseBeginning, nextWords[phraseBeginning]);
                    phraseBeginning = ContinuePhrase(nextWords, newstr.ToString(), wordsCount - 1);
                }
                else
                    if (nextWords.ContainsKey(words[1]))
                    {
                        newstr.AppendFormat("{0} {1}", phraseBeginning, nextWords[words[words.Length-1]]);
                        phraseBeginning = ContinuePhrase(nextWords, words[words.Length - 1], wordsCount - 1);
                    }
                else
                    return phraseBeginning;
            }
            else
            {
                if (nextWords.ContainsKey(words[1]))
                {
                    newstr.AppendFormat("{0} {1}", phraseBeginning, nextWords[words[words.Length - 1]]);
                    phraseBeginning = ContinuePhrase(nextWords, words[words.Length - 1], wordsCount - 1);
                }
                else
                    return phraseBeginning;
            }
            return phraseBeginning;
        }
    }
}