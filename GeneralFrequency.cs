using System.Text;

namespace KeywordExtractor
{
    public class GeneralFrequency
    {
        public IEnumerable<KeyValuePair<string, int>> _data;
        public GeneralFrequency(IEnumerable<KeyValuePair<string, int>> data)
        {
            _data = data;
        }
        public void ToFile(string filename)
        {
            FileStream fileStream = File.OpenWrite(filename);
            foreach (KeyValuePair<string, int> pair in _data)
            {
                string text = $"{pair.Key}: {pair.Value}\n";
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                fileStream.Write(bytes);
            }
            fileStream.Close();
        }
    }
}