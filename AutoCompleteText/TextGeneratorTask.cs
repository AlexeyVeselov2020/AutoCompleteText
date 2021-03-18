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
            StringBuilder newstr = new StringBuilder(phraseBeginning);
            List<string> words = new List<string>(phraseBeginning.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            while (wordsCount > 0)
            {
                if (words.Count > 1)
                {
                    var str = String.Format("{0} {1}", words[words.Count - 2], words[words.Count - 1]);
                    if (nextWords.ContainsKey(str))
                    {
                        newstr.AppendFormat(" {0}", nextWords[str]);
                        words.Add(nextWords[str]);
                        wordsCount--;
                    }
                    else
                    if (nextWords.ContainsKey(words[words.Count - 1]))
                    {
                        newstr.AppendFormat(" {0}", nextWords[words[words.Count - 1]]);
                        words.Add(nextWords[words[words.Count - 1]]);
                        wordsCount--;
                    }
                    else
                        break;
                }
                else
                {
                    if (nextWords.ContainsKey(words[words.Count - 1]))
                    {
                        newstr.AppendFormat(" {0}", nextWords[words[words.Count - 1]]);
                        words.Add(nextWords[words[words.Count - 1]]);
                        wordsCount--;
                    }
                    else
                        break;
                }
            }
            return newstr.ToString();
        }
    }
}
