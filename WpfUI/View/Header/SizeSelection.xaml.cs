using Services.Enums;
using System.Windows;
using System.Windows.Controls;
using WpfUI.VmDataContext;

namespace WpfUI.View.Header
{
    /// <summary>
    /// Логика взаимодействия для SizeSelection.xaml
    /// </summary>
    public partial class SizeSelection : UserControl
    {
        private EntytyVmContext Context
        {
            get
            {
                return (EntytyVmContext)this.DataContext;
            }
        }

        public SizeSelection()
        {
            InitializeComponent();
        }

        private void Button_Size_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            SizeFormats reqFormat = ConvertStringToEnum(button.Name);
            if (reqFormat == Context.CurrentSizeFormat)
                return;

            Context.VProperties.ResetColorAllSizeButtons();
            Context.ChangeSizeFormat(reqFormat);
            Context.CurrentSizeFormat = reqFormat;
            ChangeButtonColor(reqFormat);
        }

        private SizeFormats ConvertStringToEnum(string buttonName)
        {
            switch (buttonName)
            {
                case "ButtonSizeKB": return SizeFormats.kB;
                case "ButtonSizeMB": return SizeFormats.MB;
                case "ButtonSizeGB": return SizeFormats.GB;
                default: return SizeFormats.AUTO;
            }
        }

        private void ChangeButtonColor(SizeFormats format)
        {
            switch (format)
            {
                case SizeFormats.AUTO: Context.VProperties.BgButtonSizeAuto = Constants.SizeButtonsSelected; break;
                case SizeFormats.kB: Context.VProperties.BgButtonSizeKB = Constants.SizeButtonsSelected; break;
                case SizeFormats.MB: Context.VProperties.BgButtonSizeMB = Constants.SizeButtonsSelected; break;
                case SizeFormats.GB: Context.VProperties.BgButtonSizeGB = Constants.SizeButtonsSelected; break;
            }
        }
    }
}
