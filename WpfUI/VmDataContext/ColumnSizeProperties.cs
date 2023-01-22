using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfUI.VmDataContext
{
    public class ColumnSizeProperties : INotifyPropertyChanged
    {
        private Visibility columnSubFilesVisibility;
        private Visibility columnAllocatedVisibility;
        private Visibility columnSubFoldersVisibility;
        private Visibility columnPercentParentVisibility;

        private double columnAllocatedWidth;
        private double columnSubFoldersWidth;
        private double columnSubFilesWidth;
        private double columnPercentParentWidth;

        public event PropertyChangedEventHandler PropertyChanged;


        public double ColumnAllocatedWidthOld { get; set; }
        public double ColumnSubFoldersWidthOld { get; set; }
        public double ColumnSubFilesWidthOld { get; set; }
        public double ColumnPercentParentWidthOld { get; set; }



        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ColumnSizeProperties()
        {
            ColumnAllocatedWidth = Constants.MediumColumnWidth;
            ColumnSubFoldersWidth = Constants.SmallColumnWidth;
            ColumnSubFilesWidth = Constants.SmallColumnWidth;
            ColumnPercentParentWidth = Constants.MediumColumnWidth;
            ColumnAllocatedVisibility = Visibility.Visible;
            ColumnSubFoldersVisibility = Visibility.Visible;
            ColumnSubFilesVisibility = Visibility.Visible;
            ColumnPercentParentVisibility = Visibility.Visible;
        }


        public Visibility ColumnAllocatedVisibility
        {
            get { return columnAllocatedVisibility; }
            set { columnAllocatedVisibility = value; OnPropertyChanged(); }
        }


        public double ColumnAllocatedWidth
        {
            get { return columnAllocatedWidth; }
            set { columnAllocatedWidth = value; OnPropertyChanged(); }
        }

        public Visibility ColumnSubFoldersVisibility
        {
            get { return columnSubFoldersVisibility; }
            set { columnSubFoldersVisibility = value; OnPropertyChanged(); }
        }


        public double ColumnSubFoldersWidth
        {
            get { return columnSubFoldersWidth; }
            set { columnSubFoldersWidth = value; OnPropertyChanged(); }
        }


        public Visibility ColumnSubFilesVisibility
        {
            get { return columnSubFilesVisibility; }
            set { columnSubFilesVisibility = value; OnPropertyChanged(); }
        }


        public double ColumnSubFilesWidth
        {
            get { return columnSubFilesWidth; }
            set { columnSubFilesWidth = value; OnPropertyChanged(); }
        }


        public Visibility ColumnPercentParentVisibility
        {
            get { return columnPercentParentVisibility; }
            set { columnPercentParentVisibility = value; OnPropertyChanged(); }
        }


        public double ColumnPercentParentWidth
        {
            get { return columnPercentParentWidth; }
            set { columnPercentParentWidth = value; OnPropertyChanged(); }
        }
    }
}
