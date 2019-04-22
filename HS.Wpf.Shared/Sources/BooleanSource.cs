using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Wpf.Shared.Sources
{
    public static class BooleanSource
    {
        public static IList<ComboBoxItem> Items = new List<ComboBoxItem>()
        {
            new ComboBoxItem() { Value = false, Display = "NE" },
            new ComboBoxItem() { Value = true, Display = "ANO" }
        };

        public static ComboBoxItem GetByValue(bool b)
        {
            return Items.First(p => (bool)p.Value == b);
        }
    }
}
