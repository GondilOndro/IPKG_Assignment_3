namespace FileReadingLib.Interfaces
{
    // Provides methods for reading files
    public interface IFileReader
    {
        /// <summary>
        /// Method for reading text file.
        /// </summary>
        /// <param name="path">Path to file to be read.</param>
        /// <returns>Content of the file.</returns>
        string ReadTextFile(string path);
    }
}
