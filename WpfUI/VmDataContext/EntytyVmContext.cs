using Services.Enums;
using Services.Models;
using Services.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using WpfUI.ViewModels;

namespace WpfUI.VmDataContext
{
    public class EntytyVmContext : INotifyPropertyChanged
    {
        public ObservableCollection<EntytyVM> Entyties { get; set; }

        public SizeFormats CurrentSizeFormat { get; set; }

        public SortingAttributes CurrentSortAttribute { get; set; }

        public VisibleProperties VProperties { get; set; }

        public ColumnSizeProperties SizeProperties { get; set; }

        private IDirectoryService Service { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public EntytyVmContext()
        {
            Service = new DirectoryService();
            Entyties = new ObservableCollection<EntytyVM>();
            VProperties = new VisibleProperties();
            SizeProperties = new ColumnSizeProperties();
            SelectNewPath(Constants.DefaultFolder);
        }

        public void SelectFolder()
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            if (folderBrowser.SelectedPath == null || folderBrowser.SelectedPath.Length < 1)
            {
                return;
            }

            SelectNewPath(folderBrowser.SelectedPath);
        }

        public async void SelectNewPath(string path)
        {
            BaseEntyty rootEntyty = await Service.GetAllEntytys(path);

            EntytyVM vM = new EntytyVM();
            vM.Level = 0;
            CastEntytyVMParams(vM, rootEntyty);
            vM.MarginLeft = Constants.LeftMarginFirstLevel + Constants.MarginListNodeSfx;

            Entyties.Clear();
            Entyties.Add(vM);
            ExpandItem(vM);

        }

        public void CastEntytyVMParams(EntytyVM vM, BaseEntyty entyty)
        {
            vM.Entyty = entyty;
            vM.Type = entyty.IsFile ? VmServices.GetFileType(entyty.Name.Substring(entyty.Name.LastIndexOf(".") + 1)) : "Folder";
            vM.MarginLeft = vM.Level * Constants.LeftMarginOffset + Constants.MarginListNodeSfx;
            vM.Picture = entyty.IsFile ? "/Images/file.ico" : "/Images/icons8-folder-48.png";
            vM.DisplaySize = VmServices.DisplaySize(entyty.Size, CurrentSizeFormat);
            vM.DisplayAllocated = VmServices.DisplaySize(entyty.Allocated, CurrentSizeFormat);
            if (entyty.AccessDenied)
            {
                vM.TextNameColor = Constants.TextNameAccessDenied;
                vM.TextDataColor = Constants.TextDataAccessDenied;
            }
        }

        public void ClickExpCollapseButton(EntytyVM vM)
        {
            if (!vM.Expanded)
            {
                ExpandItem(vM);
                vM.Expanded = true;
            }
            else
            {
                CollapseItem(vM);
                vM.Expanded = false;
            }
        }

        public void ExpandItem(EntytyVM vM)
        {

            long parentSize = vM.Entyty.Size;
            List<BaseEntyty> files = vM.Entyty.SubEntytys;
            Sorting(files);
            int index = Entyties.IndexOf(vM);


            foreach (BaseEntyty entyty in files)
            {
                EntytyVM entytyVM = new EntytyVM();
                entytyVM.Level = vM.Level + 1;
                CastEntytyVMParams(entytyVM, entyty);
                entytyVM.PercentOfParent = 100.0 * entyty.Size / parentSize;
                Entyties.Insert(++index, entytyVM);
            }

            vM.Expanded = true;
        }

        public void CollapseItem(EntytyVM vM)
        {
            List<BaseEntyty> files = vM.Entyty.SubEntytys;

            foreach (BaseEntyty entyty in files)
            {
                EntytyVM entytyVM = Entyties.First(item => item.Entyty == entyty);
                if (entytyVM.Expanded)
                    CollapseItem(entytyVM);
                Entyties.Remove(entytyVM);
            }

            vM.Expanded = false;
        }

        public void CollapseAll()
        {
            if (Entyties.Count > 0)
                CollapseItem(Entyties.First());
        }

        public void ChangeSizeFormat(SizeFormats format)
        {
            foreach (EntytyVM entyty in Entyties)
            {
                entyty.DisplaySize = VmServices.DisplaySize(entyty.Entyty.Size, format);
                entyty.DisplayAllocated = VmServices.DisplaySize(entyty.Entyty.Allocated, format);
            }
            CurrentSizeFormat = format;
        }

