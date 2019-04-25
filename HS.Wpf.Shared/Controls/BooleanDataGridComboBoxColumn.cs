using HS.Wpf.Shared.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HS.Wpf.Shared.Controls
{
    public class BooleanDataGridComboBoxColumn : DataGridComboBoxColumn
    {
        public BooleanDataGridComboBoxColumn()
        {
            ItemsSource = BooleanSource.Items;
            DisplayMemberPath = "Display";
            SelectedValuePath = "Value";
        }
    }
}
