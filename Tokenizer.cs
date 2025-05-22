using System.Text;
using System.Text.RegularExpressions;

namespace KeywordExtractor
{
    public class Tokenizer
    {
        private List<string> ignore;
        public Tokenizer()
        {
            ignore = blacklist();
        }
        private List<string> blacklist()
        {
            return new List<string>(File.ReadAllLines("./blacklist.txt"));
        }
        public IEnumerable<string> Tokenize(string text)
        {
            string lowercased = text.ToLower();
            string[] tokens = Regex.Split(lowercased, @"\s+");
            return tokens.Select(token =>
            {
                token = token.Normalize(
                            NormalizationForm.FormD
                        );
                token = Regex.Replace(token, @"[^a-zA-Z]", "");
                return token;
            }).Where(token => token.Length > 2 && !ignore.Contains(token));
        }
    }
}