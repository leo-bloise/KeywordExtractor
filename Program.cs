namespace KeywordExtractor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FrequencyAnalyzer frequencyAnalyzer = new FrequencyAnalyzer(new Tokenizer());
            Corpus corpus = new Corpus("./corpus");
            List<Document> frequencys = [];
            foreach (string data in corpus)
            {
                Dictionary<string, int> frequencyChart = frequencyAnalyzer.TokenFrequency(data);
                frequencys.Add(new Document(frequencyChart));
            }
            DocumentAnalyzer documentAnalyzer = new DocumentAnalyzer(frequencys);
            GeneralFrequency frequency = documentAnalyzer.OrderByRelevance();
            frequency.ToFile("general_frequency.txt");
        }
    }
}