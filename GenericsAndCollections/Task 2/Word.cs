using System.Collections.Generic;

namespace GenericsAndCollections.Task_2
{
    public class Word
    {
        public int Count { get; set; }
        public string Content { get; set; }

        public Word(string content)
        {
            Content = content;
            Count = 1;
        }

        public Word(string content, int count)
        {
            Content = content;
            Count = count;
        }

        public static List<Word> Unique(string [] words)
        {
            List<Word> uniquewords = new List<Word>();

            for (int i = 0; i < words.Length; i++)
            {
                if (uniquewords.Find(item => item.Content == words[i]) != null)
                {
                    continue;
                }

                Word word = new Word(words[i]);
                uniquewords.Add(word);

                for (int j = i + 1; j < words.Length; j++)
                {   
                    if(words[i] == words[j])
                    {
                        word.Count++;
                    }
                }
            }

            return uniquewords;
        }
    }
}
