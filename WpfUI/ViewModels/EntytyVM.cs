using Services.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfUI.ViewModels
{
    public class EntytyVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string picture;
        private string displaySize;
        private string displayAllocated;
        private string textNameColor;
        private string textDataColor;

        public BaseEntyty Entyty { get; set; }

        public string Type { get; set; }

        public double PercentOfParent { get; set; }

        public int Level { get; set; }

        public string MarginLeft { get; set; }

        public bool Expanded { get; set; }

        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public EntytyVM()
        {
            TextDataColor = Constants.TextNameOK;
            TextNameColor = Constants.TextDataOK;
        }

        public string Picture
        {
            get { return picture; }
            set { picture = value; OnPropertyChanged(); }
        }

        public string DisplaySize
        {
            get { return displaySize; }
            set { displaySize = value; OnPropertyChanged(); }
        }

        public string DisplayAllocated
        {
            get { return displayAllocated; }
            set { displayAllocated = value; OnPropertyChanged(); }
        }

        public string TextNameColor
        {
            get { return textNameColor; }
            set { textNameColor = value; OnPropertyChanged(); }
        }

        public string TextDataColor
        {
            get { return textDataColor; }
            set { textDataColor = value; OnPropertyChanged(); }
        }

    }
}
