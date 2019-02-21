using Microsoft.Extensions.FileProviders;
using Microsoft.WindowsAzure.Storage.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LamondLu.AzureFileProvider
{
    public class AzureFileContentInfo : IFileInfo
    {
        private CloudFile _file = null;
        private MemoryStream _stream = new MemoryStream();

        public AzureFileContentInfo(CloudFile file)
        {
            _file = file;
            _file.DownloadRangeToStreamAsync(_stream, null, null).Wait();
            _stream.Position = 0;
        }

        public bool Exists
        {
            get
            {
                return true;
            }
        }

        public long Length
        {
            get
            {
                return _stream.Length;
            }
        }

        public string PhysicalPath
        {
            get
            {
                return _file.Uri.AbsolutePath;
            }
        }

        public string Name
        {
            get
            {
                return _file.Name;
            }
        }

        public DateTimeOffset LastModified
        {
            get
            {
                return _file.Properties.LastModified.GetValueOrDefault();
            }
        }

        public bool IsDirectory
        {
            get
            {
                return false;
            }
        }


        public Stream CreateReadStream()
        {
            return _stream;
        }
    }
}
