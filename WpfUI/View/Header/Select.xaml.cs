using System.Windows;
using System.Windows.Controls;
using WpfUI.VmDataContext;

namespace WpfUI.View.Header
{
    /// <summary>
    /// Логика взаимодействия для Select.xaml
    /// </summary>
    public partial class Select : UserControl
    {
        public Select()
        {
            InitializeComponent();
        }

        private EntytyVmContext Context
        {
            get
            {
                return (EntytyVmContext)this.DataContext;
            }
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            Context.VProperties.BusyIndicator = true;
            Context.SelectFolder();
            Context.VProperties.BusyIndicator = false;
        }
    }
}
