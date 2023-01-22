using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfUI.VmDataContext
{
    public class VisibleProperties : INotifyPropertyChanged
    {

        private string bgButtonSizeAuto;
        private string bgButtonSizeKB;
        private string bgButtonSizeMB;
        private string bgButtonSizeGB;
        private string bgColumnName;
        private string bgColumnSize;
        private string bgColumnAllocated;
        private string bgColumnCreated;
        private bool busyIndicator;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public VisibleProperties()
        {
            ResetColorAllSizeButtons();
            SetDefaultColumnBackground();
            BgButtonSizeAuto = Constants.SizeButtonsSelected;
        }


        public string BgButtonSizeAuto
        {
            get { return bgButtonSizeAuto; }
            set { bgButtonSizeAuto = value; OnPropertyChanged(); }
        }


        public string BgButtonSizeKB
        {
            get { return bgButtonSizeKB; }
            set
            {
                bgButtonSizeKB = value;
                OnPropertyChanged();
            }
        }


        public string BgButtonSizeMB
        {
            get { return bgButtonSizeMB; }
            set
            {
                bgButtonSizeMB = value;
                OnPropertyChanged();
            }
        }


        public string BgButtonSizeGB
        {
            get { return bgButtonSizeGB; }
            set
            {
                bgButtonSizeGB = value;
                OnPropertyChanged();
            }
        }


        public string BgColumnName
        {
            get { return bgColumnName; }
            set
            {
                bgColumnName = value;
                OnPropertyChanged();
            }
        }


        public string BgColumnSize
        {
            get { return bgColumnSize; }
            set
            {
                bgColumnSize = value;
                OnPropertyChanged();
            }
        }


        public string BgColumnAllocated
        {
            get { return bgColumnAllocated; }
            set
            {
                bgColumnAllocated = value;
                OnPropertyChanged();
            }
        }


        public string BgColumnCreated
        {
            get { return bgColumnCreated; }
            set
            {
                bgColumnCreated = value;
                OnPropertyChanged();
            }
        }

        public bool BusyIndicator
        {
            get { return busyIndicator; }
            set { busyIndicator = value; OnPropertyChanged(); }
        }

        public void ResetColorAllSizeButtons()
        {
            BgButtonSizeAuto = Constants.SizeButtonsUnSelect;
            BgButtonSizeKB = Constants.SizeButtonsUnSelect;
            BgButtonSizeMB = Constants.SizeButtonsUnSelect;
            BgButtonSizeGB = Constants.SizeButtonsUnSelect;
        }

        public void SetDefaultColumnBackground()
        {
            BgColumnName = Constants.ColumnUnSelect;
            BgColumnSize = Constants.ColumnUnSelect;
            BgColumnAllocated = Constants.ColumnUnSelect;
            BgColumnCreated = Constants.ColumnUnSelect;
        }


    }
}
