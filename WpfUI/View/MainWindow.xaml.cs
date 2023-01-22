using Services.Enums;
using System.Windows;
using System.Windows.Controls;
using WpfUI.ViewModels;
using WpfUI.VmDataContext;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EntytyVmContext Context
        {
            get
            {
                return (EntytyVmContext)this.DataContext;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            EntytyVM vM = button.DataContext as EntytyVM;

            if (!vM.Entyty.IsFile)
            {
                Context.ClickExpCollapseButton(vM);
            }

        }

        private void HeaderClickName(object sender, RoutedEventArgs e)
        {
            if (Context.CurrentSortAttribute == SortingAttributes.NameUp)
            {
                Context.ChangeSorting(SortingAttributes.NameDown);
            }
            else if (Context.CurrentSortAttribute == SortingAttributes.NameDown || Context.CurrentSortAttribute != SortingAttributes.NameUp)
            {
                Context.ChangeSorting(SortingAttributes.NameUp);
            }
        }

        private void HeaderClickSize(object sender, RoutedEventArgs e)
        {
            if (Context.CurrentSortAttribute == SortingAttributes.SizeUp)
            {
                Context.ChangeSorting(SortingAttributes.SizeDown);
            }
            else if (Context.CurrentSortAttribute == SortingAttributes.SizeDown || Context.CurrentSortAttribute != SortingAttributes.SizeUp)
            {
                Context.ChangeSorting(SortingAttributes.SizeUp);
            }
        }

        private void HeaderClickAllocated(object sender, RoutedEventArgs e)
        {
            if (Context.CurrentSortAttribute == SortingAttributes.AllocatedUp)
            {
                Context.ChangeSorting(SortingAttributes.AllocatedDown);
            }
            else if (Context.CurrentSortAttribute == SortingAttributes.AllocatedDown || Context.CurrentSortAttribute != SortingAttributes.AllocatedUp)
            {
                Context.ChangeSorting(SortingAttributes.AllocatedUp);
            }
        }

        private void HeaderClickCreated(object sender, RoutedEventArgs e)
        {
            if (Context.CurrentSortAttribute == SortingAttributes.CreatedUp)
            {
                Context.ChangeSorting(SortingAttributes.CreatedDown);
            }
            else if (Context.CurrentSortAttribute == SortingAttributes.CreatedDown || Context.CurrentSortAttribute != SortingAttributes.CreatedUp)
            {
                Context.ChangeSorting(SortingAttributes.CreatedUp);
            }
        }

        private void HeaderClickSubFolders(object sender, RoutedEventArgs e)
        {
            if (Context.CurrentSortAttribute == SortingAttributes.SubFoldersUp)
            {
                Context.ChangeSorting(SortingAttributes.SubFoldersDown);
            }
            else if (Context.CurrentSortAttribute == SortingAttributes.SubFoldersDown || Context.CurrentSortAttribute != SortingAttributes.SubFoldersUp)
            {
                Context.ChangeSorting(SortingAttributes.SubFoldersUp);
            }
        }

        private void HeaderClickSubFiles(object sender, RoutedEventArgs e)
        {
            if (Context.CurrentSortAttribute == SortingAttributes.SubFilesUp)
            {
                Context.ChangeSorting(SortingAttributes.SubFilesDown);
            }
            else if (Context.CurrentSortAttribute == SortingAttributes.SubFilesDown || Context.CurrentSortAttribute != SortingAttributes.SubFilesUp)
            {
                Context.ChangeSorting(SortingAttributes.SubFilesUp);
            }
        }

    }
}
