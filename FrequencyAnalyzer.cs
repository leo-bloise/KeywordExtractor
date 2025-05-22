namespace KeywordExtractor
{
    public class FrequencyAnalyzer
    {
        private Tokenizer _tokenizer;
        public FrequencyAnalyzer(Tokenizer tokenizer)
        {
            _tokenizer = tokenizer;
        }
        public Dictionary<string, int> TokenFrequency(string text)
        {
            IEnumerable<string> tokens = _tokenizer.Tokenize(text);
            Dictionary<string, int> frequency = new Dictionary<string, int>();
            foreach (string token in tokens)
            {
                int freq = frequency.GetValueOrDefault(token, 0);
                frequency[token] = ++freq;
            }
            return frequency;
        }
    }
}