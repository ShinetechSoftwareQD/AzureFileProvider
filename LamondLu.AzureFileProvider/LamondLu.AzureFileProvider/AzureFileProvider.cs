using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using System;
using System.Collections.Generic;
using System.IO;

namespace LamondLu.AzureFileProvider
{
    public class AzureFileProvider : IFileProvider
    {
        private AzureStorageSetting _setting = null;

        public AzureFileProvider(AzureStorageSetting setting)
        {
            _setting = setting;
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            var rootDirectory = GetRootDirectory();

            var folderName = subpath.Substring(1);
            CloudFileDirectory folder = null;

            if (string.IsNullOrWhiteSpace(folderName))
            {
                folder = rootDirectory;
            }
            else
            {
                folder = rootDirectory.GetDirectoryReference(folderName);
            }

            var files = new List<IFileInfo>();
            foreach (var item in folder.ListFilesAndDirectoriesSegmentedAsync(new FileContinuationToken()).Result.Results)
            {
                if (item is CloudFile)
                {
                    var file = item as CloudFile;
                    files.Add(new AzureFileInfo(file));
                }
                else if (item is CloudFileDirectory)
                {
                    var directory = item as CloudFileDirectory;
                    files.Add(new AzureDirectoryInfo(directory));
                }
            }

            return new AzureStorageDirectoryContents(files);
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            var rootDirectory = GetRootDirectory();
            var file = rootDirectory.GetFileReference(subpath.Substring(1));

            return new AzureFileInfo(file);
        }

        public IChangeToken Watch(string filter)
        {
            throw new NotImplementedException();
        }

        private CloudFileDirectory GetRootDirectory()
        {
            var shareName = _setting.ShareName;
            var storageAccount = CloudStorageAccount.Parse(_setting.ConnectionString);
            var fileClient = storageAccount.CreateCloudFileClient();
            var share = fileClient.GetShareReference(shareName);
            var rootDir = share.GetRootDirectoryReference();

            return rootDir;
        }

    }
}
