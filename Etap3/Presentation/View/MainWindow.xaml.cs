using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Task.Run(async () =>
            {
                while (true)
                {
                    Dispatcher.Invoke(() => itemss.Items.Refresh());
                    await Task.Delay(20);
                }
            });
        }

        private void StartSimulationButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BallsNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
