using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace QuickHash.Gen
{
    public class HashGenerator
    {
        private readonly string _input;
        private string _output;

        public HashGenerator(string input)
        {
            _input = input;
        }

        public HashGenerator() : this(string.Empty) { }

        public string HashIt(string suffix)
        {
            StringBuilder sb = new StringBuilder();
            var fullInput = _input + suffix;

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(fullInput));

                foreach (byte b in result)
                    sb.Append(b.ToString("X2"));
            }

            _output = sb.ToString();

            return _output;
        }

        public void ExportTokenFile()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\token.tkn";

            if (!string.IsNullOrEmpty(_output))
                File.WriteAllText(filePath, _output);
        }
    }
}