        public void Sorting(List<BaseEntyty> entyties)
        {
            List<BaseEntyty> folders = entyties.Where(item => !item.IsFile).ToList();
            List<BaseEntyty> files = entyties.Where(item => item.IsFile).ToList();

            switch (CurrentSortAttribute)
            {

                case SortingAttributes.SizeUp:
                    folders.Sort((x, y) => x.Size.CompareTo(y.Size));
                    files.Sort((x, y) => x.Size.CompareTo(y.Size));
                    break;

                case SortingAttributes.SizeDown:
                    folders.Sort((x, y) => x.Size.CompareTo(y.Size) * (-1));
                    files.Sort((x, y) => x.Size.CompareTo(y.Size) * (-1));
                    break;

                case SortingAttributes.AllocatedUp:
                    folders.Sort((x, y) => x.Allocated.CompareTo(y.Allocated));
                    files.Sort((x, y) => x.Allocated.CompareTo(y.Allocated));
                    break;

                case SortingAttributes.AllocatedDown:
                    folders.Sort((x, y) => x.Allocated.CompareTo(y.Allocated) * (-1));
                    files.Sort((x, y) => x.Allocated.CompareTo(y.Allocated) * (-1));
                    break;

                case SortingAttributes.CreatedUp:
                    folders.Sort((x, y) => x.Created.CompareTo(y.Created));
                    files.Sort((x, y) => x.Created.CompareTo(y.Created));
                    break;

                case SortingAttributes.CreatedDown:
                    folders.Sort((x, y) => x.Created.CompareTo(y.Created) * (-1));
                    files.Sort((x, y) => x.Created.CompareTo(y.Created) * (-1));
                    break;

                case SortingAttributes.NameDown:
                    folders.Sort((x, y) => x.Name.CompareTo(y.Name) * (-1));
                    files.Sort((x, y) => x.Name.CompareTo(y.Name) * (-1));
                    break;
                case SortingAttributes.SubFoldersUp:
                    folders.Sort((x, y) => x.SubFoldersCount.CompareTo(y.SubFoldersCount));
                    files.Sort((x, y) => x.SubFoldersCount.CompareTo(y.SubFoldersCount));
                    break;
                case SortingAttributes.SubFoldersDown:
                    folders.Sort((x, y) => x.SubFoldersCount.CompareTo(y.SubFoldersCount) * (-1));
                    files.Sort((x, y) => x.SubFoldersCount.CompareTo(y.SubFoldersCount) * (-1));
                    break;
                case SortingAttributes.SubFilesUp:
                    folders.Sort((x, y) => x.SubFilesCount.CompareTo(y.SubFilesCount));
                    files.Sort((x, y) => x.SubFilesCount.CompareTo(y.SubFilesCount));
                    break;
                case SortingAttributes.SubFilesDown:
                    folders.Sort((x, y) => x.SubFilesCount.CompareTo(y.SubFilesCount) * (-1));
                    files.Sort((x, y) => x.SubFilesCount.CompareTo(y.SubFilesCount) * (-1));
                    break;


                case SortingAttributes.NameUp:
                default:
                    folders.Sort((x, y) => x.Name.CompareTo(y.Name));
                    files.Sort((x, y) => x.Name.CompareTo(y.Name));
                    break;
            }

            entyties.Clear();
            entyties.AddRange(folders);
            entyties.AddRange(files);

        }

        public void ChangeSorting(SortingAttributes sort)
        {
            List<EntytyVM> expandedEntyties = Entyties.Where(item => item.Expanded).ToList();
            CollapseAll();
            CurrentSortAttribute = sort;
            foreach (EntytyVM vM in expandedEntyties)
            {
                ExpandItem(vM);
            }
            ChangeColumnColor(sort);
        }

        private void ChangeColumnColor(SortingAttributes sort)
        {
            VProperties.SetDefaultColumnBackground();
            switch (sort)
            {
                case SortingAttributes.NameUp:
                case SortingAttributes.NameDown: VProperties.BgColumnName = Constants.ColumnSelect; break;
                case SortingAttributes.SizeUp:
                case SortingAttributes.SizeDown: VProperties.BgColumnSize = Constants.ColumnSelect; break;
                case SortingAttributes.AllocatedUp:
                case SortingAttributes.AllocatedDown: VProperties.BgColumnAllocated = Constants.ColumnSelect; break;
                case SortingAttributes.CreatedUp:
                case SortingAttributes.CreatedDown: VProperties.BgColumnCreated = Constants.ColumnSelect; break;
            }
        }


    }
}
