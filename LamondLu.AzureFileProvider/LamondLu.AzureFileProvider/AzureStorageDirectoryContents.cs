using Microsoft.Extensions.FileProviders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LamondLu.AzureFileProvider
{
    public class AzureStorageDirectoryContents : IDirectoryContents
    {
        public bool Exists => throw new NotImplementedException();

        public IEnumerator<IFileInfo> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
