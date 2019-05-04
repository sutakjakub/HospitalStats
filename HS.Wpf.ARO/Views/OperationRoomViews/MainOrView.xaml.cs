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

namespace HS.Wpf.ARO.Views.OperationRoomViews
{
    /// <summary>
    /// Interaction logic for MainOrView.xaml
    /// </summary>
    public partial class MainOrView : UserControl
    {
        public MainOrView()
        {
            InitializeComponent();
        }

        private void DataToggle_Checked(object sender, RoutedEventArgs e)
        {
            dataRow.Height = new GridLength(1, GridUnitType.Star);
            splitterRow.Height = new GridLength(5);
        }

        private void DataToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            dataRow.Height = new GridLength(0);
            splitterRow.Height = new GridLength(0);
        }

        private void StatsToggle_Checked(object sender, RoutedEventArgs e)
        {
            statsRow.Height = new GridLength(1, GridUnitType.Star);
        }

        private void StatsToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            statsRow.Height = new GridLength(0);
        }
    }
}
