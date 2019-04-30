using HS.Wpf.ARO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Wpf.ARO.Messages
{
    public class SaveOrMessage
    {
        public IList<OperationRoomActionModel> Items { get; set; }

        public SaveOrMessage(IList<OperationRoomActionModel> items)
        {
            Items = items ?? throw new ArgumentNullException(nameof(items));
        }
    }
}
