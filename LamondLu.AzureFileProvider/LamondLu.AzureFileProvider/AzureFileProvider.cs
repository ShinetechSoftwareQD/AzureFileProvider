using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using System;

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
            throw new NotImplementedException();
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            throw new NotImplementedException();
        }

        public IChangeToken Watch(string filter)
        {
            throw new NotImplementedException();
        }

        private CloudFileDirectory GetRootDirectory()
        {
            var shareName = _setting.SharedName;
            var storageAccount = CloudStorageAccount.Parse(_setting.ConnectionString);
            var fileClient = storageAccount.CreateCloudFileClient();
            var share = fileClient.GetShareReference(shareName);
            var rootDir = share.GetRootDirectoryReference();

            return rootDir;
        }

    }
}
