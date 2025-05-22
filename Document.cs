namespace KeywordExtractor
{
    public record Document(
        Dictionary<string, int> Frequency
    )
    {
        public int TermFrequency(string term)
        {
            return Frequency.GetValueOrDefault(term, 0);
        }
    }
}