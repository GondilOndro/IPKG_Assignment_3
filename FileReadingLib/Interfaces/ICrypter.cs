namespace FileReadingLib.Interfaces
{
    /// <summary>
    /// Interface providing simple cryptographic methods.
    /// </summary>
    public interface ICrypter
    {
        /// <summary>
        /// Simple example of decrypting method. As a decryption is used reversing characters in string.
        /// Decryption logic could/should be replaced with some real cryptography.
        /// </summary>
        /// <param name="str">Conten</param>
        /// <returns>Decrypted string.</returns>
        string DecryptFile(string str);
    }
}
