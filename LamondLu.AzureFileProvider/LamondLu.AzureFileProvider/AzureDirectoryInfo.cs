using Microsoft.Extensions.FileProviders;
using Microsoft.WindowsAzure.Storage.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LamondLu.AzureFileProvider
{
    public class AzureDirectoryInfo : IFileInfo
    {
        private CloudFileDirectory _directory = null;

        public AzureDirectoryInfo(CloudFileDirectory directory)
        {
            _directory = directory;
        }

        public bool Exists
        {
            get
            {
                return true;
            }
        }

        public long Length => throw new NotImplementedException();

        public string PhysicalPath
        {
            get
            {
                return _directory.Uri.AbsolutePath;
            }
        }

        public string Name
        {
            get
            {
                return _directory.Name;
            }
        }

        public DateTimeOffset LastModified
        {
            get
            {
                return _directory.Properties.LastModified.GetValueOrDefault();
            }
        }

        public bool IsDirectory
        {
            get
            {
                return true;
            }
        }

        public Stream CreateReadStream()
        {
            throw new NotImplementedException();
        }
    }
}
