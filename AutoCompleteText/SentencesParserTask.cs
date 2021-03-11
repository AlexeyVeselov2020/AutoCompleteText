using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var sentence = new List<string>();
            string _text = text;
            //using (var sr = new StreamReader("HarryPotterText.txt"))
            //{
            //     _text = sr.ReadToEnd();
            //}
            var sb = new StringBuilder();
            for (int i = 0; i < _text.Length; i++)
            {
                if (char.IsLetter(_text[i]) || _text[i] == '\'')
                    sb.Append(_text[i]);
                else
                {
                    if (sb.Length > 0)
                    {
                        sentence.Add(sb.ToString().ToLower());
                        sb.Clear();
                    }
                    if (_text[i] == '.' || _text[i] == '!' || _text[i] == '?' || _text[i] == ';' || _text[i] == ':' || _text[i] == '(' || _text[i] == ')')
                    {
                        if (sentence.Count > 0)
                        {
                            sentencesList.Add(new List<string>(sentence));
                            sentence.Clear();
                        }
                    }
                }
            }
            if (sb.Length > 0)
            {
                sentence.Add(sb.ToString().ToLower());
                sentencesList.Add(sentence);
            }

            return sentencesList;
        }
    }
}