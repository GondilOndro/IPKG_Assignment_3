using FileReadingLib.Enums;
using FileReadingLib.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Xml.Linq;

namespace FileReadingLib
{
    /// <inheritdoc/>
    public class FileReader : IFileReader
    {
        private readonly ICrypter _crypter = new Crypter();
        private readonly IRoleSecurity _roleSecurity = new RoleSecurity();

        /// <inheritdoc/>
        public string ReadTextFile(string path, bool isEncrypted)
        {
            if (!path.EndsWith(".txt"))
            {
                throw new ArgumentException("Provided file have not correct format. Required file format is .txt.");
            }

            var content = ReadFile(path, isEncrypted);

            return content;
        }

        public string ReadTextFile(string path, bool isEncrypted, RoleType? role)
        {
            if (role != null && !_roleSecurity.ValidateAccessToFile(path, role.Value))
            {
                throw new UnauthorizedAccessException("Content of this file is not accessible by your role.");
            }

            return ReadTextFile(path, isEncrypted);
        }

        /// <inheritdoc/>
        public string ReadXmlFile(string path, bool isEncrypted)
        {
            if (!path.EndsWith(".xml"))
            {
                throw new ArgumentException("Provided file have not correct format. Required file format is .xml.");
            }

            var content = ReadFile(path, isEncrypted);

            return FormatXml(content);
        }

        public string ReadXmlFile(string path, bool isEncrypted, RoleType? role)
        {
            if (role != null && !_roleSecurity.ValidateAccessToFile(path, role.Value))
            {
                throw new UnauthorizedAccessException("Content of this file is not accessible by your role.");
            }

            return ReadXmlFile(path, isEncrypted);
        }

        /// <inheritdoc/>
        public string ReadJsonFile(string path)
        {
            if (!path.EndsWith(".json"))
            {
                throw new ArgumentException("Provided file have not correct format. Required file format is .json.");
            }

            var content = ReadFile(path, false);

            return FormatJson(content);
        }

        /// <summary>
        /// Reads a file content.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="isEncrypted">Indicates whether file is encrypted and should be decrypted before showing.</param>
        /// <returns>Plain file content.</returns>
        private string ReadFile(string path, bool isEncrypted)
        {
            if (isEncrypted)
            {
                return _crypter.DecryptFile(path);
            }

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

        /// <summary>
        /// Formats content of JSON file as a pretty print JSON.
        /// </summary>
        /// <param name="jsonContent">Plain content of JSON file.</param>
        /// <returns>Formated XML content.</returns>
        private string FormatJson(string jsonContent)
        {
            try
            {
                string jsonDoc = JValue.Parse(jsonContent).ToString(Formatting.Indented);
                return jsonDoc;
            }
            catch (Exception e)
            {
                throw new Exception($"Parsing JSON file failed: {e}");

            }
        }
    }
}
