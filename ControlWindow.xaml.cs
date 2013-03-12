using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Robotics.Services.Sample.HiTechnic.PrototypeBoard.Proxy;

namespace prototypeBoardConnectionTest
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
