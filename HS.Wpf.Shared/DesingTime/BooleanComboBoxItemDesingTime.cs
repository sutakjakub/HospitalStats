using HS.Wpf.Shared.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Wpf.Shared.DesingTime
{
    public class BooleanComboBoxItemDesingTime : ComboBoxItem
    {
        public BooleanComboBoxItemDesingTime()
        {
            var item = BooleanSource.GetByValue(true);
            Value = item.Value;
            Display = item.Display;
        }
    }
}
