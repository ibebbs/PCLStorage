﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PCLStorage
{
    public class WinRTFileSystem : IFileSystem
    {
        public IFolder LocalStorage
        {
            get
            {
                return new WinRTFolder(Windows.Storage.ApplicationData.Current.LocalFolder);
            }
        }

        public IFolder RoamingStorage
        {
            get
            {
                return new WinRTFolder(Windows.Storage.ApplicationData.Current.RoamingFolder);
            }
        }

        public async Task<IFile> GetFileFromPathAsync(string path)
        {
            StorageFile storageFile = await StorageFile.GetFileFromPathAsync(path);

            return new WinRTFile(storageFile);
        }

        public async Task<IFolder> GetFolderFromPathAsync(string path)
        {
            StorageFolder storageFolder = await StorageFolder.GetFolderFromPathAsync(path);

            return new WinRTFolder(storageFolder);
        }
    }
}