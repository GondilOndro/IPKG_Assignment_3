using FileReadingLib;
using FileReadingLib.Enums;
using FileReadingLib.Interfaces;
using ReactiveUI;
using System;
using System.IO;
using System.Linq;

namespace GuiSample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string[] _fileTypes = new string[] { ".txt", ".xml", ".json" };
        private string _selectedFileType;
        private bool _isEncrypted;
        private bool _useRole;
        private RoleType[] _roles;
        private RoleType? _selectedRole;
        private readonly string[] _allFiles;
        private string[] _files;
        private string _selectedFile;
        private readonly IFileReader _fileReader;
        private string _textOfFile;

        public MainWindowViewModel()
        {
            _roles = GetRoles();
            _files = _allFiles = GetFiles();
            _fileReader = new FileReader();
        }

        public string SelectedFileType
        {
            get => _selectedFileType;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedFileType, value);
                ChangeFilesList();
            }
        }
        public string[] FileTypes { get => _fileTypes; set => _fileTypes = value; }
        public bool IsEncrypted
        {
            get => _isEncrypted;
            set
            {
                this.RaiseAndSetIfChanged(ref _isEncrypted, value);
                ChangeFilesList();
            }
        }
        public bool UseRole { get => _useRole; set => this.RaiseAndSetIfChanged(ref _useRole, value); }
        public RoleType[] Roles { get => _roles; set => _roles = value; }
        public RoleType? SelectedRole { get => _selectedRole; set => this.RaiseAndSetIfChanged(ref _selectedRole, value); }
        public string[] Files
        {
            get => _files;
            set => this.RaiseAndSetIfChanged(ref _files, value);
        }
        public string SelectedFile
        {
            get => _selectedFile;
            set => this.RaiseAndSetIfChanged(ref _selectedFile, value);
        }
        public string TextOfFile { get => _textOfFile; set => this.RaiseAndSetIfChanged(ref _textOfFile, value); }

        public void ShowFile()
        {
            if(SelectedFileType==null || SelectedFile == null)
            {
                return;
            }

            try
            {
                switch (_selectedFileType)
                {
                    case ".txt":
                        {
                            TextOfFile = _fileReader.ReadTextFile(_selectedFile, _isEncrypted, _selectedRole);
                            return;
                        }
                    case ".xml":
                        {
                            TextOfFile = _fileReader.ReadXmlFile(_selectedFile, _isEncrypted, _selectedRole);
                            return;
                        }
                    case ".json":
                        {
                            TextOfFile = _fileReader.ReadJsonFile(_selectedFile, _isEncrypted, _selectedRole);
                            return;
                        }
                }
            }
            catch (Exception e)
            {
                TextOfFile = "WARNING:" + e.Message;
            }
        }

        private void ChangeFilesList()
        {
            Files = _allFiles.Where(x => Path.GetExtension(x).Equals(_selectedFileType))
                .Where(x => _isEncrypted
                                ? Path.GetFileNameWithoutExtension(x).Contains("Encrypted_")
                                : !Path.GetFileNameWithoutExtension(x).Contains("Encrypted_")).ToArray();
        }

        private RoleType[] GetRoles()
        {
            return (RoleType[])Enum.GetValues(typeof(RoleType));
        }

        private string[] GetFiles()
        {
            var filesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "files");
            return Directory.GetFiles(filesDirectory);
        }
    }
}
