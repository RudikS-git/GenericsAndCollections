using System;
using System.Collections.Generic;

namespace GenericsAndCollections.Task_2
{
    public class FrequencyOfWords
    {
        public static List<Word> Search(string text)
        {
            string[] words = text.ToLower().Split(new char[] { ' ', ',', '.', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            return Word.Unique(words);
        }
    }
}
