using FileReadingLib.Enums;

namespace FileReadingLib.Interfaces
{
    // Provides methods for reading files
    public interface IFileReader
    {
        /// <summary>
        /// Method for reading text file.
        /// </summary>
        /// <param name="path">Path to file to be read.</param>
        /// <param name="isEncrypted">Indicates whether file is encrypted and should be decrypted before showing.</param>
        /// <returns>Content of the file.</returns>
        string ReadTextFile(string path, bool isEncrypted);

        /// <summary>
        /// Method for reading text file.
        /// </summary>
        /// <param name="path">Path to file to be read.</param>
        /// <param name="isEncrypted">Indicates whether file is encrypted and should be decrypted before showing.</param>
        /// <param name="role">Defining role of user.</param>
        /// <returns>Content of the file.</returns>
        string ReadTextFile(string path, bool isEncrypted, RoleType? role);

        /// <summary>
        /// Method for reading XML file.
        /// </summary>
        /// <param name="path">Path to file to be read.</param>
        /// <param name="isEncrypted">Indicates whether file is encrypted and should be decrypted before showing.</param>
        /// <returns>Formated content of the XML file.</returns>
        string ReadXmlFile(string path, bool isEncrypted);

        /// <summary>
        /// Method for reading XML file.
        /// </summary>
        /// <param name="path">Path to file to be read.</param>
        /// <param name="isEncrypted">Indicates whether file is encrypted and should be decrypted before showing.</param>
        /// <param name="role">Defining role of user.</param>
        /// <returns>Formated content of the XML file.</returns>
        string ReadXmlFile(string path, bool isEncrypted, RoleType? role);

        /// <summary>
        /// Method for reading JSON file.
        /// </summary>
        /// <param name="path">Path to file to be read.</param>
        /// <param name="isEncrypted">Indicates whether file is encrypted and should be decrypted before showing.</param>
        /// <returns>Formated content of the XML file.</returns>
        string ReadJsonFile(string path, bool isEncrypted);

        /// <summary>
        /// Method for reading JSON file.
        /// </summary>
        /// <param name="path">Path to file to be read.</param>
        /// <param name="isEncrypted">Indicates whether file is encrypted and should be decrypted before showing.</param>
        /// <param name="role">Defining role of user.</param>
        /// <returns>Formated content of the XML file.</returns>
        string ReadJsonFile(string path, bool isEncrypted, RoleType? role);
    }
}
