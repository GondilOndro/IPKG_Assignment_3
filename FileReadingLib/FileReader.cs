using FileReadingLib.Interfaces;
using System;
using System.IO;
using System.Xml.Linq;

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

        /// <inheritdoc/>
        public string ReadXmlFile(string path)
        {
            if (!path.EndsWith(".xml"))
            {
                throw new ArgumentException("Provided file have not correct format. Required file format is .xml.");
            }

            var content = ReadFile(path);

            return FormatXml(content);
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

        /// <summary>
        /// Formats content of XML file as a pretty print XML.
        /// </summary>
        /// <param name="xmlContent">Plain content of XML file.</param>
        /// <returns>Formated XML content.</returns>
        private string FormatXml(string xmlContent)
        {
            try
            {
                XDocument xmlDoc = XDocument.Parse(xmlContent);
                return xmlDoc.ToString();
            }
            catch (Exception e)
            {
                throw new Exception($"Parsing XML file failed: {e}");
            }
        }
    }
}
