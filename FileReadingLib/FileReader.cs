using FileReadingLib.Interfaces;
using System;
using System.IO;

namespace FileReadingLib
{
    /// <inheritdoc/>
    public class FileReader : IFileReader
    {
        /// <inheritdoc/>
        public string ReadTextFile(string path)
        {
            if (!path.EndsWith(".txt"))
            {
                throw new ArgumentException("Provided file have not correct format. Required file format is .txt.");
            }

            var content = ReadFile(path);

            return content;
        }

        /// <summary>
        /// Reads a file content.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <returns>Plain file content.</returns>
        private string ReadFile(string path)
        {
            using (var sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
