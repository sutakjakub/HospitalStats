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
    /// Interaction logic for CollectionActionsView.xaml
    /// </summary>
    public partial class CollectionActionsView : UserControl
    {
        public static readonly DependencyProperty SelectedActionProperty =
             DependencyProperty.Register(nameof(SelectedAction), typeof(object),
             typeof(CollectionActionsView), new FrameworkPropertyMetadata(null));

        public object SelectedAction
        {
            get { return (object)GetValue(SelectedActionProperty); }
            set { SetValue(SelectedActionProperty, value); }
        }


        public CollectionActionsView()
        {
            InitializeComponent();
        }

        private void dataGridStats_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            //if (e.Row.GetIndex() != 0)
            //{
            //    e.Cancel = true;
            //}
        }
    }
}
