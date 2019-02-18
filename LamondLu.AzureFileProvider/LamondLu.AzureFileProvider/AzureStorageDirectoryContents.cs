using Microsoft.Extensions.FileProviders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LamondLu.AzureFileProvider
{
    public class AzureStorageDirectoryContents : IDirectoryContents
    {
        private List<IFileInfo> _listInfos;

        public AzureStorageDirectoryContents(List<IFileInfo> listInfos)
        {
            _listInfos = listInfos;
        }

        public bool Exists
        {
            get
            {
                return true;
            }
        }

        public IEnumerator<IFileInfo> GetEnumerator()
        {
            return _listInfos.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _listInfos.GetEnumerator();
        }
    }
}
