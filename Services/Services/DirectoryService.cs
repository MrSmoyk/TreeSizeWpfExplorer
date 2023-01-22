using Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Services.Services
{
    public class DirectoryService : IDirectoryService
    {
        public async Task<BaseEntyty> GetAllEntytys(string path)
        {
            try
            {
                if (path == null || path.Length < 1)
                    throw new ArgumentException(nameof(path));

                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                BaseEntyty getSubEntytys = await GetSubEntytys(directoryInfo);

                return getSubEntytys;

            }
            catch (Exception ex)
            {
                return new BaseEntyty();
            }
        }

        private async Task<BaseEntyty> GetSubEntytys(DirectoryInfo directoryInfo)
        {
            BaseEntyty entyty = new BaseEntyty();

            AddSubDirectories(directoryInfo, entyty);
            AddSubFiles(directoryInfo, entyty);
            DataParametersTransfer(directoryInfo, entyty);

            return entyty;
        }

        private async Task<BaseEntyty> DirectoryProcessing(DirectoryInfo directoryInfo)
        {
            BaseEntyty entyty = await GetSubEntytys(directoryInfo);
            return entyty;
        }

        private void AddSubDirectories(DirectoryInfo sourse, BaseEntyty entyty)
        {
            DirectoryInfo[] directories;
            try
            {
                directories = sourse.GetDirectories();

            }
            catch
            {
                entyty.AccessDenied = true;
                return;
            }

            List<Task> taskList = new List<Task>();

            foreach (DirectoryInfo directory in directories)
            {
                BaseEntyty subEntyty = new BaseEntyty();

                Task wrappedInTask = Task.Run(() => AddSubDirectoriesAsync(entyty, directory, subEntyty));
                taskList.Add(wrappedInTask);
            }

            Task.WaitAll(taskList.ToArray());
        }

        private async void AddSubDirectoriesAsync(BaseEntyty entyty, DirectoryInfo directory, BaseEntyty subEntyty)
        {
            subEntyty = await DirectoryProcessing(directory);

            entyty.SubEntytys.Add(subEntyty);
            entyty.Size += subEntyty.Size;
            entyty.Allocated += subEntyty.Allocated;
            entyty.SubFoldersCount += subEntyty.SubFoldersCount;
            entyty.SubFilesCount += subEntyty.SubFilesCount;
            entyty.SubFoldersCount++;
        }

        private void AddSubFiles(DirectoryInfo sourse, BaseEntyty entyty)
        {
            if (entyty.AccessDenied)
                return;

            List<Task> taskList = new List<Task>();

            foreach (FileInfo fileInfo in sourse.GetFiles())
            {
                BaseEntyty baseEntyty = new BaseEntyty();
                Task wrappedInTask = Task.Run(() => AddSubFilesAsync(entyty, baseEntyty, fileInfo));
                taskList.Add(wrappedInTask);
            }

            Task.WaitAll(taskList.ToArray());

        }

        private async void AddSubFilesAsync(BaseEntyty entyty, BaseEntyty baseEntyty, FileInfo fileInfo)
        {
            baseEntyty = await GetFileInformation(fileInfo);
            entyty.SubEntytys.Add(baseEntyty);
            entyty.Size += baseEntyty.Size;
            entyty.Allocated += baseEntyty.Allocated;
            entyty.SubFilesCount++;
        }

        private async Task<BaseEntyty> GetFileInformation(FileInfo file)
        {
            BaseEntyty entyty = new BaseEntyty();

            entyty.Name = file.Name;
            entyty.Size = file.Length;

            entyty.Allocated = await GetFileSizeOnDisk(file.FullName);
            entyty.IsFile = true;
            entyty.Created = file.CreationTime;
            entyty.Modificated = file.LastWriteTime;

            return entyty;
        }

        private void DataParametersTransfer(DirectoryInfo sourse, BaseEntyty entyty)
        {
            entyty.Name = sourse.Name;
            entyty.Created = sourse.CreationTime;
            entyty.Modificated = sourse.LastWriteTime;
        }

        private static async Task<long> GetFileSizeOnDisk(string file)
        {
            FileInfo info = new FileInfo(file);
            uint dum, sectorsPerCluster, bytesPerSector;
            int result = GetDiskFreeSpaceW(info.Directory.Root.FullName, out sectorsPerCluster, out bytesPerSector, out dum, out dum);
            if (result == 0) throw new Win32Exception();
            uint clusterSize = sectorsPerCluster * bytesPerSector;
            uint hosize;
            uint losize = GetCompressedFileSizeW(file, out hosize);
            long size;
            size = (long)hosize << 32 | losize;
            return ((size + clusterSize - 1) / clusterSize) * clusterSize;
        }

        [DllImport("kernel32.dll")]
        static extern uint GetCompressedFileSizeW([In, MarshalAs(UnmanagedType.LPWStr)] string lpFileName,
           [Out, MarshalAs(UnmanagedType.U4)] out uint lpFileSizeHigh);

        [DllImport("kernel32.dll", SetLastError = true, PreserveSig = true)]
        static extern int GetDiskFreeSpaceW([In, MarshalAs(UnmanagedType.LPWStr)] string lpRootPathName,
           out uint lpSectorsPerCluster, out uint lpBytesPerSector, out uint lpNumberOfFreeClusters,
           out uint lpTotalNumberOfClusters);
    }
}
