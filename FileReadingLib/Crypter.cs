using System;
using System.IO;

namespace FileReadingLib.Interfaces
{
    /// <inheritdoc/>
    public class Crypter : ICrypter
    {
        /// <inheritdoc/>
        public string DecryptFile(string path)
        {
            // sample check if file is encrypted
            var filename = Path.GetFileName(path);
            if (!filename.Contains("Encrypted_"))
            {
                throw new ArgumentException("File is not encrypted, hence could not be decrypted.");
            }

            using StreamReader sr = new StreamReader(path);

            char[] charArray = sr.ReadToEnd().ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
