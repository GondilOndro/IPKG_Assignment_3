using FileReadingLib.Enums;
using FileReadingLib.Interfaces;
using System.IO;

namespace FileReadingLib
{
    /// <inheritdoc/>
    public class RoleSecurity : IRoleSecurity
    {
        public bool ValidateAccessToFile(string path, RoleType role)
        {
            var filename = Path.GetFileName(path);
            bool result = false;

            switch (role)
            {
                case RoleType.Admin:
                    {
                        result = true; // let's say Admins just have access to all files
                        break;
                    }
                case RoleType.User:
                    {
                        if (filename.StartsWith("A_"))
                        {
                            break;
                        }
                        result = true;
                        break;
                    }
            }

            return result;
        }
    }
}
