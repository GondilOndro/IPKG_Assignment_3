using FileReadingLib.Enums;

namespace FileReadingLib.Interfaces
{
    /// <summary>
    /// Interface for managing role based security.
    /// </summary>
    public interface IRoleSecurity
    {
        /// <summary>
        /// Checks if specified file is accessible by user with particular role.
        /// Simple example only checks for presence of specific character at the beginning of filename.
        /// Logic should be replaced with complex solution storing permissions for files and particular roles in e.g. DB.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <param name="role">Role type of requesting user.</param>
        /// <returns>True if user has access to file, otherwise returns False.</returns>
        bool ValidateAccessToFile(string path, RoleType role);
    }
}
