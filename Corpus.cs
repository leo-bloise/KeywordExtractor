using System.Collections;

namespace KeywordExtractor
{
    public class Corpus: IEnumerable<string>
    {
        public readonly string Filepath;
        public int Size { get => _size; }
        private int _size;
        private IEnumerable<string> _filepaths;
        public Corpus(string filepath)
        {
            Filepath = filepath;
            read();
        }
        private void read()
        {
            IEnumerable<string> files = Directory.EnumerateFiles(Filepath);
            _size = files.Count();
            _filepaths = files;
        }

        public IEnumerator<string> GetEnumerator()
        {
            List<string> filedata = [];
            foreach (var filepath in _filepaths)
            {
                filedata.Add(File.ReadAllText(filepath));
            }
            return filedata.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}