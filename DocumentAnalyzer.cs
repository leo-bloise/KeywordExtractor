namespace KeywordExtractor
{
    public class DocumentAnalyzer
    {
        private IEnumerable<Document> _documents;
        public DocumentAnalyzer(IEnumerable<Document> documents)
        {
            _documents = documents;
        }
        public GeneralFrequency OrderByRelevance()
        {
            Dictionary<string, int> generalFrequency = new Dictionary<string, int>();
            foreach (Document document in _documents)
            {
                foreach (string term in document.Frequency.Keys)
                {
                    generalFrequency[term] = generalFrequency.GetValueOrDefault(term, 0) + document.TermFrequency(term);
                }
            }
            return new GeneralFrequency(generalFrequency.OrderByDescending(keyValuePair => keyValuePair.Value).Where(KeyValuePair => KeyValuePair.Value > 5));
        }
    }
}