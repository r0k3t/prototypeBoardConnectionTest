using System.Windows;
using prototypeBoardConnectionTest.UI.ViewModel;

namespace prototypeBoardConnectionTest.UI
{
    /// <summary>
    /// Interaction logic for ControlWindow.xaml
    /// </summary>
    public partial class ControlWindow : Window
    {
        
        public ControlWindow()
        {
            InitializeComponent();
        }

        internal ControlWindow(MainWindowViewModel vm): this()
        {
            DataContext = vm;
        }
    }
}
